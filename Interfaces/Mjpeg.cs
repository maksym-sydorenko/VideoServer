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

        public override event CameraEventHandler NewFrame;

        public override void Start()
        {
            // create events
            stopEvent = new ManualResetEvent(false);
            reloadEvent = new ManualResetEvent(false);

            thread = new Thread(WorkerThread);
            thread.Name = String.Format("MJPG[{0}]", cameraAdapter.CameraName);
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
            //SetAllowUnsafeHeaderParsing20();
            while (!stopEvent.WaitOne(0, true))
            {
                // reset reload event
                reloadEvent.Reset();

                HttpWebRequest req = null;
                WebResponse resp = null;
                Stream stream = null;
                byte[] delimiter = null;
                byte[] delimiter2 = null;
                byte[] boundary = null;
                int boundaryLen, delimiterLen = 0, delimiter2Len = 0;
                int read, todo = 0, total = 0, pos = 0, align = 1;
                int start = 0, stop = 0;

                try
                {
                    req = (HttpWebRequest)WebRequest.Create(cameraAdapter.Connection);
                    Console.WriteLine(cameraAdapter.Connection);
                    if ((cameraAdapter.Login != null) && (cameraAdapter.Password != null) && (cameraAdapter.Login != ""))
                        req.Credentials = new NetworkCredential(cameraAdapter.Login, cameraAdapter.Password);

                    if (useSeparateConnectionGroup)
                        req.ConnectionGroupName = GetHashCode().ToString();
                    else
                        req.ConnectionGroupName = Guid.NewGuid().ToString();

                    req.Timeout = 10000;//10 sec
                    resp = req.GetResponse();

                    string ct = resp.ContentType;
                    if (ct.IndexOf("multipart/x-mixed-replace") == -1)
                        throw new ApplicationException("Invalid URL");

                    ASCIIEncoding encoding = new ASCIIEncoding();
                    boundary = encoding.GetBytes(ct.Substring(ct.IndexOf("boundary=", 0) + 9));
                    boundaryLen = boundary.Length;

                    stream = resp.GetResponseStream();

                    while ((!stopEvent.WaitOne(0, true)) && (!reloadEvent.WaitOne(0, true)))
                    {
                        // check total read
                        if (total > bufSize - readSize)
                        {
                            total = pos = todo = 0;
                        }

                        if ((read = stream.Read(buffer, total, readSize)) == 0)
                            throw new ApplicationException();

                        total += read;
                        todo += read;

                        bytesReceived += read;

                        if (delimiter == null)
                        {
                            pos = ByteArrayUtils.Find(buffer, boundary, pos, todo);

                            if (pos == -1)
                            {
                                todo = boundaryLen - 1;
                                pos = total - todo;
                                continue;
                            }

                            todo = total - pos;

                            if (todo < 2)
                                continue;

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

                        if (align == 1)
                        {
                            start = ByteArrayUtils.Find(buffer, delimiter, pos, todo);
                            if (start != -1)
                            {
                                start += delimiterLen;
                                pos = start;
                                todo = total - pos;
                                align = 2;
                            }
                            else
                            {
                                todo = delimiterLen - 1;
                                pos = total - todo;
                            }
                        }

                        while ((align == 2) && (todo >= boundaryLen))
                        {
                            stop = ByteArrayUtils.Find(buffer, boundary, pos, todo);
                            if (stop != -1)
                            {
                                pos = stop;
                                todo = total - pos;

                                framesReceived++;

                                if (NewFrame != null)
                                {
                                    using (var ms = new MemoryStream(buffer, start, stop - start))
                                    using (var bmp = (Bitmap)Bitmap.FromStream(ms))
                                    {
                                        this.lastFrame = bmp;

                                        using (Graphics g = Graphics.FromImage(bmp))
                                        using (Font drawFont = new Font("System", 12, FontStyle.Bold))
                                        using (SolidBrush drawBrush = new SolidBrush(Color.Black))
                                        {
                                            if (cameraAdapter.SaveToFile &&
                                                !stopEvent.WaitOne(0, true) &&
                                                !reloadEvent.WaitOne(0, true))
                                            {
                                                if (cameraAdapter.MoviDetect)
                                                {
                                                    if (DetectMotion(ref this.lastFrame))
                                                        SaveToFileJpeg(bmp);
                                                }
                                                else
                                                {
                                                    SaveToFileJpeg(bmp);
                                                }
                                            }

                                            g.DrawString(DateTime.Now.ToString(),
                                                         drawFont,
                                                         drawBrush,
                                                         new PointF(5, bmp.Height - 20));
                                        }

                                        if(NewFrame != null)
                                            NewFrame(this, new CameraEventArgs(bmp));
                                    }
                                }

                                pos = stop + boundaryLen;
                                todo = total - pos;
                                Array.Copy(buffer, pos, buffer, 0, todo);

                                total = todo;
                                pos = 0;
                                align = 1;
                            }
                            else
                            {
                                todo = boundaryLen - 1;
                                pos = total - todo;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
                }
                finally
                {
                    if (req != null)
                    {
                        req.Abort();
                        req = null;
                    }
                    if (stream != null)
                    {
                        stream.Close();
                        stream = null;
                    }
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
