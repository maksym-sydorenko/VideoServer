using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using LibVLCSharp.Shared;

namespace Interfaces
{
    internal class CameraM3U8 : SourceFormater
    {

        private IntPtr videoBuffer;
        private uint width = 800;
        private uint height = 600;
        private uint pitch = 800 * 4;
        private int bufferSize = (int) (800 * 600 * 4);
        private byte[] managedBuffer = new byte[800 * 600 * 4];

        public override event CameraEventHandler NewFrame;

        public override void Start()
        {
            stopEvent = new ManualResetEvent(false);

            videoBuffer = Marshal.AllocHGlobal(bufferSize);

            thread = new Thread(new ThreadStart(WorkerThread));
            thread.Name = "HLS fMP4";
            thread.Start();
        }

        public override void Stop()
        {
            if (thread != null)
            {
                stopEvent.Set();
                thread.Join();
                thread = null;
            }
        }

        public override void WorkerThread()
        {
            try
            {
                Core.Initialize();
                using (var libVLC = new LibVLC())
                {
                    using (var mediaPlayer = new MediaPlayer(libVLC))
                    {
                        libVLC.Log += (sender, e) => Console.WriteLine($"[{e.Level}] {e.Module}:{e.Message}");

                        mediaPlayer.SetVideoFormat("RV32", width, height, pitch);
                        mediaPlayer.SetVideoCallbacks(OnLock, OnUnlock, OnDisplay);

                        string playlistUrl = cameraAdapter.SourcePath;
                        var media = new Media(libVLC, playlistUrl, FromType.FromLocation);
                        mediaPlayer.Play(media);

                        while (!stopEvent.WaitOne(100))
                        {
                            // health-check / reconnect
                        }

                        mediaPlayer.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Marshal.FreeHGlobal(videoBuffer);
            }
        }

        private void OnUnlock(IntPtr opaque, IntPtr picture, IntPtr planes)
        {
        }

        private IntPtr OnLock(IntPtr opaque, IntPtr planes)
        {
            Marshal.WriteIntPtr(planes, videoBuffer);
            return videoBuffer;
        }

        private void OnDisplay(IntPtr opaque, IntPtr picture)
        {
            Marshal.Copy(videoBuffer, managedBuffer, 0, bufferSize);

            var bmp = new Bitmap((int)width, (int)height, (int)pitch,
                PixelFormat.Format32bppRgb, videoBuffer);

            NewFrame?.Invoke(this, new CameraEventArgs((Bitmap)bmp.Clone()));

            bmp.Dispose();
        }
    }
}
