using System;
using System.Windows.Forms;
using System.Xml;
using Interfaces;

namespace axis
{
    public partial class SetupPage : System.Windows.Forms.UserControl, Interfaces.ISetupPage
    {
        string frameFrequncy = "1";
        string sourcePath = "";
        string description = "Axis camera";
        XmlNode node = null;

        public SetupPage()
        {
            InitializeComponent();
            cbTypeStream.SelectedIndex = 0;
            cbResolution.SelectedIndex = 1;
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
            this.node.InnerXml = "<CameraName>" + tbName.Text + "</CameraName>" +
               "<CameraType>Axis web camera</CameraType>" +
               "<CameraDescription>" + description + "</CameraDescription>" +
               "<SaveToFile>" + cbhSave.Checked + "</SaveToFile>" +
               "<MoviDetect>" + cbhSaveMoving.Checked + "</MoviDetect>" +
               "<FileDirectoryPath>" + tbPath.Text + "</FileDirectoryPath>" +
               "<Url>" + tbUrl.Text + "</Url>" +
               "<Login>" + tbLogin.Text + "</Login>" +
               "<Password>" + tbPassword.Text + "</Password>" +
               "<SourceType>" + cbTypeStream.Text + "</SourceType>" +
               "<Resolution>" + cbResolution.Text + "</Resolution>";
        }

        public void SetConfiguration(XmlNode node)
        {
            if (node.SelectSingleNode("CameraName") != null)
                tbName.Text = node.SelectSingleNode("CameraName").InnerText;

            if (node.SelectSingleNode("CameraDescription") != null)
                description = node.SelectSingleNode("CameraDescription").InnerText;

            if (node.SelectSingleNode("Url") != null)
                tbUrl.Text = node.SelectSingleNode("Url").InnerText;

            if (node.SelectSingleNode("Login") != null)
                tbLogin.Text = node.SelectSingleNode("Login").InnerText;

            if (node.SelectSingleNode("Password") != null)
                tbPassword.Text = node.SelectSingleNode("Password").InnerText;

            if (node.SelectSingleNode("Resolution") != null)
                cbResolution.SelectedItem = node.SelectSingleNode("Resolution").InnerText;

            if (node.SelectSingleNode("SaveToFile") != null)
                cbhSave.Checked = bool.Parse(node.SelectSingleNode("SaveToFile").InnerText);

            if (node.SelectSingleNode("MoviDetect") != null)
                cbhSaveMoving.Checked = bool.Parse(node.SelectSingleNode("MoviDetect").InnerText);

            if (node.SelectSingleNode("FileDirectoryPath") != null)
                tbPath.Text = node.SelectSingleNode("FileDirectoryPath").InnerText;

            cbTypeStream.SelectedItem = SourceTypes.MJPEG;//!!! only
        }
        #endregion

        internal void Update(ISourceAdaptee axisCamera)
        {
            axisCamera.CameraName = tbName.Text;
            axisCamera.SourcePath = tbUrl.Text;
            axisCamera.Login = tbLogin.Text;
            axisCamera.Password = tbPassword.Text;
            axisCamera.Resolution = cbResolution.SelectedItem.ToString();
            axisCamera.Quality = "";
            axisCamera.SourceType = SourceTypes.MJPEG;// only MJPEG
            axisCamera.CameraDescription = "";

            sourcePath = tbPath.Text;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
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

        private void cbResolution_SelectedIndexChanged(object sender, EventArgs e)
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
