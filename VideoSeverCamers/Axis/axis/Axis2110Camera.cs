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
        string _description = "Axis camera";
        public string CameraDescription
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
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
                //fullUrl = "http://" + sourcePath + "/SnapshotJPEG?Resolution=" + resolution + "&Quality=" + quality; ;
                fullUrl = "http://" + sourcePath + "/axis-cgi/mjpg/video.cgi?resolution=" + resolution;
            }
            else
            {
                fullUrl = "http://" + sourcePath + "/axis-cgi/jpg/image.cgi?resolution=" + resolution;
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
            throw new NotImplementedException();
        }

        #endregion
    }
}
