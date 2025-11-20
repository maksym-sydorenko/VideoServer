using System;
using System.Windows.Forms;
using System.Xml;
using Interfaces;

namespace IPCamera
{
    public partial class SetupPage : System.Windows.Forms.UserControl, Interfaces.ISetupPage
    {
        string frameFrequncy = "";

        string sourcePath = "";
        XmlNode node = null;

        public SetupPage()
        {
            InitializeComponent();
            mtbServerYOLO.ValidatingType = typeof(System.Net.IPAddress);
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
               "<CameraType>IP camera</CameraType>" +
               "<CameraDescription>" + " " + "</CameraDescription>" +
               "<SaveToFile>" + cbhSave.Checked + "</SaveToFile>" +
               "<MoviDetect>" + cbhSaveMoving.Checked + "</MoviDetect>" +
               "<FileDirectoryPath>" + tbPath.Text + "</FileDirectoryPath>" +
               "<Url>" + tbUrl.Text + "</Url>" +
               "<Login>" + tbLogin.Text + "</Login>" +
               "<Password>" + tbPassword.Text + "</Password>" +
               "<SourceType>" + cbTypeStream.Text + "</SourceType>";
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

            if (node.SelectSingleNode("SaveToFile") != null)
                cbhSave.Checked = bool.Parse(node.SelectSingleNode("SaveToFile").InnerText);

            if (node.SelectSingleNode("MoviDetect") != null)
                cbhSaveMoving.Checked = bool.Parse(node.SelectSingleNode("MoviDetect").InnerText);

            if (node.SelectSingleNode("FileDirectoryPath") != null)
                tbPath.Text = node.SelectSingleNode("FileDirectoryPath").InnerText;

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
                else
                {
                    cbTypeStream.SelectedItem = SourceTypes.JPEG;
                }
            }
        }
        #endregion

        internal void Update(ISourceAdaptee ip_camera)
        {

            {
                ip_camera.CameraName = tbName.Text;

                ip_camera.SourcePath = tbUrl.Text;
                ip_camera.Login = tbLogin.Text;
                ip_camera.Password = tbPassword.Text;
                ip_camera.SaveToFile = cbhSave.Checked;
                ip_camera.MoviDetect = cbhSaveMoving.Checked;
                ip_camera.FileDirectoryPath = tbPath.Text;
                ip_camera.CameraDescription = "";
                sourcePath = tbPath.Text;

                string typeStream = cbTypeStream?.SelectedItem?.ToString();
                switch (typeStream)
                {
                    case "JPEG":
                        {
                            ip_camera.SourceType = SourceTypes.JPEG;
                        }
                        break;
                    case "MJPEG":
                        {
                            ip_camera.SourceType = SourceTypes.MJPEG;
                        }
                        break;
                    case "M3U8":
                        {
                            ip_camera.SourceType = SourceTypes.M3U8;
                        }
                        break;
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
            cbTypeStream.SelectedIndex = 1;
        }

        private void cbxDetectObjects_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
