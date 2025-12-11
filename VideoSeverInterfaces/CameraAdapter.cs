using System;
using System.Xml;

namespace Interfaces
{
    public class CameraAdapter
    {
        public CameraAdapter()
        {

        }

        SourceFormater sourceFormater = null;
        internal SourceFormater SourceFormat
        {
            get
            {
                return sourceFormater;
            }
        }

        public event CameraEventHandler NewFrame;

        #region Camera configuration

        string cameraType;
        public string CameraType
        {
            get
            {
                return cameraType;
            }
        }

        string name = "";
        public string CameraName
        {
            get
            {
                return name;
            }

        }

        string description = "";
        public string CameraDescription
        {
            get
            {
                return description;
            }
        }

        bool moviDetect = false;
        public bool MoviDetect
        {
            get
            {
                return moviDetect;
            }

        }

        bool saveToFile = false;
        public bool SaveToFile
        {
            get
            {
                return saveToFile;
            }

        }

        string fileDirectoryPath = "D:\\";
        public string FileDirectoryPath
        {
            get
            {
                return fileDirectoryPath;
            }
        }

        string sourcePath = "";
        public string SourcePath
        {
            get
            {
                return sourcePath;
            }
        }

        string login = "";
        public string Login
        {
            get
            {
                return login;// iSourceAdaptee.Login;
            }

        }

        string password = "";
        public string Password
        {
            get
            {
                return password;// iSourceAdaptee.Password;
            }

        }

        string resolution = "";
        public string Resolution
        {
            get
            {
                return resolution;// iSourceAdaptee.Resolution;
            }
        }

        string quality = "";
        public string Quality
        {
            get
            {
                return quality;// iSourceAdaptee.Quality;
            }

        }

        string frameFrequncy = "";
        public string FrameFrequncy
        {
            get
            {
                return frameFrequncy;
            }
        }

        string connection = "";
        public string Connection
        {
            get
            {
                return connection;
            }

        }

        SourceTypes sourceType = SourceTypes.MJPEG;
        public SourceTypes SourceType
        {
            get
            {
                return sourceType;
            }
        }
        #endregion

        ISourceAdaptee iSourceAdaptee = null;
        public ISourceAdaptee ISourceAdaptee
        {
            set
            {
                iSourceAdaptee = value;
            }
            get
            {
                return iSourceAdaptee;
            }
        }

        public void SetConfiguration(XmlNode node)
        {
            if (iSourceAdaptee == null)
                throw new Exception("Тип камери не встановлено");

            if (node.SelectSingleNode("CameraName") != null)
                name = node.SelectSingleNode("CameraName").InnerText;

            if (node.SelectSingleNode("CameraDescription") != null)
                description = node.SelectSingleNode("CameraDescription").InnerText;

            if (node.SelectSingleNode("Url") != null)
                sourcePath = node.SelectSingleNode("Url").InnerText;

            if (node.SelectSingleNode("Login") != null)
                login = node.SelectSingleNode("Login").InnerText;

            if (node.SelectSingleNode("Password") != null)
                password = node.SelectSingleNode("Password").InnerText;

            if (node.SelectSingleNode("Resolution") != null)
                resolution = node.SelectSingleNode("Resolution").InnerText;

            if (node.SelectSingleNode("Quality") != null)
                quality = node.SelectSingleNode("Quality").InnerText;

            if (node.SelectSingleNode("FrameFrequncy") != null)
                frameFrequncy = node.SelectSingleNode("FrameFrequncy").InnerText;

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
                switch (str)
                {
                    case "JPEG":
                        {
                            sourceType = SourceTypes.JPEG;
                        }
                        break;
                    case "MJPEG":
                        {
                            sourceType = SourceTypes.MJPEG;
                        }
                        break;
                    case "LOCAL":
                        {
                            sourceType = SourceTypes.LOCAL;
                        }
                        break;
                    case "M3U8":
                        {
                            sourceType = SourceTypes.M3U8;
                        }
                        break;
                }
            }

            iSourceAdaptee.SetConfiguration(node);

            connection = iSourceAdaptee.UpdateSource();

        }

        public void Start()
        {

            connection = iSourceAdaptee.UpdateSource();

            switch (sourceType)
            {
                case SourceTypes.JPEG:
                    {
                        sourceFormater = new Jpeg();
                    }
                    break;
                case SourceTypes.MJPEG:
                    {
                        sourceFormater = new Mjpeg();
                    }
                    break;
                case SourceTypes.LOCAL:
                    {
                        sourceFormater = new LocalCaptureDevice();
                    }
                    break;
                case SourceTypes.M3U8:
                    {
                        sourceFormater = new CameraM3U8();
                    }
                    break;
            }

            if (sourceFormater != null)
            {
                sourceFormater.CameraAdapter = this;
                sourceFormater.NewFrame += new CameraEventHandler(sourceFormat_NewFrame);
                sourceFormater.Start();
            }

        }

        public void StartPreview()
        {
            connection = iSourceAdaptee.UpdateSource();
            login = iSourceAdaptee.Login;
            password = iSourceAdaptee.Password;
            quality = iSourceAdaptee.Quality;
            resolution = iSourceAdaptee.Resolution;
            saveToFile = iSourceAdaptee.SaveToFile;
            moviDetect = iSourceAdaptee.MoviDetect;
            fileDirectoryPath = iSourceAdaptee.FileDirectoryPath;
            frameFrequncy = iSourceAdaptee.FileDirectoryPath;
            cameraType = iSourceAdaptee.CameraType;
            name = iSourceAdaptee.CameraName;
            description = iSourceAdaptee.CameraDescription;
            sourceType = iSourceAdaptee.SourceType;
            sourcePath = iSourceAdaptee.SourcePath;

            switch (sourceType)
            {
                case SourceTypes.JPEG:
                    {
                        sourceFormater = new Jpeg();
                    }
                    break;
                case SourceTypes.MJPEG:
                    {
                        sourceFormater = new Mjpeg();
                    }
                    break;
                case SourceTypes.LOCAL:
                    {
                        sourceFormater = new LocalCaptureDevice();
                    }
                    break;
                case SourceTypes.M3U8:
                    {
                        sourceFormater = new CameraM3U8();
                    }
                    break;
            }

            if (sourceFormater != null)
            {
                sourceFormater.CameraAdapter = this;
                sourceFormater.NewFrame += new CameraEventHandler(sourceFormat_NewFrame);
                sourceFormater.Start();
            }

        }

        public void Stop()
        {

            if (sourceFormater != null)
            {
                sourceFormater.NewFrame -= new CameraEventHandler(sourceFormat_NewFrame);
                sourceFormater.Stop();
            }

        }

        void sourceFormat_NewFrame(object sender, CameraEventArgs e)
        {
            if (NewFrame != null)
            {
                NewFrame(sender, e);
            }
        }

    }
}
