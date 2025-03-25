using System;
using System.Windows.Forms;
using System.Xml;
using Interfaces;

namespace DLink
{
    public partial class SetupPage : System.Windows.Forms.UserControl, Interfaces.ISetupPage
    {
        string frameFrequncy = "";

        string sourcePath = "";
        XmlNode node = null;

        public SetupPage()
        {
            InitializeComponent();
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
            this.node.InnerXml = "<CameraName>" + tbName.Text + "</CameraName>" +
               "<CameraType>D-Link DCS-2102 web camera</CameraType>" +
               "<CameraDescription>" + " " + "</CameraDescription>" +
               "<SaveToFile>" + cbhSave.Checked + "</SaveToFile>" +
               "<MoviDetect>" + cbhSaveMoving.Checked + "</MoviDetect>" +
               "<FileDirectoryPath>" + tbPath.Text + "</FileDirectoryPath>" +
               "<Url>" + tbUrl.Text + "</Url>" +
               "<Login>" + tbLogin.Text + "</Login>" +
               "<Password>" + tbPassword.Text + "</Password>" +
               "<SourceType>" + cbTypeStream.Text + "</SourceType>" +
               "<Resolution>" + cbProfile.Text + "</Resolution>" +
               "<FrameFrequncy>" + cbPeriod.Text + "</FrameFrequncy>";


        }

        public void SetConfiguration(XmlNode node)
        {
           
            if (node.SelectSingleNode("CameraName") != null)
                tbName.Text = node.SelectSingleNode("CameraName").InnerText;

            //if (node.SelectSingleNode("CameraDescription") != null)
            //    description = node.SelectSingleNode("CameraDescription").InnerText;

            if (node.SelectSingleNode("Url") != null)
                tbUrl.Text = node.SelectSingleNode("Url").InnerText;

            if (node.SelectSingleNode("Login") != null)
                tbLogin.Text = node.SelectSingleNode("Login").InnerText;

            if (node.SelectSingleNode("Password") != null)
                tbPassword.Text = node.SelectSingleNode("Password").InnerText;

            if (node.SelectSingleNode("Resolution") != null)
                cbProfile.SelectedItem = node.SelectSingleNode("Resolution").InnerText;

            //if (node.SelectSingleNode("Quality") != null)
            //    quality = node.SelectSingleNode("Quality").InnerText;

            if (node.SelectSingleNode("SaveToFile") != null)
                cbhSave.Checked = bool.Parse(node.SelectSingleNode("SaveToFile").InnerText);

            if (node.SelectSingleNode("MoviDetect") != null)
                cbhSaveMoving.Checked = bool.Parse(node.SelectSingleNode("MoviDetect").InnerText);

            if (node.SelectSingleNode("FileDirectoryPath") != null)
                tbPath.Text = node.SelectSingleNode("FileDirectoryPath").InnerText;

            if (node.SelectSingleNode("FrameFrequncy") != null)
                cbPeriod.SelectedItem = node.SelectSingleNode("FrameFrequncy").InnerText;

            if (node.SelectSingleNode("SourceType") != null)
            {
                string str = node.SelectSingleNode("SourceType").InnerText;

                if (str == SourceTypes.MJPEG.ToString())
                {
                    cbTypeStream.SelectedItem = SourceTypes.MJPEG;
                }
                else if (str == SourceTypes.JPEG.ToString())
                {
                    cbTypeStream.SelectedItem = SourceTypes.JPEG;
                }
                else if (str == SourceTypes.STREAM.ToString())
                {
                    cbTypeStream.SelectedItem = SourceTypes.STREAM;
                }
                else 
                {
                    cbTypeStream.SelectedItem = SourceTypes.JPEG;
                }

            }

            
        }
        #endregion

        internal void Update(ISourceAdaptee dlinkCamera)
        {

            {
                dlinkCamera.CameraName = tbName.Text;
                dlinkCamera.Resolution = cbProfile.Text;
                dlinkCamera.SourcePath = tbUrl.Text;
                dlinkCamera.Login = tbLogin.Text;
                dlinkCamera.Password = tbPassword.Text;
                dlinkCamera.SaveToFile = cbhSave.Checked;
                dlinkCamera.MoviDetect = cbhSaveMoving.Checked;
                dlinkCamera.FileDirectoryPath = tbPath.Text;
                dlinkCamera.FrameFrequncy = cbPeriod.Text;
                dlinkCamera.CameraDescription = "";
                //panasonicCamera.CameraType

                sourcePath = tbPath.Text;
                if (cbTypeStream.SelectedIndex == 0)
                {
                    dlinkCamera.SourceType = SourceTypes.JPEG;
                    frameFrequncy = cbPeriod.SelectedText;
                }
                else
                {
                    dlinkCamera.SourceType = SourceTypes.MJPEG;
                }
            }

        }

        #region Controls
        private void btSelectPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void tbPath_TextChanged(object sender, EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void cbhSaveMoving_CheckedChanged(object sender, EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void cbhSave_CheckedChanged(object sender, EventArgs e)
        {

            if (cbhSave.Checked)
            {
                tbPath.Enabled = true;
                cbhSaveMoving.Enabled = true;
                btSelectPath.Enabled = true;
                lbFilePath.Enabled = true;
            }
            else
            {
                tbPath.Enabled = false;
                cbhSaveMoving.Checked = false;
                cbhSaveMoving.Enabled = false;
                btSelectPath.Enabled = false;
                lbFilePath.Enabled = false;

            }
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void cbResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void cbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void cbTypeStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbTypeStream.SelectedIndex) 
            {
                case 0: 
                    {
                        cbhSaveMoving.Visible = false;
                        cbhSaveMoving.Checked = false;
                        cbPeriod.Visible = true;
                        lbInterval.Visible = true;
                    }
                    break;
                case 1:
                    {
                        cbhSaveMoving.Visible = true;
                        cbhSaveMoving.Checked = false;
                        cbPeriod.Visible = false;
                        lbInterval.Visible = false;
                    }
                    break;
                case 2:
                    {
                        cbhSaveMoving.Visible = true;
                        cbhSaveMoving.Checked = false;
                        cbPeriod.Visible = false;
                        lbInterval.Visible = false;
                    }
                    break;

            }
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void tbUrl_TextChanged(object sender, EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }
        #endregion

        private void SetupPage_Load(object sender, EventArgs e)
        {
            cbProfile.SelectedIndex = 1;
            cbTypeStream.SelectedIndex = 1;
            cbPeriod.SelectedIndex = 0;
    
        }
    }
}
