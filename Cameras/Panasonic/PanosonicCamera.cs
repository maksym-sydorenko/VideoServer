using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
namespace Panasonic
{
    public class PanosonicCamera : ISourceAdaptee
    {


        SetupPage setupPage = null;
        public PanosonicCamera()
        {
            setupPage = new SetupPage();
            setupPage.StateChanged += new EventHandler(setupPage_StateChanged);
        }

        void setupPage_StateChanged(object sender, EventArgs e)
        {
            setupPage.Update(this);
        }

        ~PanosonicCamera()
        {
        }

        #region ISourceAdaptee Members
        string frameFrequncy = "";
        string quality = "Standard";
        string login = "";
        string password = "";
        string resolution = "320x240";
        string sourcePath = "";


        public string CameraType
        {
            get
            {
                return "Panasonic web camera";
            }
        }

        string cameraDescription = "";
        public string CameraDescription
        {
            get
            {
                return cameraDescription;
            }
            set
            {
                cameraDescription = value;
            }
        }

        string cameraName = "";
        public string CameraName
        {
            get
            {
                return cameraName;
            }
            set
            {
                cameraName = value;
            }
        }

        bool moviDetect = false;
        public bool MoviDetect
        {
            get
            {
                return moviDetect;
            }
            set
            {
                moviDetect = value;
            }
        }

        bool saveToFile = false;
        public bool SaveToFile
        {
            get
            {
                return saveToFile;
            }
            set
            {
                saveToFile = value;
            }
        }
        string fileDirectoryPath = "D:\\";
        public string FileDirectoryPath
        {
            get
            {
                return fileDirectoryPath;
            }
            set
            {
                fileDirectoryPath = value;
            }
        }

        public string FrameFrequncy
        {
            get
            {
                return frameFrequncy;
            }
            set
            {
                frameFrequncy = value;
            }
        }

        public string Quality
        {
            get
            {
                return quality;
            }
            set
            {
                quality = value;
            }
        }

        public string Resolution
        {
            get
            {
                return resolution;
            }
            set
            {
                resolution = value;
            }
        }

        public string SourcePath
        {
            get
            {
                return sourcePath;
            }
            set
            {
                sourcePath = value; ;
            }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        SourceTypes sourceType = SourceTypes.MJPEG;
        public SourceTypes SourceType
        {
            get
            {
                return sourceType;
            }
            set
            {
                sourceType = value;
            }
        }

        public string UpdateSource()
        {

            if (sourceType != SourceTypes.MJPEG)
            {
                return "http://" + sourcePath + "/SnapshotJPEG?Resolution=" + resolution + "&Quality=" + quality; ;
            }
            else
            {
                return "http://" + sourcePath + "/nphMotionJpeg?Resolution=" + resolution + "&Quality=" + quality;
            }

        }

        public bool YoloEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string YoloUrl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string[] YoloTargets { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ISetupPage ISetupPage
        {
            get
            {
                return (ISetupPage)setupPage;
            }

        }

        public void SetConfiguration(System.Xml.XmlNode node)
        {
            if (node.SelectSingleNode("CameraName") != null)
                cameraName = node.SelectSingleNode("CameraName").InnerText;

            if (node.SelectSingleNode("CameraDescription") != null)
                cameraDescription = node.SelectSingleNode("CameraDescription").InnerText;

            if (node.SelectSingleNode("Url") != null)
                sourcePath = node.SelectSingleNode("Url").InnerText;

            if (node.SelectSingleNode("Login") != null)
                login = node.SelectSingleNode("Login").InnerText;

            if (node.SelectSingleNode("Password") != null)
                password = node.SelectSingleNode("Password").InnerText;

            if (node.SelectSingleNode("SaveToFile") != null)
                saveToFile = bool.Parse(node.SelectSingleNode("SaveToFile").InnerText);

            if (node.SelectSingleNode("MoviDetect") != null)
                moviDetect = bool.Parse(node.SelectSingleNode("MoviDetect").InnerText);

            if (node.SelectSingleNode("FileDirectoryPath") != null)
                fileDirectoryPath = node.SelectSingleNode("FileDirectoryPath").InnerText;


            if (node.SelectSingleNode("SourceType") != null)
            {
                string str = node.SelectSingleNode("SourceType").InnerText;

                if (str == SourceTypes.LOCAL.ToString())
                {
                    sourceType = SourceTypes.LOCAL;
                }
                else if (str == SourceTypes.MJPEG.ToString())
                {
                    sourceType = SourceTypes.MJPEG;
                }
                else if (str == SourceTypes.JPEG.ToString())
                {
                    sourceType = SourceTypes.JPEG;
                }
                else if (str == SourceTypes.M3U8.ToString())
                {
                    sourceType = SourceTypes.M3U8;
                }

            }
        }

        #endregion
    }
}
