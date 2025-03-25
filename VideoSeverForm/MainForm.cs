///////////////////////////////////////////////////////////////////
// Система видео наблюдения "Око"
// Автор ........................................Сидоренко М.Г.
// Год создания ...........................................2010
// 
//////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using VideoServer.Tools;
using System.IO;
using System.Reflection;
using System.Collections;

namespace VideoServer
{
    public partial class MainForm : Form
    {
        CameraCollection camersBaseTypes = null;
        CameraCollection camers = null;
        Camera camera = null;
        XmlDocument setting = null;
        static string appPath = "";
        VideoServer.UserInterface.AddCameraForm addCameraForm = null;
        VideoServer.UserInterface.ViewSettingForm viewSettingForm = null;
        VideoServer.UserInterface.AddViewForm viewForm = null;
        VideoServer.UserInterface.SettingForm settingForm = null;
        Hashtable tableIAdaptee = null;
        Point mainWindowLocation;
        Size mainWindowSize;


        public MainForm()
        {
            InitializeComponent();
            treeView.MouseClick += new MouseEventHandler(MainForm_MouseClick);
        }

        void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                System.Drawing.Point p = treeView.PointToScreen(e.Location);
                cmenuStrip.Show(p);
            }
        }

        private void addCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCamera();
        }

        private void delCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DelCamera();
        }

        private void conCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addViewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddView();
        }

        private void delViewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DelView();
        }

        private void showViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowView();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                camersBaseTypes = new CameraCollection();
                tableIAdaptee = new Hashtable();
                camersBaseTypes.Load(Path.GetDirectoryName(Application.ExecutablePath), ref tableIAdaptee);
                addCameraForm = new VideoServer.UserInterface.AddCameraForm(camersBaseTypes);

                appPath = System.IO.Path.GetFullPath("xml");
                this.WindowState = FormWindowState.Maximized;
                setting = new XmlDocument();
                setting.Load(appPath + "\\Setting.xml");
                UpdateTree();
                mainWindowLocation = this.Location;
                mainWindowSize = this.Size;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void UpdateTree()
        {
            treeView.Nodes.Clear();
            TreeNode camerasNode = treeView.Nodes.Add("1", "Камери");
            TreeNode camerasViewNode = treeView.Nodes.Add("2", "Вікна нагляду");
            int key = 3;
            XmlNode appNode = setting.SelectSingleNode("/ROOT/Cameras");
            foreach (XmlNode node in appNode.ChildNodes)
            {
                camerasNode.Nodes.Add(key.ToString(), node.Attributes["CameraName"].InnerText);
                key++;
            }
            appNode = setting.SelectSingleNode("/ROOT/CamerasViews");
            foreach (XmlNode node in appNode.ChildNodes)
            {
                camerasViewNode.Nodes.Add(key.ToString(), node.Attributes["ViewName"].InnerText);
                key++;
            }
            return;
        }

        // Full screen
        private void FullScreen(bool full)
        {




            if (full)
            {
                mainWindowLocation = this.Location;
                mainWindowSize = this.Size;

                this.FormBorderStyle = FormBorderStyle.None;
                this.MainMenuStrip = null;

                int cx = Win32.GetSystemMetrics(Win32.SystemMetrics.CXSCREEN);
                int cy = Win32.GetSystemMetrics(Win32.SystemMetrics.CYSCREEN);

                this.Location = new Point(-4, -0);
                this.Size = new Size(cx + 5, cy + 1);
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.MainMenuStrip = this.menuStrip;

                // restore window position
                this.Location = mainWindowLocation;
                this.Size = mainWindowSize;
            }


            // set/reset top most window
            this.TopMost = full;

            // hide/restore cameras bar
            this.treeView.Visible = !full;
            this.menuStrip.Visible = !full;
            this.statusStrip.Visible = !full;


        }

        private void FitToScreen(bool fit)
        {
            viewPanel.FitToWindow = fit;
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if ((treeView.SelectedNode.Name != null) && (treeView.SelectedNode.Name == "1"))
                {
                    ShowCamera();
                }
                else if ((treeView.SelectedNode.Parent != null) && (treeView.SelectedNode.Parent.Name == "1"))
                {
                    ShowCamera();
                }
                else if ((treeView.SelectedNode.Name != null) && (treeView.SelectedNode.Name == "2"))
                {
                    ShowView();
                }
                else if ((treeView.SelectedNode.Parent != null) && (treeView.SelectedNode.Parent.Name == "2"))
                {
                    ShowView();
                }
            }
            catch (Exception)
            { }

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if ((treeView.SelectedNode.Name != null) && (treeView.SelectedNode.Name == "1"))
                {
                    AddCamera();
                }
                else if ((treeView.SelectedNode.Parent != null) && (treeView.SelectedNode.Parent.Name == "1"))
                {
                    AddCamera();
                }
                else if ((treeView.SelectedNode.Name != null) && (treeView.SelectedNode.Name == "2"))
                {
                    AddView();
                }
                else if ((treeView.SelectedNode.Parent != null) && (treeView.SelectedNode.Parent.Name == "2"))
                {
                    AddView();
                }
            }
            catch (Exception)
            { }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {


            try
            {
                if ((treeView.SelectedNode.Name != null) && (treeView.SelectedNode.Name == "1"))
                {
                    DelCamera();
                }
                else if ((treeView.SelectedNode.Parent != null) && (treeView.SelectedNode.Parent.Name == "1"))
                {
                    DelCamera();
                }
                else if ((treeView.SelectedNode.Name != null) && (treeView.SelectedNode.Name == "2"))
                {
                    DelView();
                }
                else if ((treeView.SelectedNode.Parent != null) && (treeView.SelectedNode.Parent.Name == "2"))
                {
                    DelView();
                }
            }
            catch (Exception)
            { }


        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditCamera();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (settingForm == null)
                    settingForm = new VideoServer.UserInterface.SettingForm();

                settingForm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VideoServer.UserInterface.AboutForm aboutForm = new VideoServer.UserInterface.AboutForm();
            aboutForm.ShowDialog();
        }

        private void fullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fullToolStripMenuItem.Checked = !fullToolStripMenuItem.Checked;
            FullScreen(fullToolStripMenuItem.Checked);
            FitToScreen(fitToolStripMenuItem.Checked);
        }

        private void fitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            fitToolStripMenuItem.Checked = !fitToolStripMenuItem.Checked;
            FitToScreen(fitToolStripMenuItem.Checked);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCamera();
        }

        void AddCamera()
        {
            try
            {

                if (setting == null)
                    return;
                XmlNode node = setting.CreateNode(XmlNodeType.Element, "Camera", "");
                if (node == null)
                    return;
                if (addCameraForm.ShowDialog() == DialogResult.OK)
                {
                    addCameraForm.GetCameraConfiguration(ref node);
                    XmlNode appNode = setting.SelectSingleNode("/ROOT/Cameras/Camera[@CameraName=\"" + node["CameraName"].InnerText + "\"]");
                    if (appNode != null)
                    {
                        MessageBox.Show("Камера с такою назвою існуе");
                        return;
                    }
                    appNode = setting.SelectSingleNode("/ROOT/Cameras");

                    XmlAttribute attribute = setting.CreateAttribute("CameraName");
                    node.Attributes.Append(attribute);
                    node.Attributes["CameraName"].InnerText = node["CameraName"].InnerText;
                    appNode.AppendChild(node);
                    setting.Save(appPath + "\\Setting.xml");
                    UpdateTree();
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void DelCamera()
        {
            try
            {

                if ((setting == null) || (treeView.SelectedNode.Name == "1") || (treeView.SelectedNode.Name == "2"))
                    return;

                XmlNode node = setting.SelectSingleNode("/ROOT/Cameras/Camera[@CameraName=\"" + treeView.SelectedNode.Text + "\"]");
                if (node == null)
                    return;

                XmlNode appNode = setting.SelectSingleNode("/ROOT/Cameras");
                appNode.RemoveChild(node);
                setting.Save(appPath + "\\Setting.xml");
                UpdateTree();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void EditCamera()
        {
            try
            {

                if ((setting == null) || (treeView.SelectedNode.Name == "1") || (treeView.SelectedNode.Name == "2"))
                    return;

                XmlNode node = setting.SelectSingleNode("/ROOT/Cameras/Camera[@CameraName=\"" + treeView.SelectedNode.Text + "\"]");
                if (node == null)
                    return;

                addCameraForm.SetCameraConfiguration(node.Clone());
                if (addCameraForm.ShowDialog() == DialogResult.OK)
                {
                    XmlNode appNode = setting.SelectSingleNode("/ROOT/Cameras");
                    appNode.RemoveChild(node);

                    node = setting.CreateNode(XmlNodeType.Element, "Camera", "");
                    addCameraForm.GetCameraConfiguration(ref node);

                    XmlAttribute attribute = setting.CreateAttribute("CameraName");
                    node.Attributes.Append(attribute);
                    node.Attributes["CameraName"].InnerText = node["CameraName"].InnerText;

                    appNode.AppendChild(node);
                    setting.Save(appPath + "\\Setting.xml");
                    UpdateTree();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void ShowCamera()
        {
            try
            {

                if ((setting == null) || (treeView.SelectedNode.Name == "1") || (treeView.SelectedNode.Name == "2"))
                    return;

                if (camera != null)
                {
                    camera.Stop();
                    camera = null;
                }
                if (camers != null)
                {
                    foreach (Camera cam in camers)
                    {
                        if (cam != null)
                            cam.Stop();
                    }
                    camers.Clear();
                    camers = null;
                }

                camera = CreateCamera(treeView.SelectedNode.Text);
                viewPanel.SetCamera(0, 0, camera);
                viewPanel.Rows = 1;
                viewPanel.Cols = 1;
                viewPanel.SingleCameraMode = true;
                viewPanel.CamerasVisible = true;
                viewPanel.FitToWindow = true;

                camera.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void AddView()
        {
            try
            {
                XmlNode node = null;

                viewSettingForm = new VideoServer.UserInterface.ViewSettingForm();
                viewSettingForm.SetDocument(ref setting);

                viewForm = new VideoServer.UserInterface.AddViewForm();
                viewForm.SetDocument(ref setting);

                do
                {
                    if (viewSettingForm.ShowDialog() != DialogResult.OK)
                        return;
                    viewSettingForm.GetNode(ref node);

                    viewForm.SetNode(ref node);


                } while (viewForm.ShowDialog() == DialogResult.Retry);

                if (viewForm.DialogResult == DialogResult.OK)
                {
                    XmlNode addNode = setting.SelectSingleNode("/ROOT/CamerasViews");
                    addNode.AppendChild(node);
                    setting.Save(appPath + "\\Setting.xml");
                    UpdateTree();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void DelView()
        {
            try
            {
                if ((setting == null) || (treeView.SelectedNode.Name == "1") || (treeView.SelectedNode.Name == "2"))
                    return;

                XmlNode node = setting.SelectSingleNode("/ROOT/CamerasViews/CamerasView[@ViewName=\"" + treeView.SelectedNode.Text + "\"]");
                if (node != null)
                {
                    XmlNode appNode = setting.SelectSingleNode("/ROOT/CamerasViews");
                    appNode.RemoveChild(node);
                    setting.Save(appPath + "\\Setting.xml");
                    treeView.Nodes.Remove(treeView.SelectedNode);
                    //UpdateTree();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void EditView()
        { }
        void ShowView()
        {
            try
            {
                if ((setting == null) || (treeView.SelectedNode.Name == "1") || (treeView.SelectedNode.Name == "2"))
                    return;
                XmlNode node = setting.SelectSingleNode("/ROOT/CamerasViews/CamerasView[@ViewName=\"" + treeView.SelectedNode.Text + "\"]");
                if (node != null)
                {
                    if (this.camera != null)
                    {
                        this.camera.Stop();
                        this.camera = null;
                    }
                    if (camers != null)
                    {
                        foreach (Camera cam in camers)
                        {
                            cam?.Stop();
                        }
                        camers.Clear();
                        camers = null;
                    }
                    //viewPanel = new VideoServer.Controls.ViewPanel();

                    camers = new CameraCollection();
                    if (node.SelectSingleNode("row") != null)
                        viewPanel.Rows = int.Parse(node.SelectSingleNode("row").InnerText);
                    if (node.SelectSingleNode("col") != null)
                        viewPanel.Cols = int.Parse(node.SelectSingleNode("col").InnerText);

                    if (node.SelectSingleNode("width") != null)
                        viewPanel.Width = int.Parse(node.SelectSingleNode("width").InnerText);
                    if (node.SelectSingleNode("height") != null)
                        viewPanel.Height = int.Parse(node.SelectSingleNode("height").InnerText);
                    viewPanel.SingleCameraMode = false;
                    viewPanel.CamerasVisible = true;
                    viewPanel.FitToWindow = true;
                    XmlNodeList nodesCameras = node.SelectNodes("SelectedCamera");

                    foreach (XmlNode nodeCamera in nodesCameras)
                    {
                        Camera camera = null;
                        string cameraName = "";
                        int row = 0;
                        int col = 0;
                        cameraName = nodeCamera.Attributes["CameraName"].Value;
                        camera = CreateCamera(cameraName);
                        camers.Add(camera);

                        if (nodeCamera.SelectSingleNode("row") != null)
                            row = int.Parse(nodeCamera.SelectSingleNode("row").InnerText);

                        if (nodeCamera.SelectSingleNode("col") != null)
                            col = int.Parse(nodeCamera.SelectSingleNode("col").InnerText);

                        if(camera != null)
                            viewPanel.SetCamera(row, col, camera);
                    }
                    foreach (Camera camera in camers)
                    {
                        camera?.Start();
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Camera CreateCamera(string cameraName)
        {
            Camera camera = null;
            XmlNode node = setting.SelectSingleNode("/ROOT/Cameras/Camera[@CameraName=\"" + cameraName + "\"]");
            if (node == null)
                return null;

            string cameraType = node.SelectSingleNode("CameraType").InnerText;
            camera = new Camera();
            camera.ISourceAdaptee = (Interfaces.ISourceAdaptee)tableIAdaptee[cameraType];
            camera.SetConfiguration(node);
            return camera;
        }

    }
}
