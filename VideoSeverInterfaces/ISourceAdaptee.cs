using System.Xml;

namespace Interfaces
{
    /// <summary>
    /// ISourceAdaptee
    /// </summary>
    public interface ISourceAdaptee
    {
        /// <summary>
        /// Camera Type
        /// </summary>
        string CameraType
        {
            get;
        }

        /// <summary>
        /// Camera Name
        /// </summary>
        string CameraName
        {
            get;
            set;
        }

        /// <summary>
        /// Camera Description
        /// </summary>
        string CameraDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Save To File
        /// </summary>
        bool SaveToFile
        {
            get;
            set;
        }

        /// <summary>
        /// MoviDetect
        /// </summary>
        bool MoviDetect
        {
            get;
            set;
        }

        /// <summary>
        /// File Directory Path
        /// </summary>
        string FileDirectoryPath
        {
            get;
            set;
        }

        /// <summary>
        /// Quality
        /// </summary>
        string Quality
        {
            get;
            set;
        }

        /// <summary>
        /// Resolution
        /// </summary>
        string Resolution
        {
            get;
            set;
        }
        /// <summary>
        /// Frame Frequncy
        /// </summary>
        string FrameFrequncy
        {
            get;
            set;
        }
        /// <summary>
        /// Source Path
        /// </summary>
        string SourcePath
        {
            get;
            set;
        }
        /// <summary>
        /// Login
        /// </summary>
        string Login
        {
            get;
            set;
        }
        /// <summary>
        /// Password
        /// </summary>
        string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Yolo Enabled
        /// </summary>
        bool YoloEnabled
        {
            get;
            set;
        }

        /// <summary>
        ///  Yolo Url
        /// </summary>
        string YoloUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Yolo Targets
        /// </summary>
        string[] YoloTargets
        {
            get;
            set;
        }


        /// <summary>
        /// Source Type
        /// </summary>
        SourceTypes SourceType
        {
            get;
            set;
        }

        /// <summary>
        /// ISetupPage
        /// </summary>
        ISetupPage ISetupPage
        {
            get;
        }


        /// <summary>
        /// SetConfiguration
        /// </summary>
        /// <param name="node">node</param>
        void SetConfiguration(XmlNode node);

        /// <summary>
        /// UpdateSource
        /// </summary>
        /// <returns>source string</returns>
        string UpdateSource();
    }
}
