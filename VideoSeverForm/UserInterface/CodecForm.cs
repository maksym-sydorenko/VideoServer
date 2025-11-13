using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using dshow;
using dshow.Core;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections;

namespace VideoServer.UserInterface
{
    public partial class CodecForm : Form
    {
        FilterCollection filters;
        Hashtable tableVideo = null;
        Hashtable tableAudio = null;
        public CodecForm()
        {
            InitializeComponent();

            filters = new FilterCollection(FilterCategory.VideoCompressorCategory);
            tableVideo = new Hashtable();
            tableAudio = new Hashtable();
            if (filters.Count == 0)
            {
                lbxVideo.Items.Add("No Video Codec");
                lbxVideo.Enabled = false;
            }
            else
            {
                // add all devices to combo
                foreach (Filter filter in filters)
                {
                    if (filter.MonikerString[filter.MonikerString.Length-5] == '\\')
                    {
                        tableVideo.Add(filter.Name, filter.MonikerString.Substring(filter.MonikerString.Length - 4));
                        lbxVideo.Items.Add(filter.Name);
                    }
                }
            }
            filters = new FilterCollection(FilterCategory.AudioCompressorCategory);
            if (filters.Count == 0)
            {
                lbxAudio.Items.Add("No Audio Codec");
                lbxAudio.Enabled = false;
            }
            else
            {
                // add all devices to combo
                foreach (Filter filter in filters)
                {
                    if (filter.MonikerString[filter.MonikerString.Length - 5] == '\\')
                    {
                        tableAudio.Add(filter.Name, filter.MonikerString.Substring(filter.MonikerString.Length - 4));
                        lbxAudio.Items.Add(filter.Name);
                    }
                }
            }
        }

        private void btSelectVideo_Click(object sender, EventArgs e)
        {
            RegistryKey pKeyVideo = null;
            try
            {

                //reestr 
                pKeyVideo = Registry.CurrentUser.OpenSubKey("Software\\SMG\\Oko\\", true);
                if (pKeyVideo == null)
                {//created
                    RegistryKey pKey = Registry.CurrentUser.OpenSubKey("Software", true);
                    pKeyVideo = pKey.CreateSubKey("SMG\\Oko\\");
                    pKeyVideo.SetValue("VIDEO", tableVideo[lbxVideo.Text]);
                }
                else
                {//changed
                    if (pKeyVideo.GetValue("VIDEO") != null)
                        pKeyVideo.DeleteValue("VIDEO");
                    pKeyVideo.SetValue("VIDEO",tableVideo[lbxVideo.Text]);

                }
                pKeyVideo.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (pKeyVideo != null)
                    pKeyVideo.Close();
            }

       
        }

        private void btSelectAudio_Click(object sender, EventArgs e)
        {
            RegistryKey pKeyAudio = null;
            try
            {

                //reestr 
                pKeyAudio = Registry.CurrentUser.OpenSubKey("Software\\SMG\\Oko\\", true);
                if (pKeyAudio == null)
                {//created
                    RegistryKey pKey = Registry.CurrentUser.OpenSubKey("Software", true);
                    pKeyAudio = pKey.CreateSubKey("SMG\\Oko\\");
                    pKeyAudio.SetValue("AUDIO", tableAudio[lbxAudio.Text]);
                }
                else
                {//changed
                    if (pKeyAudio.GetValue("AUDIO") != null)
                        pKeyAudio.DeleteValue("AUDIO");
                    pKeyAudio.SetValue("AUDIO", tableAudio[lbxAudio.Text]);

                }
                pKeyAudio.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (pKeyAudio != null)
                    pKeyAudio.Close();
            }
        }

        private void CodecForm_Load(object sender, EventArgs e)
        {
            RegistryKey pKey = null;
            try
            {
                pKey = Registry.CurrentUser.OpenSubKey("Software\\SMG\\Oko\\", true);
                if (pKey == null)
                    return;

                if (pKey.GetValue("VIDEO") != null)
                {
                    int j = 0;
                    foreach (object i in tableVideo.Values)
                    {
                        if (pKey.GetValue("VIDEO").ToString() == i.ToString())
                        {
                            lbxVideo.SelectedIndex = j;
                            break;
                        }
                        else
                        {
                            j++;
                        }

                    }
                }

                if (pKey.GetValue("AUDIO") != null)
                {
                    int j = 0;
                    foreach (object i in tableAudio.Values)
                    {
                        if (pKey.GetValue("AUDIO").ToString() == i.ToString())
                        {
                            lbxAudio.SelectedIndex = j;
                            break;
                        }
                        else
                        {
                            j++;
                        }

                    }
                }
                pKey.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                if (pKey!=null)
                    pKey.Close();
            }
        }

       
    }
}
