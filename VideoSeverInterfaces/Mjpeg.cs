using System;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;
using System.Drawing;

namespace Interfaces
{
    class Mjpeg : SourceFormater
    {
        bool finishThread = false;

        public override event CameraEventHandler NewFrame;

        public override void Start()
        {
            // create events
            stopEvent = new ManualResetEvent(false);
            reloadEvent = new ManualResetEvent(false);
            thread = new Thread(new ThreadStart(WorkerThread));
            //thread.Name = DateTime.Now.ToString();
            // cameraAdapter.CameraName;
            thread.Start();
        }

        public override void Stop()
        {
            stopEvent.Set();
            reloadEvent.Set();
            thread = null;
        }

        public override void WorkerThread()
        {
            byte[] buffer = new byte[bufSize];	// buffer to read stream
            SetAllowUnsafeHeaderParsing20();
            while (!stopEvent.WaitOne(0, true))
            {
                // reset reload event
                reloadEvent.Reset();
                if (finishThread)
                    return;
                HttpWebRequest req = null;
                WebResponse resp = null;
                Stream stream = null;
                byte[] delimiter = null;
                byte[] delimiter2 = null;
                byte[] boundary = null;
                int boundaryLen, delimiterLen = 0, delimiter2Len = 0;
                int read, todo = 0, total = 0, pos = 0, align = 1;
                int start = 0, stop = 0;

                // align
                //  1 = searching for image start
                //  2 = searching for image end
                try
                {
                    // create request
                    req = (HttpWebRequest)WebRequest.Create(cameraAdapter.Connection);
                    // set login and password
                    if ((cameraAdapter.Login != null) && (cameraAdapter.Password != null) && (cameraAdapter.Login != ""))
                        req.Credentials = new NetworkCredential(cameraAdapter.Login, cameraAdapter.Password);
                    // set connection group name
                    if (useSeparateConnectionGroup)
                        req.ConnectionGroupName = GetHashCode().ToString();
                    req.Timeout = 10000;//10 sec
                    // get response
                    resp = req.GetResponse();

                    // check content type
                    string ct = resp.ContentType;
                    if (ct.IndexOf("multipart/x-mixed-replace") == -1)
                        throw new ApplicationException("Invalid URL");

                    // get boundary
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    boundary = encoding.GetBytes(ct.Substring(ct.IndexOf("boundary=", 0) + 9));
                    boundaryLen = boundary.Length;

                    // get response stream
                    stream = resp.GetResponseStream();

                    // loop
                    while ((!stopEvent.WaitOne(0, true)) && (!reloadEvent.WaitOne(0, true)))
                    {
                        // check total read
                        if (total > bufSize - readSize)
                        {
                            total = pos = todo = 0;
                        }

                        // read next portion from stream
                        if ((read = stream.Read(buffer, total, readSize)) == 0)
                            throw new ApplicationException();

                        total += read;
                        todo += read;

                        // increment received bytes counter
                        bytesReceived += read;

                        // does we know the delimiter ?
                        if (delimiter == null)
                        {
                            // find boundary
                            pos = ByteArrayUtils.Find(buffer, boundary, pos, todo);

                            if (pos == -1)
                            {
                                // was not found
                                todo = boundaryLen - 1;
                                pos = total - todo;
                                continue;
                            }

                            todo = total - pos;

                            if (todo < 2)
                                continue;

                            // check new line delimiter type
                            if (buffer[pos + boundaryLen] == 10)
                            {
                                delimiterLen = 2;
                                delimiter = new byte[2] { 10, 10 };
                                delimiter2Len = 1;
                                delimiter2 = new byte[1] { 10 };
                            }
                            else
                            {
                                delimiterLen = 4;
                                delimiter = new byte[4] { 13, 10, 13, 10 };
                                delimiter2Len = 2;
                                delimiter2 = new byte[2] { 13, 10 };
                            }

                            pos += boundaryLen + delimiter2Len;
                            todo = total - pos;
                        }

                        // search for image
                        if (align == 1)
                        {
                            start = ByteArrayUtils.Find(buffer, delimiter, pos, todo);
                            if (start != -1)
                            {
                                // found delimiter
                                start += delimiterLen;
                                pos = start;
                                todo = total - pos;
                                align = 2;
                            }
                            else
                            {
                                // delimiter not found
                                todo = delimiterLen - 1;
                                pos = total - todo;
                            }
                        }

                        // search for image end
                        while ((align == 2) && (todo >= boundaryLen))
                        {
                            stop = ByteArrayUtils.Find(buffer, boundary, pos, todo);
                            if (stop != -1)
                            {
                                pos = stop;
                                todo = total - pos;

                                // increment frames counter
                                framesReceived++;
                                if (finishThread)
                                    return;


                                // image at stop
                                if (NewFrame != null)
                                {
                                    Bitmap bmp = (Bitmap)Bitmap.FromStream(new MemoryStream(buffer, start, stop - start));
                                    // notify client
                                    this.lastFrame = bmp;
                                    Graphics g = Graphics.FromImage(bmp);
                                    Font drawFont = new Font("System", 12, FontStyle.Bold);
                                    SolidBrush drawBrush = new SolidBrush(Color.Black);


                                    //NewFrame(this, new CameraEventArgs(bmp));
                                    if ((cameraAdapter.SaveToFile) && (!stopEvent.WaitOne(0, true)) && (!reloadEvent.WaitOne(0, true)))
                                    {
                                        if (cameraAdapter.MoviDetect)
                                        {
                                            if (MotionDetect(ref bmp))
                                            {
                                                SaveToFile(bmp);
                                            }
                                            else
                                            {
                                                CloseFile();
                                            }
                                        }
                                        else
                                        {
                                            SaveToFile(bmp);
                                        }

                                    }
                                    g.DrawString(DateTime.Now.ToString(), drawFont, drawBrush, new PointF(5, bmp.Height - 20));
                                    NewFrame(this, new CameraEventArgs(bmp));
                                    drawBrush.Dispose();
                                    drawFont.Dispose();
                                    g.Dispose();
                                    // release the image
                                    bmp.Dispose();
                                    bmp = null;
                                }

                                // shift array
                                pos = stop + boundaryLen;
                                todo = total - pos;
                                Array.Copy(buffer, pos, buffer, 0, todo);

                                total = todo;
                                pos = 0;
                                align = 1;
                            }
                            else
                            {
                                // delimiter not found
                                todo = boundaryLen - 1;
                                pos = total - todo;
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
                    // wait for a while before the next try
                    Thread.Sleep(250);
                }
                catch (ApplicationException ex)
                {
                    System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
                    // wait for a while before the next try
                    Thread.Sleep(250);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
                }
                finally
                {
                    CloseFile();
                    // abort request
                    if (req != null)
                    {
                        req.Abort();
                        req = null;
                    }
                    // close response stream
                    if (stream != null)
                    {
                        stream.Close();
                        stream = null;
                    }
                    // close response
                    if (resp != null)
                    {
                        resp.Close();
                        resp = null;
                    }
                }
            }
        }
    }
}
