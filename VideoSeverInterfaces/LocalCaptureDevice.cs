using System;
using DirectShowLib;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Interfaces
{
    internal static class Ole32
    {
        [DllImport("ole32.dll")]
        public static extern int CreateBindCtx(int reserved, out IBindCtx ppbc);

        [DllImport("ole32.dll", CharSet = CharSet.Unicode)]
        public static extern int MkParseDisplayName(IBindCtx pbc, string szUserName, out int pchEaten, out IMoniker ppmk);
    }

    class LocalCaptureDevice : SourceFormater
    {
        public override event CameraEventHandler NewFrame;

        public override void Start()
        {
            if (thread == null)
            {
                framesReceived = 0;

                // create events
                stopEvent = new ManualResetEvent(false);

                // create and start new thread
                thread = new Thread(new ThreadStart(WorkerThread));
                thread.Name = cameraAdapter.Connection;
                thread.Start();
            }
        }

        public override void Stop()
        {
            Monitor.Enter(this);
            if (writer != null)
            {
                writer.Dispose();
                writer = null;
            }
            // stop thread
            if (thread != null)
            {
                // signal to stop
                stopEvent.Set();
            }
            Monitor.Exit(this);


        }

        public override void WorkerThread()
        {
            // grabber
            Grabber grabber = new Grabber(this);

            // objects
            object graphObj = null;
            object sourceObj = null;
            object grabberObj = null;

            // interfaces
            IGraphBuilder graph;
            IBaseFilter sourceBase;
            IBaseFilter grabberBase;
            ICaptureGraphBuilder2 captureGraph;
            IMediaControl mediaControl;
            ISampleGrabber sampleGrabber;
            try
            {
                Type srvType = Type.GetTypeFromCLSID(typeof(FilterGraph).GUID);
                if (srvType == null)
                    throw new ApplicationException("Failed creating filter graph");

                graphObj = Activator.CreateInstance(srvType);
                graph = (IGraphBuilder)graphObj;
                captureGraph = (ICaptureGraphBuilder2)new CaptureGraphBuilder2();
                captureGraph.SetFiltergraph(graph);

                IBindCtx bindCtx = null;
                IMoniker moniker = null;
                int n = 0;

                if (Ole32.CreateBindCtx(0, out bindCtx) == 0)
                {
                    if (Ole32.MkParseDisplayName(bindCtx, cameraAdapter.Connection, out n, out moniker) == 0)
                    {
                        Guid filterId = typeof(IBaseFilter).GUID;
                        moniker.BindToObject(null, null, ref filterId, out sourceObj);

                        Marshal.ReleaseComObject(moniker);
                        moniker = null;
                    }
                    Marshal.ReleaseComObject(bindCtx);
                    bindCtx = null;
                }

                if (sourceObj == null)
                    throw new ApplicationException("Failed creating device object for moniker");

                sourceBase = (IBaseFilter)sourceObj;

                srvType = Type.GetTypeFromCLSID(typeof(SampleGrabber).GUID);
                if (srvType == null)
                    throw new ApplicationException("Failed creating sample grabber");
                grabberObj = Activator.CreateInstance(srvType);

                sampleGrabber = (ISampleGrabber)grabberObj;
                AMMediaType mt = new AMMediaType
                {
                    majorType = MediaType.Video,
                    subType = MediaSubType.RGB24,
                    formatType = FormatType.VideoInfo
                };
                sampleGrabber.SetMediaType(mt);

                grabberBase = (IBaseFilter)grabberObj;

                graph.AddFilter(sourceBase, "source");
                graph.AddFilter(grabberBase, "grabber");

                captureGraph.RenderStream(PinCategory.Capture, MediaType.Video, sourceBase, grabberBase, null);

                if (sampleGrabber.GetConnectedMediaType(mt) == 0)
                {
                    VideoInfoHeader vih = (VideoInfoHeader)Marshal.PtrToStructure(mt.formatPtr, typeof(VideoInfoHeader));
                    grabber.Width = vih.BmiHeader.Width;
                    grabber.Height = vih.BmiHeader.Height;

                }

                // render
                graph.Render(GetOutPin(grabberBase, 0));

                sampleGrabber.SetBufferSamples(false);
                sampleGrabber.SetOneShot(false);
                sampleGrabber.SetCallback(grabber, 1);

                IVideoWindow win = (IVideoWindow)graphObj;
                win.put_AutoShow(OABool.False);
                win = null;


                // get media control
                mediaControl = (IMediaControl)graphObj;

                // run
                mediaControl.Run();

                while (!stopEvent.WaitOne(0, true))
                {
                    Thread.Sleep(100);
                }
                mediaControl.StopWhenReady();
            }
            // catch any exceptions
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("----: " + e.Message);
            }
            // finalization block
            finally
            {
                // release all objects
                mediaControl = null;
                graph = null;
                sourceBase = null;
                grabberBase = null;
                sampleGrabber = null;

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

        // new frame
        protected void OnNewFrame(Bitmap image)
        {
            framesReceived++;
            //if ((!stopEvent.WaitOne(0, true)) && (NewFrame != null))
            //    NewFrame(this, new CameraEventArgs(image));

            if (cameraAdapter.ISourceAdaptee.SaveToFile)
            {
                if (cameraAdapter.ISourceAdaptee.MoviDetect)
                {
                    if (MotionDetect(ref image))
                    {
                        //SaveToFile(image);
                    }
                    else
                    {
                        CloseFile();
                    }
                }
                else
                {
                    //SaveToFile(image);
                }

            }
            if ((!stopEvent.WaitOne(0, true)) && (NewFrame != null))
                NewFrame(this, new CameraEventArgs(image));
        }

        // Grabber
        private class Grabber : DirectShowLib.ISampleGrabberCB
        {
            private LocalCaptureDevice parent;
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
            public Grabber(LocalCaptureDevice parent)
            {
                this.parent = parent;
            }

            //
            public int SampleCB(double SampleTime, IntPtr pSample)
            {
                return 0;
            }

            public int BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen)
            {
                using (Bitmap img = new Bitmap(width, height, PixelFormat.Format24bppRgb))
                {
                    BitmapData bmData = img.LockBits(
                        new Rectangle(0, 0, width, height),
                        ImageLockMode.WriteOnly,
                        PixelFormat.Format24bppRgb);

                    int srcStride = width * 3;
                    int dstStride = bmData.Stride;

                    unsafe
                    {
                        byte* srcBase = (byte*)pBuffer.ToPointer();
                        byte* dstBase = (byte*)bmData.Scan0.ToPointer();

                        for (int y = 0; y < height; y++)
                        {
                            byte* srcRow = srcBase + y * srcStride;
                            byte* dstRow = dstBase + (height - y - 1) * dstStride;
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
