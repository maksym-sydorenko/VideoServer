using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Drawing;

namespace Interfaces
{
    class Jpeg : SourceFormater
    {
        public override event CameraEventHandler NewFrame;
        private bool preventCaching = false;
        private int frameInterval = 0;	

        public override void Start()
        {
            stopEvent = new ManualResetEvent(false);
            reloadEvent = new ManualResetEvent(false);
            thread = new Thread(new ThreadStart(WorkerThread));
            //thread.Name = cameraAdapter.SourcePath;
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
            HttpWebRequest req = null;
            WebResponse resp = null;
            Stream stream = null;
            Random rnd = new Random((int)DateTime.Now.Ticks);
            DateTime start;
            TimeSpan span;
            SetAllowUnsafeHeaderParsing20();
            while (!stopEvent.WaitOne(0, true))
            {
                int read, total = 0;

                try
                {
                    start = DateTime.Now;
                    string source = cameraAdapter.Connection;
                    // create request
                    if (!preventCaching)
                    {
                        req = (HttpWebRequest)WebRequest.Create(source);
                    }
                    else
                    {
                        
                        req = (HttpWebRequest)WebRequest.Create(source + ((source.IndexOf('?') == -1) ? '?' : '&') + "fake=" + rnd.Next().ToString());
                    }
                    // set login and password
                    if ((cameraAdapter.Login != null) && (cameraAdapter.Password != null) && (cameraAdapter.Login != ""))
                        req.Credentials = new NetworkCredential(cameraAdapter.Login, cameraAdapter.Password);
                    // set connection group name
                    if (useSeparateConnectionGroup)
                        req.ConnectionGroupName = GetHashCode().ToString();
                    //req.Proxy = null;// WebRequest.DefaultWebProxy;
                    // get response
                    req.Timeout = 10000;
                    resp = req.GetResponse();

                    // get response stream
                    stream = resp.GetResponseStream();
                    string fInterval = cameraAdapter.FrameFrequncy;

                    // loop
                    while (!stopEvent.WaitOne(0, true))
                    {
                        // check total read
                        if (total > bufSize - readSize)
                        {
                            total = 0;
                        }

                        // read next portion from stream
                        if ((read = stream.Read(buffer, total, readSize)) == 0)
                            break;

                        total += read;

                        // increment received bytes counter
                        bytesReceived += read;
                    }

                    if (!stopEvent.WaitOne(0, true))
                    {
                        // increment frames counter
                        framesReceived++;

                        // image at stop
                        if (NewFrame != null)
                        {
                            Bitmap bmp = (Bitmap)Bitmap.FromStream(new MemoryStream(buffer, 0, total));
                            // notify client
                            NewFrame(this, new CameraEventArgs(bmp));
                            if (cameraAdapter.SaveToFile)
                                SaveToFileJpeg(bmp);
                            // release the image
                            bmp.Dispose();
                            bmp = null;
                        }
                    }

                    // wait for a while ?
                    if (fInterval !="")
                    {
                        // times span
                        span = DateTime.Now.Subtract(start);
                        // miliseconds to sleep

                        frameInterval = int.Parse(fInterval.Substring(0, (fInterval.Length - 2)));
                        int msec = frameInterval - (int)span.TotalMilliseconds;

                        while ((msec > 0) && (stopEvent.WaitOne(0, true) == false))
                        {
                            // sleeping ...
                            Thread.Sleep((msec < 100) ? msec : 100);
                            msec -= 100;
                        }
                    }
                }
                catch (WebException ex)
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

                // need to stop ?
                if (stopEvent.WaitOne(0, true))
                    break;
            }
        }
    }
}
