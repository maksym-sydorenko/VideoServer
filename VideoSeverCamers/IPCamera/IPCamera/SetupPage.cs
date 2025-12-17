using System;
using System.Linq;
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
            mtbUrlYOLO.ValidatingType = typeof(System.Net.IPAddress);
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

            string[] objectsToDetect = clbxObjectsYOLO.CheckedItems
                                              .Cast<object>()
                                              .Select(item => item.ToString())
                                              .ToArray();

            this.node.InnerXml = "<CameraName>" + tbName.Text + "</CameraName>" +
               "<CameraType>IP camera</CameraType>" +
               "<CameraDescription>" + rtbDescription.Text + "</CameraDescription>" +
               "<SaveToFile>" + cbxSave.Checked + "</SaveToFile>" +
               "<MoviDetect>" + cbxSaveMoving.Checked + "</MoviDetect>" +
               "<FileDirectoryPath>" + tbPath.Text + "</FileDirectoryPath>" +
               "<Url>" + tbUrl.Text + "</Url>" +
               "<SourceType>" + cbTypeStream.Text + "</SourceType>" +
               "<UseYOLO>" + cbxUseYOLO.Checked+ "</UseYOLO>" +
               "<UrlYOLO>" + mtbUrlYOLO.Text + "</UrlYOLO>" +
               "<ObjectsYOLO>" + String.Join(";", objectsToDetect) + "</ObjectsYOLO>";
        }

        public void SetConfiguration(XmlNode node)
        {

            if (node.SelectSingleNode("CameraName") != null)
                tbName.Text = node.SelectSingleNode("CameraName").InnerText;

            if (node.SelectSingleNode("CameraDescription") != null)
                rtbDescription.Text = node.SelectSingleNode("CameraDescription").InnerText;

            if (node.SelectSingleNode("Url") != null)
                tbUrl.Text = node.SelectSingleNode("Url").InnerText;

            if (node.SelectSingleNode("SaveToFile") != null)
                cbxSave.Checked = bool.Parse(node.SelectSingleNode("SaveToFile").InnerText);

            if (node.SelectSingleNode("MoviDetect") != null)
                cbxSaveMoving.Checked = bool.Parse(node.SelectSingleNode("MoviDetect").InnerText);

            if (node.SelectSingleNode("FileDirectoryPath") != null)
                tbPath.Text = node.SelectSingleNode("FileDirectoryPath").InnerText;

            if (node.SelectSingleNode("UseYOLO") != null)
                cbxUseYOLO.Checked = bool.Parse(node.SelectSingleNode("UseYOLO").InnerText);

            if (node.SelectSingleNode("UrlYOLO") != null)
                mtbUrlYOLO.Text = node.SelectSingleNode("UrlYOLO").InnerText;

            if (node.SelectSingleNode("ObjectsYOLO") != null)
            {
                string[] obj = node.SelectSingleNode("ObjectsYOLO").InnerText.Split(';');
                for (int i = 0; i < clbxObjectsYOLO.Items.Count; i++)
                {
                    object item = clbxObjectsYOLO.Items[i];
                    for (int j = 0; j < obj.Length; ++j)
                    {
                        if (item.ToString() == obj[j])
                        {
                            clbxObjectsYOLO.SetItemChecked(i, true);
                        }
                    }
                }
            }

            if (node.SelectSingleNode("SourceType") != null)
            {
                string str = node.SelectSingleNode("SourceType").InnerText;
                switch (str)
                {
                    case "JPEG":
                        {
                            cbTypeStream.SelectedItem = "JPEG";
                        }
                        break;
                    case "MJPEG":
                        {
                            cbTypeStream.SelectedItem = "MJPEG";
                        }
                        break;
                    case "M3U8":
                        {
                            cbTypeStream.SelectedItem = "M3U8";
                        }
                        break;
                    case "MP4":
                        {
                            cbTypeStream.SelectedItem = "MP4";
                        }
                        break;
                }
            }
        }
        #endregion

        internal void Update(ISourceAdaptee ip_camera)
        {
            ip_camera.CameraName = tbName.Text;

            ip_camera.SourcePath = tbUrl.Text;
            ip_camera.SaveToFile = cbxSave.Checked;
            ip_camera.MoviDetect = cbxSaveMoving.Checked;
            ip_camera.FileDirectoryPath = tbPath.Text;
            ip_camera.CameraDescription = rtbDescription.Text;
            ip_camera.YoloEnabled = cbxUseYOLO.Checked;
            ip_camera.YoloUrl = mtbUrlYOLO.Text;
            string[] objectsToDetect = clbxObjectsYOLO.CheckedItems
                                               .Cast<object>()
                                               .Select(item => item.ToString())
                                               .ToArray();
            ip_camera.YoloTargets = objectsToDetect;

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

        private void cbxSaveMoving_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSaveMoving.Checked)
            {
                cbxUseYOLO.Checked = false;
            }
            else if (StateChanged != null)
                StateChanged(this, new EventArgs());

        }

        private void cbxSave_CheckedChanged(object sender, EventArgs e)
        {

            if (cbxSave.Checked)
            {
                tbPath.Enabled = true;
                cbxSaveMoving.Enabled = true;
                btSelectPath.Enabled = true;
                lbFilePath.Enabled = true;
                cbxUseYOLO.Enabled = true;
            }
            else
            {
                tbPath.Enabled = false;
                cbxSaveMoving.Checked = false;
                cbxSaveMoving.Enabled = false;
                btSelectPath.Enabled = false;
                lbFilePath.Enabled = false;
                cbxUseYOLO.Enabled = false;

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
            if(cbTypeStream.SelectedIndex == -1)
                cbTypeStream.SelectedIndex = 1;
        }

        private void cbxDetectObjects_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxUseYOLO.Checked)
            {
                mtbUrlYOLO.Enabled = true;
                clbxObjectsYOLO.Enabled = true;
                cbxSaveMoving.Checked = false;
            }
            else
            {
                mtbUrlYOLO.Enabled = false;
                clbxObjectsYOLO.Enabled = false;
            }
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void mtbServerYOLO_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void clbxDetectedObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }
    }
}
