using System;
using Interfaces;
using System.Windows.Forms;
using System.Xml;


namespace Panasonic
{
    public partial class SetupPage : System.Windows.Forms.UserControl, ISetupPage
    {

        string frameFrequncy = "";
        
        string sourcePath = "";
        XmlNode node = null;
      
        public SetupPage()
        {
           
            InitializeComponent();
            cbTypeStream.SelectedIndex = 1;
            cbResolution.SelectedIndex = 1;
            cbQuality.SelectedIndex = 1;
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

        private void cbTypeStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTypeStream.SelectedIndex != -1) 
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

            }
            
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
            //this.node.Attributes.i.Attributes..["CameraName"]="Panasonic1";
            this.node.InnerXml = "<CameraName>" + tbName.Text+ "</CameraName>"+
               "<CameraType>Panasonic web camera</CameraType>" +
               "<CameraDescription>" + " " + "</CameraDescription>" +
               "<SourceType>" + cbTypeStream.Text + "</SourceType>" +
               "<SaveToFile>" + cbhSave.Checked + "</SaveToFile>" +
               "<MoviDetect>"+ cbhSaveMoving.Checked +"</MoviDetect>" +
               "<FileDirectoryPath>" + tbPath.Text + "</FileDirectoryPath>"+
               "<Url>" +tbUrl.Text + "</Url>"+
               "<Login>" + tbLogin.Text + "</Login>"+
               "<Password>" +tbPassword.Text + "</Password>"+
               "<Quality>" + cbQuality.Text + "</Quality>"+
               "<Resolution>" + cbResolution.Text + "</Resolution>"+
               "<FrameFrequncy>" +  cbPeriod.Text + "</FrameFrequncy>";

            
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
                cbResolution.SelectedItem = node.SelectSingleNode("Resolution").InnerText;

            if (node.SelectSingleNode("Quality") != null)
                cbQuality.SelectedItem = node.SelectSingleNode("Quality").InnerText;

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

                if (str == Interfaces.SourceTypes.MJPEG.ToString())
                {
                    cbTypeStream.SelectedItem = Interfaces.SourceTypes.MJPEG;
                }
                else if (str == Interfaces.SourceTypes.JPEG.ToString())
                {
                    cbTypeStream.SelectedItem = Interfaces.SourceTypes.JPEG;
                }
                else if (str == Interfaces.SourceTypes.STREAM.ToString())
                {
                    cbTypeStream.SelectedItem = Interfaces.SourceTypes.STREAM;
                }
                else
                {
                    cbTypeStream.SelectedItem = Interfaces.SourceTypes.JPEG;
                }
            }
        }
        
        #endregion


        internal void Update(ISourceAdaptee panasonicCamera) 
        {
            
            {
                panasonicCamera.CameraName = tbName.Text;
                panasonicCamera.Quality = cbQuality.Text;
                panasonicCamera.Resolution = cbResolution.Text;
                panasonicCamera.SourcePath = tbUrl.Text;
                panasonicCamera.Login = tbLogin.Text;
                panasonicCamera.Password = tbPassword.Text;
                panasonicCamera.SaveToFile = cbhSave.Checked;
                panasonicCamera.MoviDetect = cbhSaveMoving.Checked;
                panasonicCamera.FileDirectoryPath = tbPath.Text;
                panasonicCamera.FrameFrequncy = cbPeriod.Text;
                panasonicCamera.CameraDescription = "";
                //panasonicCamera.CameraType

                sourcePath = tbPath.Text;
                if (cbTypeStream.SelectedIndex == 0)
                {
                    panasonicCamera.SourceType = Interfaces.SourceTypes.JPEG;
                    frameFrequncy = cbPeriod.SelectedText;
                }
                else
                {
                    panasonicCamera.SourceType = Interfaces.SourceTypes.MJPEG;
                }
            }
            
        }

        private void tbUrl_TextChanged(object sender, EventArgs e)
        {
           
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
         
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

        private void tbName_TextChanged(object sender, EventArgs e)
        {
               if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void SetupPage_Load(object sender, EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lbInterval_Click(object sender, EventArgs e)
        {

        }

   }

    
}
