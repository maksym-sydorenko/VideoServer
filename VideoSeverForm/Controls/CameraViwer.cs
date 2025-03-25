using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace VideoServer.Controls
{
    internal partial class CameraViwer : System.Windows.Forms.Control
    {

        private bool autosize = false;
        private bool needSizeUpdate = false;
        private bool firstFrame = true;
        Bitmap lastFrame = null;


        // AutoSize property
        [DefaultValue(false)]
        public new bool AutoSize
        {
            get { return autosize; }
            set
            {
                autosize = value;
                needSizeUpdate = true;
                UpdatePosition();
            }
        }

        // Constructor
        public CameraViwer()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer |
                ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }

        // Paint control
        protected override void OnPaint(PaintEventArgs pe)
        {
            if ((needSizeUpdate) || (firstFrame))
            {
                UpdatePosition();
                needSizeUpdate = false;
            }

            // lock
            Monitor.Enter(this);

            Graphics g = pe.Graphics;
            Rectangle rc = this.ClientRectangle;
            Pen pen = new Pen(Color.Black, 1);

            // draw rectangle
            g.DrawRectangle(pen, rc.X, rc.Y, rc.Width - 1, rc.Height - 1);

            Font drawFont = new Font("System", 12, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Red);

            if (lastFrame != null)
            {
                g.DrawImage(lastFrame, rc.X + 1, rc.Y + 1, rc.Width - 2, rc.Height - 2);
                //g.DrawString(DateTime.Now.ToString(), drawFont, drawBrush, new PointF(5, rc.Height - 20));
                firstFrame = false;
            }
            else
            {
                g.DrawString("Підключення ...", drawFont, drawBrush, new PointF(5, 5));
            }
            drawBrush.Dispose();
            drawFont.Dispose();
            pen.Dispose();

            // unlock
            Monitor.Exit(this);

            base.OnPaint(pe);
        }

        // update position and size of the control
        private void UpdatePosition()
        {
            // lock
            Monitor.Enter(this);

            if (autosize)
            {
                Rectangle rc = this.Parent.ClientRectangle;
                int width = 320;
                int height = 240;


                // get frame dimension
                if (lastFrame != null)
                {
                    width = lastFrame.Width;
                    height = lastFrame.Height;
                }


                //
                this.SuspendLayout();
                this.Location = new Point((rc.Width - width - 2) / 2, (rc.Height - height - 2) / 2);
                this.Size = new Size(width + 2, height + 2);
                this.ResumeLayout();

            }
            // unlock
            Monitor.Exit(this);
        }

        // On new frame ready
        public void camera_NewFrame(object sender, Interfaces.CameraEventArgs e)
        {
            lastFrame = new Bitmap(e.Bitmap);
            Invalidate();
        }
    }

}
