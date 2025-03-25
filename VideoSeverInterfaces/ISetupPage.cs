using System;
using System.Xml;

namespace Interfaces
{
    /// <summary>
    /// ISetupPage
    /// </summary>
    public interface ISetupPage
    {
        /// <summary>
        /// event
        /// </summary>
        event EventHandler StateChanged;

        //void Update();

        /// <summary>
        /// Display
        /// </summary>
        void Display();

        /// <summary>
        ///GetConfiguration
        /// </summary>
        /// <param name="node">node</param>
        void GetConfiguration(ref XmlNode node);

        /// <summary>
        /// SetConfiguration
        /// </summary>
        /// <param name="node">node</param>
        void SetConfiguration(XmlNode node);
    }
}
