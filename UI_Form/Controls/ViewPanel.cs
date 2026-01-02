using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VideoServer.Tools;

namespace VideoServer.Controls
{
    public partial class ViewPanel : System.Windows.Forms.Panel
    {
        private const int MaxRows = 5;
        private const int MaxCols = 5;
        private CameraViwer[,] camWindows;

        private bool fitToWindow = false;
        private bool singleCameraMode = true;
        private bool camerasVisible = false;

        private int rows = 1;
        private int cols = 1;
        private int cellWidth = 640;
        private int cellHeight = 480;

        private string[,] labels;
        private CameraViwer lastClicked;

        public ViewPanel()
        {
            InitializeComponent();
            labels = new string[rows, cols];

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer |
                        ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);

            // TODO: Add any initialization after the InitForm call
            camWindows = new CameraViwer[MaxRows, MaxCols];

            // row 1
            camWindows[0, 0] = cameraViwer1;
            camWindows[0, 1] = cameraViwer2;
            camWindows[0, 2] = cameraViwer3;
            camWindows[0, 3] = cameraViwer4;
            camWindows[0, 4] = cameraViwer5;
            // row 2
            camWindows[1, 0] = cameraViwer6;
            camWindows[1, 1] = cameraViwer7;
            camWindows[1, 2] = cameraViwer8;
            camWindows[1, 3] = cameraViwer9;
            camWindows[1, 4] = cameraViwer10;
            // row 3
            camWindows[2, 0] = cameraViwer11;
            camWindows[2, 1] = cameraViwer12;
            camWindows[2, 2] = cameraViwer13;
            camWindows[2, 3] = cameraViwer14;
            camWindows[2, 4] = cameraViwer15;
            // row 4
            camWindows[3, 0] = cameraViwer16;
            camWindows[3, 1] = cameraViwer17;
            camWindows[3, 2] = cameraViwer18;
            camWindows[3, 3] = cameraViwer19;
            camWindows[3, 4] = cameraViwer20;
            // row 5
            camWindows[4, 0] = cameraViwer21;
            camWindows[4, 1] = cameraViwer22;
            camWindows[4, 2] = cameraViwer23;
            camWindows[4, 3] = cameraViwer24;
            camWindows[4, 4] = cameraViwer25;
        }

        // FitToWindow property
        [DefaultValue(false)]
        public bool FitToWindow
        {
            get { return fitToWindow; }
            set
            {
                fitToWindow = value;

                if ((camWindows[0, 0].AutoSize = (!fitToWindow && singleCameraMode)) == true)
                {
                    //camWindows[0, 0].UpdatePosition();
                }
                else
                {
                    UpdateSize();
                }
            }
        }
        // SingleCameraMode property
        [DefaultValue(true)]
        public bool SingleCameraMode
        {
            get { return singleCameraMode; }
            set
            {
                singleCameraMode = value;
                if (!fitToWindow)
                    camWindows[0, 0].AutoSize = value;
            }
        }
        // CamerasVisible property
        [DefaultValue(false)]
        public bool CamerasVisible
        {
            get { return camerasVisible; }
            set
            {
                camerasVisible = value;

                // show/hide all cameras
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        camWindows[i, j].Visible = value;
                    }
                }
            }
        }
        // Rows property
        [DefaultValue(1)]
        public int Rows
        {
            get { return rows; }
            set
            {
                rows = Math.Max(1, Math.Min(MaxRows, value));
                UpdateVisiblity();
                UpdateSize();
            }
        }
        // Cols property
        [DefaultValue(1)]
        public int Cols
        {
            get { return cols; }
            set
            {
                cols = Math.Max(1, Math.Min(MaxCols, value));
                UpdateVisiblity();
                UpdateSize();
            }
        }
        // CellWidth
        [DefaultValue(320)]
        public int CellWidth
        {
            get { return cellWidth; }
            set
            {
                cellWidth = Math.Max(50, Math.Min(800, value));
                UpdateSize();
            }
        }
        // CellHeight
        [DefaultValue(240)]
        public int CellHeight
        {
            get { return cellHeight; }
            set
            {
                cellHeight = Math.Max(50, Math.Min(800, value));
                UpdateSize();
            }
        }
        // Context menu for cameras windows
        [DefaultValue(null)]
        public ContextMenu CamerasContextMenu
        {
            get { return camWindows[0, 0].ContextMenu; }
            set
            {
                for (int i = 0; i < MaxRows; i++)
                {
                    for (int j = 0; j < MaxCols; j++)
                    {
                        camWindows[i, j].ContextMenu = value;
                    }
                }
            }
        }
        //Camera of the last click
        [Browsable(false)]
        internal CameraViwer ContextCamera
        {
            get { return lastClicked; }
        }

        // Set _camera to the specified position of the multiplexer
        internal void SetCamera(int row, int col, Camera camera)
        {
            if ((row >= 0) && (col >= 0) && (row < MaxRows) && (col < MaxCols))
            {
                camWindows[row, col].Parent = this;
                camera.NewFrame += new CameraEventHandler(camWindows[row, col].camera_NewFrame);
            }
        }

        // Set multiplexer size
        public void SetSize(int rows, int cols, int cellWidth, int cellHeight)
        {
            this.rows = rows;
            this.cols = cols;
            this.cellWidth = cellWidth;
            this.cellHeight = cellHeight;
            UpdateSize();
        }

        // Update cameras visibility
        private void UpdateVisiblity()
        {
            if (camerasVisible)
            {
                for (int i = 0; i < MaxRows; i++)
                {
                    for (int j = 0; j < MaxCols; j++)
                    {
                        camWindows[i, j].Visible = ((i < rows) && (j < cols));
                    }
                }
            }
        }

        // Update cameras size and position
        private void UpdateSize()
        {
            int width, height;

            if (!fitToWindow)
            {
                // original width & height
                width = cellWidth;
                height = cellHeight;
            }
            else
            {
                // calculate width & height of cameras to fit the view to the window
                width = (ClientRectangle.Width / cols) - 4;
                height = (ClientRectangle.Height / rows) - 4;
            }

            // starting position of the view
            int startX = (ClientRectangle.Width - cols * (width + 4)) / 2;
            int startY = (ClientRectangle.Height - rows * (height + 4)) / 2;

            this.SuspendLayout();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    camWindows[i, j].Location = new Point(startX + (width + 4) * j + 1, startY + (height + 4) * i + 1);
                    camWindows[i, j].Size = new Size(width + 2, height + 2);
                }
            }

            this.ResumeLayout(false);
        }

        // On size changed
        private void Multiplexer_Resize(object sender, System.EventArgs e)
        {
            UpdateSize();
        }

        // On mouse down in _camera window

        private void cameraWindow_MouseDown(object sender, EventArgs e)
        {
            lastClicked = (CameraViwer)sender;
        }

    }
}
