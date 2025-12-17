using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using DirectShowLib;
using LibVLCSharp.Shared;

namespace Interfaces
{
    internal class CameraM3U8 : SourceFormater
    {
        private static readonly LibVLC SharedLibVLC;
        private int _restart_time = 5000;
        private int try_cnt = 0;
        static CameraM3U8()
        {
            Core.Initialize();
            SharedLibVLC = new LibVLC();
#if DEBUG
            SharedLibVLC.Log += (sender, e) => Console.WriteLine($"[{e.Level}] {e.Module}:{e.Message}");
#endif
        }

        private IntPtr videoBuffer;
        private const uint width = 640;
        private const uint height = 480;
        private const uint pitch = width * 4;
        private int bufferSize = (int)(width * height * 4);

        public override event CameraEventHandler NewFrame;
        Bitmap safeCopy;
        Bitmap yoloCopy;

        public override void Start()
        {
            stopEvent = new ManualResetEvent(false);

            videoBuffer = Marshal.AllocHGlobal(bufferSize);

            safeCopy = new Bitmap((int)width, (int)height, (int)pitch,
                    PixelFormat.Format32bppRgb, videoBuffer);

            thread = new Thread(WorkerThread);
            thread.Name = String.Format("M3U8[{0}]", cameraAdapter.CameraName);
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
                using (MediaPlayer mediaPlayer = new MediaPlayer(SharedLibVLC))
                {

                    mediaPlayer.SetVideoFormat("RV32", width, height, pitch);
                    mediaPlayer.SetVideoCallbacks(OnLock, OnUnlock, OnDisplay);

                    string playlistUrl = cameraAdapter.SourcePath;
                    var media = new Media(SharedLibVLC, playlistUrl, FromType.FromLocation);
                    ////media.AddOption(":rate=0.1");
                    ////media.AddOption(":live-caching=300");
                    media.AddOption(":drop-late-frames");
                    if (!mediaPlayer.Play(media))
                    {
                        MessageBox.Show("Failed to start playback.");
                        stopEvent.Set();
                    }

                    mediaPlayer.EncounteredError += (sender, e) =>
                    {
                        MessageBox.Show("Failed to start playback.");
                        stopEvent.Set();
                    };

                    while (!stopEvent.WaitOne(_restart_time))
                    {
                        if (mediaPlayer.State == VLCState.Ended ||
                            mediaPlayer.State == VLCState.Error ||
                            !mediaPlayer.IsPlaying ||
                            try_cnt == 5)
                        {
                            RestartStream(mediaPlayer, playlistUrl);
                            try_cnt = 0;
                        }
                        try_cnt++;

                    }

                    mediaPlayer.Stop();
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
        private void RestartStream(MediaPlayer mediaPlayer, string playlistUrl)
        {
            try
            {
                Console.WriteLine("Restarting stream...");

                mediaPlayer.Stop();
                using (var media = new Media(SharedLibVLC, playlistUrl, FromType.FromLocation))
                {
                    //media.AddOption(":rate=0.1");
                    //media.AddOption(":live-caching=300");
                    media.AddOption(":drop-late-frames");
                    mediaPlayer.Play(media);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Restart failed: " + ex.Message);
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

        private void SafeCopy(ref Bitmap safeCopy)
        {
            BitmapData bmpData = safeCopy.LockBits(
               new Rectangle(0, 0, safeCopy.Width, safeCopy.Height),
               ImageLockMode.ReadOnly,
               safeCopy.PixelFormat);

            int bytesPerPixel = Image.GetPixelFormatSize(safeCopy.PixelFormat) / 8;
            int stride = bmpData.Stride;

            unsafe
            {
                byte* ptr = (byte*)bmpData.Scan0;

                for (int y = 0; y < safeCopy.Height; y++)
                {
                    for (int x = 0; x < safeCopy.Width; x++)
                    {
                        byte blue = ptr[0];
                        byte green = ptr[1];
                        byte red = ptr[2];
                        byte alpha = ptr[3];

                        ptr += bytesPerPixel;
                    }
                    ptr += stride - (safeCopy.Width * bytesPerPixel);
                }
            }

            safeCopy.UnlockBits(bmpData);
        }
        private Bitmap SafeCopy(Bitmap source)
        {
            Bitmap copy = new Bitmap(source.Width, source.Height, source.PixelFormat);

            BitmapData srcData = source.LockBits(
                new Rectangle(0, 0, source.Width, source.Height),
                ImageLockMode.ReadOnly,
                source.PixelFormat);

            BitmapData dstData = copy.LockBits(
                new Rectangle(0, 0, copy.Width, copy.Height),
                ImageLockMode.WriteOnly,
                copy.PixelFormat);

            int bytes = Math.Abs(srcData.Stride) * source.Height;

            unsafe
            {
                Buffer.MemoryCopy(
                    srcData.Scan0.ToPointer(),
                    dstData.Scan0.ToPointer(),
                    bytes,
                    bytes);
            }

            source.UnlockBits(srcData);
            copy.UnlockBits(dstData);

            return copy;
        }

        private void OnDisplay(IntPtr opaque, IntPtr picture)
        {
            try
            {
                try_cnt = 0;
                SafeCopy(ref safeCopy);

                if ((cameraAdapter.SaveToFile) && (!stopEvent.WaitOne(0, true)))
                {
                    if (cameraAdapter.UseYOLO)
                    {
                        yoloCopy = SafeCopy(safeCopy);
                        DetectObjects(yoloCopy);
                    }
                    else if (cameraAdapter.MoviDetect)
                    {
                        if (DetectMotion(ref safeCopy))
                        {
                            SaveToFileJpeg(safeCopy);
                        }
                    }
                    else
                    {
                        SaveToFileJpeg(safeCopy);
                    }
                }
                NewFrame?.Invoke(this, new CameraEventArgs(safeCopy));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
