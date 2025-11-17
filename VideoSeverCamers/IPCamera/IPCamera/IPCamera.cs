using Interfaces;
using System;

namespace IPCamera
{
    class IPCamera : Interfaces.ISourceAdaptee
    {
        SetupPage setupPage = null;
        public IPCamera()
        {
            setupPage = new SetupPage();
            setupPage.StateChanged += new EventHandler(setupPage_StateChanged);
        }

        void setupPage_StateChanged(object sender, EventArgs e)
        {
            setupPage.Update(this);
        }

        ~IPCamera()
        {
        }
        
        #region ISourceAdaptee Members
        string _frameFrequncy = "";
        string _quality = "Standard";
        string _login = "";
        string _password = "";
        string _resolution = "320x240";
        string _sourcePath = "";
        
        
        public string CameraType
        {
            get 
            {
                return "IP camera";
            }
        }
        
        string _IPCameraDescription = "";
        public string CameraDescription
        {
            get
            {
                return _IPCameraDescription;
            }
            set
            {
                _IPCameraDescription = value;
            }
        }

        string _IPCameraName = "";
        public string CameraName
        {
            get
            {
                return _IPCameraName;
            }
            set
            {
                _IPCameraName = value;
            }
        }

        bool _moviDetect = false;
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

        bool _saveToFile = false;
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
        string _fileDirectoryPath = "D:\\";
        public string FileDirectoryPath
        {
            get
            {
                return _fileDirectoryPath;
            }
            set
            {
                _fileDirectoryPath = value;
            }
        }

        public string FrameFrequncy
        {
            get
            {
                return _frameFrequncy;
            }
            set
            {
                _frameFrequncy = value;
            }
        }

        public string Quality
        {
            get
            {
                return _quality;
            }
            set
            {
                _quality = value;
            }
        }
        
        public string Resolution
        {
            get
            {
                return _resolution;
            }
            set
            {
                _resolution = value;
            }
        }
        
        public string SourcePath
        {
            get
            {
                return _sourcePath;
            }
            set
            {
                _sourcePath = value;;
            }
        }

        public string Login 
        {
            get { return _login; }
            set { _login = value; }
        }

        public string Password 
        {
            get { return _password; }
            set { _password = value; }
        }

        SourceTypes _sourceType = SourceTypes.MJPEG;
        public SourceTypes SourceType
        {
            get
            {
                return _sourceType;
            }
            set
            {
                _sourceType = value;
            }
        }

        public string UpdateSource()
        {

            if (_sourceType == SourceTypes.JPEG)
            {
                return "http://" + _sourcePath + "/image/jpeg.cgi";// +_resolution + "&Quality=" + _quality; ;
            }
            else if (_sourceType == SourceTypes.MJPEG)
            {
                return "http://" + _sourcePath + "/video/mjpg.cgi?profileid=" + _resolution; //+"&Quality=" + _quality; 
            }
            else if (_sourceType == SourceTypes.STREAM)
            {
               return "rtsp://" + _sourcePath + "/play" + _resolution + ".sdp"; //+"&Quality=" + _quality; 
              //return "rtsp://admin:123456@" + _sourcePath + "/play" + _resolution + ".sdp"; //+"&Quality=" + _quality; 
              //return "http:admin:123456@//" + _sourcePath + "/video/mjpg.cgi?profileid=" + _resolution;
            }
            return "http://" + _sourcePath + "/image/jpeg.cgi";// +_resolution + "&Quality=" + _quality; ;
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
                _IPCameraName = node.SelectSingleNode("CameraName").InnerText;

            if (node.SelectSingleNode("CameraDescription") != null)
                _IPCameraDescription = node.SelectSingleNode("CameraDescription").InnerText;

            if (node.SelectSingleNode("Url") != null)
                _sourcePath = node.SelectSingleNode("Url").InnerText;

            if (node.SelectSingleNode("Login") != null)
                _login = node.SelectSingleNode("Login").InnerText;

            if (node.SelectSingleNode("Password") != null)
                _password = node.SelectSingleNode("Password").InnerText;

            if (node.SelectSingleNode("SaveToFile") != null)
                _saveToFile = bool.Parse(node.SelectSingleNode("SaveToFile").InnerText);

            if (node.SelectSingleNode("MoviDetect") != null)
                _moviDetect = bool.Parse(node.SelectSingleNode("MoviDetect").InnerText);

            if (node.SelectSingleNode("FileDirectoryPath") != null)
                _fileDirectoryPath = node.SelectSingleNode("FileDirectoryPath").InnerText;

            if (node.SelectSingleNode("Resolution") != null)
                _resolution = node.SelectSingleNode("Resolution").InnerText;


            if (node.SelectSingleNode("SourceType") != null)
            {
                string str = node.SelectSingleNode("SourceType").InnerText;

                if (str == SourceTypes.LOCAL.ToString())
                {
                    _sourceType = SourceTypes.LOCAL;
                }
                else if (str == SourceTypes.MJPEG.ToString())
                {
                    _sourceType = SourceTypes.MJPEG;
                }
                else if (str == SourceTypes.JPEG.ToString())
                {
                    _sourceType = SourceTypes.JPEG;
                }
                else if (str == SourceTypes.STREAM.ToString())
                {
                    _sourceType = SourceTypes.STREAM;
                }

            }
        }

        #endregion
    }
}
