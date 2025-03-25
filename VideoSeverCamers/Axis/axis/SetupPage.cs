using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Interfaces;

namespace axis
{
    public partial class SetupPage : System.Windows.Forms.UserControl, Interfaces.ISetupPage
    {

        string frameFrequncy = "";
        string quality = "Standard";
        string login = "";
        string password = "";
        string resolution = "320x240";
        string sourcePath = "";
        SourceTypes sourceType = SourceTypes.MJPEG;
        XmlNode node = null;
        string filePath = "";
        axis.Axis2110Camera axisCamera;
        //PanosonicCamera panasonicCamera = null;

        public SetupPage()
        {
            
            InitializeComponent();
            cbTypeStream.SelectedIndex = 0;
            cbResolution.SelectedIndex = 1;
           
            cbPeriod.Visible = false;
            lbInterval.Visible = false;
        }
             
        private void btSelectPath_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) 
            {
               tbPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void cbTypeStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTypeStream.SelectedIndex != -1) 
            {
                if (cbTypeStream.SelectedIndex == 0) 
                {
                    
                    lbInterval.Visible = true;
                    cbPeriod.Visible = true;
                }
                else if (cbTypeStream.SelectedIndex == 1) 
                {
                    cbPeriod.Visible = false;
                    lbInterval.Visible = false;
                }
            }
           // Update(true);
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        #region ISetupPage Members
        public event EventHandler StateChanged;
        
        public void Display()
        {
            tbUrl.Focus();
            tbUrl.SelectionStart = tbUrl.TextLength;
        }
        public void GetConfiguration(ref XmlNode node)
        {
            this.node = node;
        }
        public void SetConfiguration(XmlNode node)
        {


        }
        #endregion

        internal void Update(ISourceAdaptee panasonicCamera) 
        {
            
            {
                panasonicCamera.Quality = "";
                panasonicCamera.Resolution = cbResolution.SelectedText;
                panasonicCamera.SourcePath = tbUrl.Text;
                panasonicCamera.Login = tbLogin.Text;
                panasonicCamera.Password = tbPassword.Text;

                sourcePath = tbPath.Text;
                if (cbTypeStream.SelectedIndex == 0)
                {
                    panasonicCamera.SourceType = SourceTypes.JPEG;
                    frameFrequncy = cbPeriod.SelectedText;
                }
                else
                {
                    panasonicCamera.SourceType = SourceTypes.MJPEG;
                }
            }
            
        }

        private void tbUrl_TextChanged(object sender, EventArgs e)
        {
            //Update(true);
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            //Update(true);
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void cbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void cbResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
     
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void cbQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void cbhSave_CheckedChanged(object sender, EventArgs e)
        {
            
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void cbhSaveMoving_CheckedChanged(object sender, EventArgs e)
        {
            
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void tbPath_TextChanged(object sender, EventArgs e)
        {
          
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

    }
}
