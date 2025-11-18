using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using System.IO;
using System.Net;
using System.Reflection;
using System.Net.Configuration;
using System.Threading;
using System.Xml;
using System.Drawing;

namespace VideoServer.Tools
{
    public delegate void CameraEventHandler(object sender, Interfaces.CameraEventArgs e);

    
    /// <summary>
    /// 
    /// </summary>
    internal class ByteArrayUtils
    {
        // Check if the array contains needle on specified position
        public static bool Compare(byte[] array, byte[] needle, int startIndex)
        {
            int needleLen = needle.Length;
            // compare
            for (int i = 0, p = startIndex; i < needleLen; i++, p++)
            {
                if (array[p] != needle[i])
                {
                    return false;
                }
            }
            return true;
        }

        // Find subarray in array
        public static int Find(byte[] array, byte[] needle, int startIndex, int count)
        {
            int needleLen = needle.Length;
            int index;

            while (count >= needleLen)
            {
                index = Array.IndexOf(array, needle[0], startIndex, count - needleLen + 1);

                if (index == -1)
                    return -1;

                int i, p;
                // check for needle
                for (i = 0, p = index; i < needleLen; i++, p++)
                {
                    if (array[p] != needle[i])
                    {
                        break;
                    }
                }

                if (i == needleLen)
                {
                    // found needle
                    return index;
                }

                count -= (index - startIndex + 1);
                startIndex = index + 1;
            }
            return -1;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    internal class Camera
    {
        Interfaces.CameraAdapter adapter = null;
        public event CameraEventHandler NewFrame;

        public Camera()
        {
            adapter = new CameraAdapter();
            adapter.NewFrame += new Interfaces.CameraEventHandler(adapter_NewFrame);
        }

        void adapter_NewFrame(object sender, Interfaces.CameraEventArgs e)
        {
            if (NewFrame != null) 
            {
                NewFrame(sender, e);
            }
        }

        public void Start()
        {
            adapter.Start();
        }

        public void StartPreview() 
        {
            adapter.StartPreview();
        }
        public void Stop()
        {
            adapter.Stop();
        }

        public void SetConfiguration(XmlNode node) 
        {
            if (adapter == null)
                return;
            adapter.SetConfiguration(node);
        }
        
        Interfaces.ISourceAdaptee iSourceAdaptee = null;

        public Interfaces.ISourceAdaptee ISourceAdaptee
        {
            get
            {
                return iSourceAdaptee;
            }
            set
            {
                iSourceAdaptee = value;
                adapter.ISourceAdaptee = iSourceAdaptee;
            }
        }

    }
}
