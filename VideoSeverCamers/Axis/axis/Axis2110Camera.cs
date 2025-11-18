using System;
using Interfaces;

namespace axis
{
    public class Axis2110Camera : Interfaces.ISourceAdaptee 
    {
        SetupPage setupPage = null;
        bool _saveToFile = false;
        bool _moviDetect = false;
        string _cameraName = "";
        string _fileDirectoryPath = "";
        SourceTypes sourceType = SourceTypes.MJPEG;

        public Axis2110Camera()
        {
            setupPage = new SetupPage();
            setupPage.StateChanged += new EventHandler(setupPage_StateChanged);
        }

        void setupPage_StateChanged(object sender, EventArgs e)
        {
            setupPage.Update(this);
        }

        #region ISourceAdaptee Members
        string frameFrequncy = "";
        string quality = "Standard";
        string login = "";
        string password = "";
        string resolution = "320x240";
        string sourcePath = "";
        string fullUrl = "";
        string _cameraDescription = "Axis camera";

        public string CameraDescription
        {
            get
            {
                return _cameraDescription;
            }
            set
            {
                _cameraDescription = value;
            }
        }

        public string CameraName
        {
            get
            {
               return _cameraName;
            }
            set
            {
                _cameraName = value;
            }
        }

        public bool MoviDetect
        {
            get
            {
               return _moviDetect;
            }
            set
            {
                _moviDetect = value;
            }
        }

        public bool SaveToFile
        {
            get
            {
                return _saveToFile;
            }
            set
            {
                _saveToFile = value;
            }
        }

        public string CameraType
        {
            get
            {
                return "Axis web camera";
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
            switch (sourceType)
            {
                case SourceTypes.MJPEG:
                    {
                        fullUrl = string.Format("http://{0}/axis-cgi/mjpg/video.cgi?resolution={1}", sourcePath, resolution);
                    }
                    break;
                default:
                    {
                        fullUrl = "";
                    }
                    break;
            }
            return fullUrl;
        }

        public ISetupPage ISetupPage
        {
            get
            {
                return (ISetupPage)setupPage;
            }

        }

        public string FullUrl
        {
            get
            {
                return fullUrl;
            }

        }
       


        public string FileDirectoryPath
        {
            get
            {
                return _fileDirectoryPath;
            }
            set
            {
                _fileDirectoryPath =  value;
            }
        }

        public void SetConfiguration(System.Xml.XmlNode node)
        {
            if (node.SelectSingleNode("CameraName") != null)
                _cameraName = node.SelectSingleNode("CameraName").InnerText;

            if (node.SelectSingleNode("CameraDescription") != null)
                _cameraDescription = node.SelectSingleNode("CameraDescription").InnerText;

            if (node.SelectSingleNode("Url") != null)
                sourcePath = node.SelectSingleNode("Url").InnerText;

            if (node.SelectSingleNode("Login") != null)
                login = node.SelectSingleNode("Login").InnerText;

            if (node.SelectSingleNode("Password") != null)
                password = node.SelectSingleNode("Password").InnerText;

            if (node.SelectSingleNode("SaveToFile") != null)
                _saveToFile = bool.Parse(node.SelectSingleNode("SaveToFile").InnerText);

            if (node.SelectSingleNode("MoviDetect") != null)
                _moviDetect = bool.Parse(node.SelectSingleNode("MoviDetect").InnerText);

            if (node.SelectSingleNode("FileDirectoryPath") != null)
                _fileDirectoryPath = node.SelectSingleNode("FileDirectoryPath").InnerText;

            if (node.SelectSingleNode("Resolution") != null)
                resolution = node.SelectSingleNode("Resolution").InnerText;

            sourceType = SourceTypes.MJPEG;
        }

        #endregion
    }
}
