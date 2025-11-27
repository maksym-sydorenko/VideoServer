using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System;

namespace VideoServer.Controls
{
    internal partial class CameraViwer : Control
    {
        private bool autosize = false;
        private bool needSizeUpdate = false;
        private bool firstFrame = true;
        private Bitmap lastFrame = null;
        private readonly object frameLock = new object();

        private readonly Pen borderPen = new Pen(Color.Black, 1);
        private readonly Font drawFont = new Font("System", 12, FontStyle.Bold);
        private readonly Brush drawBrush = new SolidBrush(Color.Red);

        [DefaultValue(false)]
        public new bool AutoSize
        {
            get
            {
                return autosize;
            }
            set
            {
                autosize = value;
                needSizeUpdate = true;
                UpdatePosition();
            }
        }

        public CameraViwer()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer |
                ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing)
            {
                borderPen.Dispose();
                drawFont.Dispose();
                drawBrush.Dispose();
                lastFrame?.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (needSizeUpdate || firstFrame)
            {
                UpdatePosition();
                needSizeUpdate = false;
            }

            lock (frameLock)
            {
                Graphics g = pe.Graphics;
                Rectangle rc = this.ClientRectangle;

                g.DrawRectangle(borderPen, rc.X, rc.Y, rc.Width - 1, rc.Height - 1);

                if (lastFrame != null)
                {
                    g.DrawImage(lastFrame, rc.X + 1, rc.Y + 1, rc.Width - 2, rc.Height - 2);
                    g.DrawString(DateTime.Now.ToString(), drawFont, drawBrush, new PointF(5, rc.Height - 20));
                    firstFrame = false;
                }
                else
                {
                    g.DrawString("Підключення ...", drawFont, drawBrush, new PointF(5, 5));
                }
            }

            base.OnPaint(pe);
        }

        private void UpdatePosition()
        {
            lock (frameLock)
            {
                if (autosize)
                {
                    Rectangle rc = this.Parent.ClientRectangle;
                    int width = 320;
                    int height = 240;

                    if (lastFrame != null)
                    {
                        width = lastFrame.Width;
                        height = lastFrame.Height;
                    }

                    this.SuspendLayout();
                    this.Location = new Point((rc.Width - width - 2) / 2, (rc.Height - height - 2) / 2);
                    this.Size = new Size(width + 2, height + 2);
                    this.ResumeLayout();
                }
            }
        }

        unsafe void CopyBitmap(Bitmap src, Bitmap dst)
        {
            var rect = new Rectangle(0, 0, src.Width, src.Height);

            var sd = src.LockBits(rect, ImageLockMode.ReadOnly, src.PixelFormat);
            var dd = dst.LockBits(rect, ImageLockMode.WriteOnly, dst.PixelFormat);
            try
            {
                int bytesPerPixel = Image.GetPixelFormatSize(src.PixelFormat) / 8;
                for (int y = 0; y < src.Height; y++)
                {
                    byte* srow = (byte*)sd.Scan0 + y * sd.Stride;
                    byte* drow = (byte*)dd.Scan0 + y * dd.Stride;
                    Buffer.MemoryCopy(srow, drow, dd.Stride, src.Width * bytesPerPixel);
                }
            }
            finally
            {
                src.UnlockBits(sd);
                dst.UnlockBits(dd);
            }
        }

        public void camera_NewFrame(object sender, Interfaces.CameraEventArgs e)
        {
            lock (frameLock)
            {
                if (lastFrame == null ||
                    lastFrame.Width != e.Bitmap.Width ||
                    lastFrame.Height != e.Bitmap.Height ||
                    lastFrame.PixelFormat != e.Bitmap.PixelFormat)
                {
                    lastFrame?.Dispose();
                    lastFrame = new Bitmap(e.Bitmap.Width, e.Bitmap.Height, e.Bitmap.PixelFormat);
                }

                CopyBitmap(e.Bitmap, lastFrame);


            }

            Invalidate();
        }


    }
}
