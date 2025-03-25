using System;
using Interfaces;
using Interfaces.dshow;
using Interfaces.dshow.Core;

namespace LocalCaptureDevice
{
    public class LocalCapture : Interfaces.ISourceAdaptee
    {
        SetupPage setupPage = null;
        public LocalCapture()
        {
            setupPage = new SetupPage();
            setupPage.StateChanged += new EventHandler(setupPage_StateChanged);
        }

        void setupPage_StateChanged(object sender, EventArgs e)
        {
            setupPage.Update(this);
        }

        ~LocalCapture()
        {
        }
        
        #region ISourceAdaptee Members
        
        string name = "";
        public string CameraName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        string description = "";
        public string CameraDescription
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
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

        public string CameraType
        {
            get 
            {
                return "Local Capture Device";
            }
        }

        string frameFrequncy = "";
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
            get { return ""; }
            set { throw new NotImplementedException(); }
        }
        
        public string Resolution
        {
            get { return ""; }
            set { throw new NotImplementedException(); }
        }

        string sourcePath = "";
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
            get { return"";}
            set { throw new NotImplementedException(); }
        }

        public string Password 
        {
            get { return ""; }
            set { throw new NotImplementedException();  }
        }

        SourceTypes sourceType = SourceTypes.LOCAL;
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

            if (sourceType == SourceTypes.LOCAL)
            {
                FilterCollection filters = new FilterCollection(FilterCategory.VideoInputDevice);
                foreach (Filter filter in filters) 
                {
                    if (filter.Name == sourcePath)
                        return filter.MonikerString;
                }
                
            }
            return "";
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
                name = node.SelectSingleNode("CameraName").InnerText;

            if (node.SelectSingleNode("CameraDescription") != null)
                description = node.SelectSingleNode("CameraDescription").InnerText;

            if (node.SelectSingleNode("Url") != null)
                sourcePath = node.SelectSingleNode("Url").InnerText;

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
                else if (str == SourceTypes.STREAM.ToString())
                {
                    sourceType = SourceTypes.STREAM; 
                }
                 
            }
        }

        #endregion
    }
}
