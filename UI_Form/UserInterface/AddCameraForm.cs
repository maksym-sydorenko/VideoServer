using System;
using System.Windows.Forms;
using System.Xml;
using VideoServer.Tools;


namespace VideoServer.UserInterface
{
    internal partial class AddCameraForm : Form
    {
        CameraCollection camers = null;
        Interfaces.ISetupPage setupPage = null;

        internal AddCameraForm(CameraCollection camers)
        {
            InitializeComponent();
            this.camers = camers;

            if (camers==null)
               return;


            foreach (Camera camera in camers)
            {
                cbCameraType.Items.Add(camera.ISourceAdaptee.CameraType);
                camera.ISourceAdaptee.ISetupPage.StateChanged += new EventHandler(setupPage_StateChanged);
            }
            if (cbCameraType.Items.Count > 0)
                cbCameraType.SelectedIndex = 0;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (camers[cbCameraType.SelectedIndex].ISourceAdaptee.CameraName == "")
                {
                    MessageBox.Show("Введіть назву камери");
                    return;
                }
                foreach (Camera camera in camers)
                {
                    camera.Stop();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            foreach (Camera camera in camers)
            {
               camera.Stop();
            }
            //DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btCheck_Click(object sender, EventArgs e)
        {
            if (btCheck.Text == "<Перевірити>")
            {
                if (cbCameraType.SelectedIndex != -1)
                {
                    camers[cbCameraType.SelectedIndex].NewFrame += new CameraEventHandler(AddCameraForm_NewFrame);
                    camers[cbCameraType.SelectedIndex].StartPreview();
                    btCheck.Text = "<Відключити>";
                    cbCameraType.Enabled = false;
                    pnCameraForm.Enabled = false;
                }
               
            }
            else
            {
                if (cbCameraType.SelectedIndex != -1)
                {
                    camers[cbCameraType.SelectedIndex].Stop();
                    camers[cbCameraType.SelectedIndex].NewFrame -= new CameraEventHandler(AddCameraForm_NewFrame);
                    btCheck.Text = "<Перевірити>";
                    cbCameraType.Enabled = true;
                    pnCameraForm.Enabled = true;
                }
            }
        }

        void AddCameraForm_NewFrame(object sender, Interfaces.CameraEventArgs e)
        {
            cameraViwer.camera_NewFrame(sender,  e);   
        }

        private void cbCameraType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCameraType.SelectedIndex !=-1) 
            {
                setupPage = camers[cbCameraType.SelectedIndex].ISourceAdaptee.ISetupPage;
                pnCameraForm.Controls.Clear();
                if (setupPage != null)
                {
                    pnCameraForm.Controls.Clear();
                    Control control = (Control)setupPage;
                    pnCameraForm.Controls.Add(control);
                    control.Dock = DockStyle.Fill;
                    control.Show();
                }
            }
        }

        void setupPage_StateChanged(object sender, EventArgs e)
        {
            
        }

        public void GetCameraConfiguration(ref XmlNode node)
        {

            if (setupPage == null)
                return;
            setupPage.GetConfiguration(ref node);
        }

        public void SetCameraConfiguration(XmlNode node)
        {
            if (node.SelectSingleNode("CameraType") == null)
                return;
           
            cbCameraType.SelectedItem = node.SelectSingleNode("CameraType").InnerText;
            setupPage = camers[cbCameraType.SelectedIndex].ISourceAdaptee.ISetupPage;
            if (setupPage == null)
                return;
            setupPage.SetConfiguration(node);

        }

      
    }
}
