using System;

using System.Windows.Forms;
using Interfaces;
using System.Xml;
using AForge.Video.DirectShow;

namespace LocalCaptureDevice
{
    public partial class SetupPage : System.Windows.Forms.UserControl, Interfaces.ISetupPage
    {
        FilterInfoCollection filters;
        //private bool completed = false;
        
        
        XmlNode node = null;
       
        public SetupPage()
        {
            InitializeComponent();
          //cbCaptureDevice.
            filters = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (filters.Count == 0)
            {
                cbCaptureDevice.Items.Add("No local capture devices");
                cbCaptureDevice.Enabled = false;
            }
            else
            {
                // add all devices to combo
                foreach (FilterInfo filter in filters)
                {
                    cbCaptureDevice.Items.Add(filter.Name);
                }
               // completed = true;
            }
            cbCaptureDevice.SelectedIndex = 0;
            cbTypeStream.SelectedIndex = 0;
            cbPeriod.SelectedIndex = 0;
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

        #region ISetupPage Members
        public event EventHandler StateChanged;
      
        public void Display()
        {
            cbCaptureDevice.Focus();
            
        }
        public void GetConfiguration(ref XmlNode node)
        {
            this.node = node;
            this.node.InnerXml = "<CameraName>" + tbName.Text + "</CameraName>" +
              "<CameraType>Local Capture Device</CameraType>" +
              "<CameraDescription>" + " " + "</CameraDescription>" +
              "<SaveToFile>" + cbhSave.Checked + "</SaveToFile>" +
              "<MoviDetect>" + cbhSaveMoving.Checked + "</MoviDetect>" +
              "<FileDirectoryPath>" + tbPath.Text + "</FileDirectoryPath>" +
              "<Url>" + cbCaptureDevice.Text + "</Url>" +
              "<SourceType>" + cbTypeStream.Text + "</SourceType>" +
              "<FrameFrequncy>" + cbPeriod.Text + "</FrameFrequncy>";
        }

        public void SetConfiguration(XmlNode node)
        {
            if (node.SelectSingleNode("CameraName") != null)
                tbName.Text = node.SelectSingleNode("CameraName").InnerText;

            //if (node.SelectSingleNode("CameraDescription") != null)
            //    description = node.SelectSingleNode("CameraDescription").InnerText;

            if (node.SelectSingleNode("Url") != null)
                cbCaptureDevice.Text = node.SelectSingleNode("Url").InnerText;

            //if (node.SelectSingleNode("Login") != null)
            //    tbLogin.Text = node.SelectSingleNode("Login").InnerText;

            //if (node.SelectSingleNode("Password") != null)
            //    tbPassword.Text = node.SelectSingleNode("Password").InnerText;

            //if (node.SelectSingleNode("Resolution") != null)
            //    cbProfile.SelectedItem = node.SelectSingleNode("Resolution").InnerText;

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

                if (str == SourceTypes.LOCAL.ToString())
                {
                    cbTypeStream.SelectedItem = SourceTypes.LOCAL;
                }

            }
        }
        #endregion

        internal void Update(ISourceAdaptee localCamera) 
        {
            
            {
                localCamera.CameraName = tbName.Text;
                localCamera.CameraDescription = "";
                localCamera.SourcePath = cbCaptureDevice.Text;//filters[cbCaptureDevice.SelectedIndex].MonikerString;
                localCamera.SaveToFile = cbhSave.Checked;
                localCamera.MoviDetect = cbhSaveMoving.Checked;
                localCamera.FileDirectoryPath = tbPath.Text;
                localCamera.SourceType = SourceTypes.LOCAL;
                
                
            }

        }

        #region  Form Controls
        private void cbhSave_CheckedChanged(object sender, EventArgs e)
        {
            if (cbhSave.Checked)
            {
                cbhSaveMoving.Enabled = true;
                tbPath.Enabled = true;
                btSelectPath.Enabled = true;
                lbPath.Enabled = true;
            }
            else 
            {
                cbhSaveMoving.Enabled = false;
                cbhSaveMoving.Checked = false;
                tbPath.Enabled = false;
                tbPath.Text = "";
                btSelectPath.Enabled = false;
                lbPath.Enabled = false;
                
            }
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

        private void cbCaptureDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void SetupPage_Load(object sender, EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void tbName_TextChanged(object sender, EventArgs e)
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
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        #endregion

        private void lbPath_Click(object sender, EventArgs e)
        {

        }
    }
}
