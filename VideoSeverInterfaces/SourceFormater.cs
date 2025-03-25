using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Reflection;
using System.Net.Configuration;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using Interfaces.avi;
using Microsoft.Win32;

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
        private MotionDetector2 motionDetecotor = null;
        protected avi.AVIWriter writer = null;
        // alarm level
        private double alarmLevel = 0.03;
        protected Thread thread = null;
        protected ManualResetEvent stopEvent = null;
        protected ManualResetEvent reloadEvent = null;
        protected Bitmap lastFrame = null;

        public SourceFormater()
        {

        }

        ~SourceFormater()
        {

        }
       
      

        protected CameraAdapter cameraAdapter = null;
        public CameraAdapter CameraAdapter
        {
            set
            {
                cameraAdapter = value;
            }
        }
        
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

        public abstract void Stop() ;
       
      
        public abstract void WorkerThread();

        #endregion

        protected bool MotionDetect(ref Bitmap lastFrame)
        {
            if (motionDetecotor == null)
            {
                motionDetecotor = new MotionDetector2();
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
                    
                    writer.Open(cameraAdapter.FileDirectoryPath+"\\"+fileName, lastFrame.Width, lastFrame.Height);
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

            // save the frame
            
           
            writer.AddFrame(lastFrame);
           
        }
        protected void SaveToFileJpeg(Bitmap lastFrame) 
        {
            try {
                DateTime date = DateTime.Now;
                String fileName = String.Format("{0}-{1}-{2} {3}-{4}-{5}.jpeg",
                    date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
                lastFrame.Save(cameraAdapter.FileDirectoryPath + "\\" + fileName, ImageFormat.Jpeg);
            }
            catch (Exception) { }
        }
        protected void CloseFile()
        {
            if (writer != null)
            {
                writer.Dispose();
                writer = null;
            }
        }

    }
}
