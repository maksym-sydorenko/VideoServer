using System;
using System.Reflection;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using Interfaces.avi;
using Microsoft.Win32;
using DirectShowLib;
using System.Runtime.InteropServices;
using System.IO;

namespace Interfaces
{
    abstract class SourceFormater
    {
        public abstract event CameraEventHandler NewFrame;
        protected const int bufSize = 512 * 1024;	// buffer size
        protected const int readSize = 1024;		// portion size to read
        protected int framesReceived;
        protected int bytesReceived;
        protected bool useSeparateConnectionGroup = true;
        protected object userData = null;
        private DetectorMotion motionDetecotor = null;
        private DetectorYOLO detectorYOLO = null;
        protected AVIWriter writer = null;
        // alarm level
        private double alarmLevel = 0.03;
        protected Thread thread = null;
        protected ManualResetEvent stopEvent = null;
        protected ManualResetEvent reloadEvent = null;
        protected Bitmap lastFrame = null;
        protected string subPath = DateTime.Now.ToString("yyyyMMdd");
        /// <summary>
        /// ctor
        /// </summary>
        public SourceFormater()
        {

        }

        /// <summary>
        /// ~ctor
        /// </summary>
        ~SourceFormater()
        {

        }

        protected CameraAdapter cameraAdapter = null;
        public CameraAdapter CameraAdapter
        {
            set
            {
                cameraAdapter = value;
                if (cameraAdapter.SaveToFile)
                {
                    subPath = Path.Combine(cameraAdapter.FileDirectoryPath, DateTime.Now.ToString("yyyyMMdd"));
                    if (!Directory.Exists(subPath))
                    {
                        Directory.CreateDirectory(subPath);
                    }
                }
            }
        }

        /// <summary>
        /// Set AllowUnsafeHeaderParsing20
        /// </summary>
        /// <returns></returns>
        protected static bool SetAllowUnsafeHeaderParsing20()
        {
            //Get the assembly that contains the internal class
            Assembly aNetAssembly = Assembly.GetAssembly(typeof(System.Net.Configuration.SettingsSection));
            if (aNetAssembly != null)
            {
                //Use the assembly in order to get the internal type for the internal class
                Type aSettingsType = aNetAssembly.GetType("System.Net.Configuration.SettingsSectionInternal");
                if (aSettingsType != null)
                {
                    //Use the internal static property to get an instance of the internal settings class.
                    //If the static instance isn't created allready the property will create it for us.
                    object anInstance = aSettingsType.InvokeMember("Section",
                      BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.NonPublic, null, null, new object[] { });

                    if (anInstance != null)
                    {
                        //Locate the private bool field that tells the framework is unsafe header parsing should be allowed or not
                        FieldInfo aUseUnsafeHeaderParsing = aSettingsType.GetField("use UnsafeHeaderParsing", BindingFlags.NonPublic | BindingFlags.Instance);
                        if (aUseUnsafeHeaderParsing != null)
                        {
                            aUseUnsafeHeaderParsing.SetValue(anInstance, true);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        #region Abstract
        public abstract void Start();

        public abstract void Stop();

        public abstract void WorkerThread();

        #endregion

        protected void DetectObjects(Bitmap lastFrame)
        {
            if (detectorYOLO == null)
            {
                detectorYOLO = new DetectorYOLO(cameraAdapter.ISourceAdaptee.CameraName);
            }
            DateTime date = DateTime.Now;
            String fileName = String.Format("{0}-{1}-{2} {3}-{4}-{5}.jpeg",
                    date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);

            detectorYOLO.DetectObjects( lastFrame,
                                        subPath,
                                        fileName,
                                        cameraAdapter.ISourceAdaptee.YoloTargets,
                                        cameraAdapter.ISourceAdaptee.YoloUrl);
        }

        protected bool DetectMotion(ref Bitmap lastFrame)
        {
            if (motionDetecotor == null)
            {
                motionDetecotor = new DetectorMotion();
                motionDetecotor.MotionLevelCalculation = true;
            }


            motionDetecotor.ProcessFrame(ref lastFrame);

            // check motion level
            if (motionDetecotor.MotionLevel >= alarmLevel)
            {
                return true;
            }

            return false;
        }

        protected void SaveToFile(Bitmap lastFrame)
        {
            if (writer == null)
            {
                // create file name
                DateTime date = DateTime.Now;
                String fileName = String.Format("{0}-{1}-{2} {3}-{4}-{5}.avi",
                    date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);

                try
                {
                    // create AVI writer
                    writer = new AVIWriter();
                    RegistryKey pKey = Registry.CurrentUser.OpenSubKey("Software\\SMG\\Oko\\", true);
                    if (pKey != null)
                    {
                        if (pKey.GetValue("VIDEO") != null)
                            writer.CodecVideo = pKey.GetValue("VIDEO").ToString();
                        if (pKey.GetValue("AUDIO") != null)
                            writer.CodecAudio = pKey.GetValue("AUDIO").ToString();
                        writer.Quality = 8500;
                    }
                    else
                    {
                        writer.CodecVideo = "";
                        writer.CodecAudio = "";
                    }
                    // open AVI file

                    writer.Open(subPath + "\\" + fileName, lastFrame.Width, lastFrame.Height);
                }
                catch (ApplicationException)
                {
                    if (writer != null)
                    {
                        writer.Dispose();
                        writer = null;
                    }
                }
            }

            writer.AddFrame(lastFrame);

        }

        protected void SaveToFileJpeg(Bitmap lastFrame)
        {
            try
            {
                DateTime date = DateTime.Now;
                String fileName = String.Format("{0}-{1}-{2} {3}-{4}-{5}.jpeg",
                    date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
                if (!File.Exists(fileName))
                {
                    lastFrame.Save(subPath + "\\" + fileName, ImageFormat.Jpeg);
                }
            }
            catch (Exception)
            {
            }
        }

        protected void CloseFile()
        {
            if (writer != null)
            {
                writer.Dispose();
                writer = null;
            }
        }

        public static IPin GetOutPin(IBaseFilter filter, int index)
        {
            IEnumPins enumPins;
            int hr = filter.EnumPins(out enumPins);
            DsError.ThrowExceptionForHR(hr);

            IPin[] pins = new IPin[1];
            IntPtr fetched = IntPtr.Zero;
            int i = 0;

            while (enumPins.Next(1, pins, fetched) == 0)
            {
                PinInfo pinInfo;
                pins[0].QueryPinInfo(out pinInfo);

                if (pinInfo.dir == PinDirection.Output)
                {
                    if (i == index)
                    {
                        return pins[0];
                    }
                    i++;
                }

                Marshal.ReleaseComObject(pins[0]);
            }

            return null;
        }

        public static IPin GetInPin(IBaseFilter filter, int index)
        {
            IEnumPins enumPins;
            int hr = filter.EnumPins(out enumPins);
            DsError.ThrowExceptionForHR(hr);

            IPin[] pins = new IPin[1];
            IntPtr fetched = IntPtr.Zero;
            int i = 0;

            while (enumPins.Next(1, pins, fetched) == 0)
            {
                PinInfo pinInfo;
                pins[0].QueryPinInfo(out pinInfo);

                if (pinInfo.dir == PinDirection.Input)
                {
                    if (i == index)
                    {
                        return pins[0];
                    }
                    i++;
                }

                Marshal.ReleaseComObject(pins[0]);
            }

            return null;
        }

    }
}
