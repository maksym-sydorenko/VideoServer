using System.Xml;

namespace Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISourceAdaptee
    {
        /// <summary>
        /// 
        /// </summary>
        string CameraType
        {
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        string CameraName
        {
            get;
            set;
        }
        string CameraDescription
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        bool SaveToFile 
        {
            get;
            set;
        }
        bool MoviDetect
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        string FileDirectoryPath 
        {
            get;
            set;
        }

        string Quality
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        string Resolution
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        string FrameFrequncy
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        string SourcePath
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        string Login
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        string Password
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        SourceTypes SourceType
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        ISetupPage ISetupPage
        {
            get;
        }


        /// <summary>
        /// Установка настроек
        /// </summary>
        /// <param name="node">нод настроек</param>
        void SetConfiguration(XmlNode node);
    
        string UpdateSource();
    }
}
