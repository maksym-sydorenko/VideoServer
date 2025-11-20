using System;
using DirectShowLib;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Runtime.InteropServices;

namespace Interfaces
{
    class CameraRTSP : SourceFormater
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

            DirectShowLib.EventCode code;
            System.IntPtr param1, param2;

            while ((!failed) && (!stopEvent.WaitOne(0, true)))
            {
                try
                {
                    // Get type for filter graph
                    Type srvType = Type.GetTypeFromCLSID(typeof(FilterGraph).GUID);
                    if (srvType == null)
                        throw new ApplicationException("Failed creating filter graph");

                    // create filter graph
                    graphObj = Activator.CreateInstance(srvType);
                    graph = (IGraphBuilder)graphObj;

                    // Get type for windows media source filter
                    srvType = Type.GetTypeFromCLSID(new Guid("B98D13E7-55DB-4385-A33D-09FD1BA26338"));//?
                    if (srvType == null)
                        throw new ApplicationException("Failed creating WM source");

                    // create windows media source filter
                    sourceObj = Activator.CreateInstance(srvType);
                    sourceBase = (IBaseFilter)sourceObj;

                    // Get type for sample grabber
                    srvType = Type.GetTypeFromCLSID(typeof(SampleGrabber).GUID);
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
                    if (graph.Connect(GetOutPin(sourceBase, 0), GetInPin(grabberBase, 0)) < 0)
                        throw new ApplicationException("Failed connecting filters");

                    // get media type
                    if (sg.GetConnectedMediaType(mt) == 0)
                    {
                        VideoInfoHeader vih = (VideoInfoHeader)Marshal.PtrToStructure(mt.formatPtr, typeof(VideoInfoHeader));

                        grabber.Width = vih.BmiHeader.Width;
                        grabber.Height = vih.BmiHeader.Height;
                    }

                    // render
                    graph.Render(GetOutPin(grabberBase, 0));

                    //
                    sg.SetBufferSamples(false);
                    sg.SetOneShot(false);
                    sg.SetCallback(grabber, 1);

                    // window
                    IVideoWindow win = (IVideoWindow)graphObj;
                    win.put_AutoShow(OABool.False);
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
                            if (code == EventCode.Complete)
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

        private class Grabber : DirectShowLib.ISampleGrabberCB
        {
            private CameraRTSP parent;
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

            public Grabber(CameraRTSP parent)
            {
                this.parent = parent;
            }


            public int SampleCB(double SampleTime, IntPtr pSample)
            {
                return 0;
            }

            // Callback method that receives a pointer to the sample buffer
            public int BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen)
            {
                // створюємо Bitmap
                using (Bitmap img = new Bitmap(width, height, PixelFormat.Format24bppRgb))
                {
                    BitmapData bmData = img.LockBits(
                        new Rectangle(0, 0, width, height),
                        ImageLockMode.WriteOnly,
                        PixelFormat.Format24bppRgb);

                    int srcStride = width * 3;           // stride джерела (RGB24)
                    int dstStride = bmData.Stride;       // stride Bitmap

                    unsafe
                    {
                        byte* srcBase = (byte*)pBuffer.ToPointer();
                        byte* dstBase = (byte*)bmData.Scan0.ToPointer();

                        // копіюємо построково
                        for (int y = 0; y < height; y++)
                        {
                            byte* srcRow = srcBase + y * srcStride;
                            byte* dstRow = dstBase + y * dstStride;
                            Buffer.MemoryCopy(srcRow, dstRow, dstStride, srcStride);
                        }
                    }

                    img.UnlockBits(bmData);

                    // викликаємо подію
                    parent.OnNewFrame((Bitmap)img.Clone());
                }

                return 0;
            }

            public int SampleCB(double SampleTime, IMediaSample pSample)
            {
                IntPtr buffer;
                pSample.GetPointer(out buffer);
                int length = pSample.GetSize();
                return 0;
            }
        }

    }
}
