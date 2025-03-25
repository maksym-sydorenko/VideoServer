using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.dshow;
using Interfaces.dshow.Core;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;



namespace Interfaces
{
    class CameraStream : SourceFormater
    {

        public override event CameraEventHandler NewFrame;

        public override void Start()
        {
            // create events
            stopEvent = new ManualResetEvent(false);
            reloadEvent = new ManualResetEvent(false);
            thread = new Thread(new ThreadStart(WorkerThread));
            //thread.Name = DateTime.Now.ToString();// cameraAdapter.CameraName;


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
            bool failed = false;

            // grabber
            Grabber grabber = new Grabber(this);

            // objects
            object graphObj = null;
            object sourceObj = null;
            object grabberObj = null;

            // interfaces
            IGraphBuilder graph = null;
            IBaseFilter sourceBase = null;
            IBaseFilter grabberBase = null;
            ISampleGrabber sg = null;
            IFileSourceFilter fileSource = null;
            IMediaControl mc = null;
            IMediaEventEx mediaEvent = null;

            int code, param1, param2;

            while ((!failed) && (!stopEvent.WaitOne(0, true)))
            {
                try
                {
                    // Get type for filter graph
                    Type srvType = Type.GetTypeFromCLSID(Clsid.FilterGraph);
                    if (srvType == null)
                        throw new ApplicationException("Failed creating filter graph");

                    // create filter graph
                    graphObj = Activator.CreateInstance(srvType);
                    graph = (IGraphBuilder)graphObj;

                    // Get type for windows media source filter
                    srvType = Type.GetTypeFromCLSID(Clsid.RtspMediaSource);
                    if (srvType == null)
                        throw new ApplicationException("Failed creating WM source");

                    // create windows media source filter
                    sourceObj = Activator.CreateInstance(srvType);
                    sourceBase = (IBaseFilter)sourceObj;

                    // Get type for sample grabber
                    srvType = Type.GetTypeFromCLSID(Clsid.SampleGrabber);
                    if (srvType == null)
                        throw new ApplicationException("Failed creating sample grabber");

                    // create sample grabber
                    grabberObj = Activator.CreateInstance(srvType);
                    sg = (ISampleGrabber)grabberObj;
                    grabberBase = (IBaseFilter)grabberObj;

                    // add source filter to graph
                    graph.AddFilter(sourceBase, "source");
                    graph.AddFilter(grabberBase, "grabber");

                    // set media type
                    AMMediaType mt = new AMMediaType();
                    mt.majorType = MediaType.Video;
                    mt.subType = MediaSubType.RGB24;
                    sg.SetMediaType(mt);

                    // load file
                    fileSource = (IFileSourceFilter)sourceObj;
                    fileSource.Load(cameraAdapter.Connection, null);

                    // connect pins
                    if (graph.Connect(DSTools.GetOutPin(sourceBase, 0), DSTools.GetInPin(grabberBase, 0)) < 0)
                        throw new ApplicationException("Failed connecting filters");

                    // get media type
                    if (sg.GetConnectedMediaType(mt) == 0)
                    {
                        VideoInfoHeader vih = (VideoInfoHeader)Marshal.PtrToStructure(mt.formatPtr, typeof(VideoInfoHeader));

                        grabber.Width = vih.BmiHeader.Width;
                        grabber.Height = vih.BmiHeader.Height;
                        mt.Dispose();
                    }

                    // render
                    graph.Render(DSTools.GetOutPin(grabberBase, 0));

                    //
                    sg.SetBufferSamples(false);
                    sg.SetOneShot(false);
                    sg.SetCallback(grabber, 1);

                    // window
                    IVideoWindow win = (IVideoWindow)graphObj;
                    win.put_AutoShow(false);
                    win = null;

                    // get events interface
                    mediaEvent = (IMediaEventEx)graphObj;

                    // get media control
                    mc = (IMediaControl)graphObj;

                    // run
                    mc.Run();

                    while (!stopEvent.WaitOne(0, true))
                    {
                        Thread.Sleep(100);

                        // get an event
                        if (mediaEvent.GetEvent(out code, out param1, out param2, 0) == 0)
                        {
                            // release params
                            mediaEvent.FreeEventParams(code, param1, param2);

                            //
                            if (code == (int)EventCode.Complete)
                            {
                                break;
                            }
                        }
                    }

                    mc.StopWhenReady();
                }
                // catch any exceptions
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("----: " + e.Message);
                    failed = true;
                }
                // finalization block
                finally
                {
                    // release all objects
                    mediaEvent = null;
                    mc = null;
                    fileSource = null;
                    graph = null;
                    sourceBase = null;
                    grabberBase = null;
                    sg = null;

                    if (graphObj != null)
                    {
                        Marshal.ReleaseComObject(graphObj);
                        graphObj = null;
                    }
                    if (sourceObj != null)
                    {
                        Marshal.ReleaseComObject(sourceObj);
                        sourceObj = null;
                    }
                    if (grabberObj != null)
                    {
                        Marshal.ReleaseComObject(grabberObj);
                        grabberObj = null;
                    }
                }
            }
        }

        

        protected void OnNewFrame(Bitmap image)
        {
            framesReceived++;
            if (NewFrame != null)
                NewFrame(this, new CameraEventArgs(image));
        }

        // Grabber
        private class Grabber : ISampleGrabberCB
        {
            private CameraStream parent;
            private int width, height;

            // Width property
            public int Width
            {
                get { return width; }
                set { width = value; }
            }
            // Height property
            public int Height
            {
                get { return height; }
                set { height = value; }
            }

            // Constructor
            public Grabber(CameraStream parent)
            {
                this.parent = parent;
            }

            //
            public int SampleCB(double SampleTime, IntPtr pSample)
            {
                return 0;
            }

            // Callback method that receives a pointer to the sample buffer
            public int BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen)
            {
                // create new image
                System.Drawing.Bitmap img = new Bitmap(width, height, PixelFormat.Format24bppRgb);

                // lock bitmap data
                BitmapData bmData = img.LockBits(
                    new Rectangle(0, 0, width, height),
                    ImageLockMode.ReadWrite,
                    PixelFormat.Format24bppRgb);

                // copy image data
                int srcStride = bmData.Stride;
                int dstStride = bmData.Stride;

                int dst = bmData.Scan0.ToInt32() + dstStride * (height - 1);
                int src = pBuffer.ToInt32();

                for (int y = 0; y < height; y++)
                {
                    Win32.memcpy(dst, src, srcStride);
                    dst -= dstStride;
                    src += srcStride;
                }

                // unlock bitmap data
                img.UnlockBits(bmData);

                // notify parent
                parent.OnNewFrame(img);

                // release the image
                img.Dispose();

                return 0;
            }
        }

    }
}
