using Interfaces;
using System;

namespace IPCamera
{
    class IPCamera : ISourceAdaptee
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
        string _login = "";
        string _password = "";
        string _sourcePath = "";
        string _IPCameraDescription = "";
        string _IPCameraName = "";
        bool _moviDetect = false;
        bool _saveToFile = false;
        string _fileDirectoryPath = "D:\\";
        SourceTypes _sourceType = SourceTypes.M3U8;

        public string CameraType
        {
            get
            {
                return "IP camera";
            }
        }

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
                return "";
            }
            set
            {
            }
        }

        public string Quality
        {
            get
            {
                return "";
            }
            set
            {
            }
        }

        public string Resolution
        {
            get
            {
                return "";
            }
            set
            {
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
                _sourcePath = value;
            }
        }

        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

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
            return _sourcePath;
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

            if (node.SelectSingleNode("SourceType") != null)
            {
                string str = node.SelectSingleNode("SourceType").InnerText;

                switch (str)
                {
                    case "JPEG":
                        {
                            _sourceType = SourceTypes.JPEG;
                        }
                        break;
                    case "MJPEG":
                        {
                            _sourceType = SourceTypes.MJPEG;
                        }
                        break;
                    case "M3U8":
                        {
                            _sourceType = SourceTypes.M3U8;
                        }
                        break;
                }
            }
        }

        #endregion
    }
}
