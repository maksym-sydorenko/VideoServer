using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace DLink
{
    class DLink2102Camera : Interfaces.ISourceAdaptee
    {
        SetupPage setupPage = null;
        public DLink2102Camera()
        {
            setupPage = new SetupPage();
            setupPage.StateChanged += new EventHandler(setupPage_StateChanged);
        }

        void setupPage_StateChanged(object sender, EventArgs e)
        {
            setupPage.Update(this);
        }

        ~DLink2102Camera()
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
                return "D-Link DCS-2102 web camera";
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
                sourcePath = value;;
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

            if (sourceType == SourceTypes.JPEG)
            {
                return "http://" + sourcePath + "/image/jpeg.cgi";// +resolution + "&Quality=" + quality; ;
            }
            else if (sourceType == SourceTypes.MJPEG)
            {
                return "http://" + sourcePath + "/video/mjpg.cgi?profileid=" + resolution; //+"&Quality=" + quality; 
            }
            else if (sourceType == SourceTypes.STREAM)
            {
               return "rtsp://" + sourcePath + "/play" + resolution + ".sdp"; //+"&Quality=" + quality; 
              //return "rtsp://admin:123456@" + sourcePath + "/play" + resolution + ".sdp"; //+"&Quality=" + quality; 
              //return "http:admin:123456@//" + sourcePath + "/video/mjpg.cgi?profileid=" + resolution;
            }
            return "http://" + sourcePath + "/image/jpeg.cgi";// +resolution + "&Quality=" + quality; ;
        }
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

            if (node.SelectSingleNode("Resolution") != null)
                resolution = node.SelectSingleNode("Resolution").InnerText;


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
                else if (str == SourceTypes.STREAM.ToString())
                {
                    sourceType = SourceTypes.STREAM;
                }

            }
        }

        #endregion
    }
}
