using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace Interfaces
{
    /// <summary>
    /// MotionDetector4
    /// </summary>
    public class MotionDetector2
    {
        private IFilter grayscaleFilter = new GrayscaleBT709();
        private IFilter pixellateFilter = new Pixellate();
        private Difference differenceFilter = new Difference();
        private Threshold thresholdFilter = new Threshold(35);
        private MoveTowards moveTowardsFilter = new MoveTowards();

        private FiltersSequence processingFilter1 = new FiltersSequence();
        private BlobCounter blobCounter = new BlobCounter();

        private Bitmap backgroundFrame;
        private BitmapData bitmapData;
        private int counter = 0;

        private Bitmap[] numbersBitmaps = new Bitmap[9];

        private bool calculateMotionLevel = false;
        private int width;	// image width
        private int height;	// image height
        private int pixelsChanged;

        // Motion level calculation - calculate or not motion level
        public bool MotionLevelCalculation
        {
            get { return calculateMotionLevel; }
            set { calculateMotionLevel = value; }
        }

        // Motion level - amount of changes in percents
        public double MotionLevel
        {
            get { return (double)pixelsChanged / (width * height); }
        }

        // Constructor
        public MotionDetector2()
        {
            processingFilter1.Add(grayscaleFilter);
            processingFilter1.Add(pixellateFilter);

            // load numbers bitmaps
            Assembly assembly = this.GetType().Assembly;

            for (int i = 1; i <= 9; i++)
            {
                System.IO.Stream str = assembly.GetManifestResourceStream(
                    string.Format("Interfaces.Resources.{0}.gif", i));
                if (str != null)
                    numbersBitmaps[i - 1] = new Bitmap(str);
            }
        }

        // Reset detector to initial state
        public void Reset()
        {
            if (backgroundFrame != null)
            {
                backgroundFrame.Dispose();
                backgroundFrame = null;
            }
            counter = 0;
        }

        // Process new frame
        public void ProcessFrame(ref Bitmap image)
        {
            if (backgroundFrame == null)
            {
                // create initial backgroung image
                backgroundFrame = processingFilter1.Apply(image);

                // get image dimension
                width = image.Width;
                height = image.Height;

                // just return for the first time
                return;
            }

            Bitmap tmpImage;

            // apply the the first filters sequence
            tmpImage = processingFilter1.Apply(image);

            if (++counter == 2)
            {
                counter = 0;

                // move background towards current frame
                moveTowardsFilter.OverlayImage = tmpImage;
                moveTowardsFilter.ApplyInPlace(backgroundFrame);
            }

            // set backgroud frame as an overlay for difference filter
            differenceFilter.OverlayImage = backgroundFrame;

            // lock temporary image to apply several filters
            bitmapData = tmpImage.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

            // apply difference filter
            differenceFilter.ApplyInPlace(bitmapData);
            // apply threshold filter
            thresholdFilter.ApplyInPlace(bitmapData);

            // get object rectangles
            blobCounter.ProcessImage(bitmapData);
            Rectangle[] rects = blobCounter.GetObjectRectangles();

            // unlock temporary image
            tmpImage.UnlockBits(bitmapData);
            tmpImage.Dispose();

            pixelsChanged = 0;

            if (rects.Length != 0)
            {
                // create graphics object from initial image
                Graphics g = Graphics.FromImage(image);

                using (Pen pen = new Pen(Color.Red, 1))
                {
                    int n = 0;

                    // draw each rectangle
                    foreach (Rectangle rc in rects)
                    {
                        if ((rc.Width > 15) && (rc.Height > 15))
                            g.DrawRectangle(pen, rc);

                        if ((n < 10) && (rc.Width > 15) && (rc.Height > 15))
                        {
                            g.DrawImage(numbersBitmaps[n], rc.Left, rc.Top, 7, 9);
                            n++;
                        }

                        // a little bit inaccurate, but fast
                        if (calculateMotionLevel)
                            pixelsChanged += rc.Width * rc.Height;
                    }
                }
                g.Dispose();
            }
        }
    }


}
