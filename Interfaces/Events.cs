namespace Interfaces
{
    using System;

    /// <summary>
    /// camera event
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">CameraEventArgs</param>
    public delegate void CameraEventHandler(object sender, CameraEventArgs e);

    /// <summary>
    /// Camera event arguments
    /// </summary>
    public class CameraEventArgs : EventArgs
    {
        private System.Drawing.Bitmap bmp;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bmp">Bitmap</param>
        public CameraEventArgs(System.Drawing.Bitmap bmp)
        {
            this.bmp = bmp;
        }

        /// <summary>
        ///  Bitmap property
        /// </summary>
        public System.Drawing.Bitmap Bitmap
        {
            get { return bmp; }
        }
    }
}
