using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace VideoServer.UserInterface
{
    public partial class AddViewForm : Form
    {
        public AddViewForm()
        {
            InitializeComponent();
            viewGrid.DragEnter += new DragEventHandler(viewGrid_DragEnter);
            viewGrid.DragDrop += new DragEventHandler(viewGrid_DragDrop);
               
        }

        private void btFinish_Click(object sender, EventArgs e)
        {
            UpdateDialog(true);
            this.DialogResult = DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
        }

        XmlNode node =null;
        public void SetNode(ref XmlNode node)
        {
            this.node = node;
            if (node.SelectSingleNode("row") != null)
                viewGrid.Rows = short.Parse(node.SelectSingleNode("row").InnerText);
            if (node.SelectSingleNode("col") != null)
                viewGrid.Cols = short.Parse(node.SelectSingleNode("col").InnerText);
        }

        XmlDocument setting = null;
        public void SetDocument(ref XmlDocument setting)
        {
            this.setting = setting;
        }

        private void viewGrid_Click(object sender, EventArgs e)
        {
            try 
            {
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void AddViewForm_Load(object sender, EventArgs e)
        {
            UpdateTree();
        }

        private void UpdateTree()
        {
            lbxCameras.Items.Clear();
            XmlNode appNode = setting.SelectSingleNode("/ROOT/Cameras");
            foreach (XmlNode node in appNode.ChildNodes)
            {
                lbxCameras.Items.Add(node.Attributes["CameraName"].InnerText);
             
            }
        }

        private void UpdateDialog(bool update) 
        {
            if (setting == null)
                throw new Exception("Не введён документ настроек");
            if (update)
            {
                XmlNode nodeCamera = null;
                for (short i = 0; i < viewGrid.Cols; i++) 
                {
                    for (short j = 0; j < viewGrid.Rows; j++)
                    {
                        nodeCamera = setting.CreateNode(XmlNodeType.Element, "SelectedCamera", "");
                        XmlAttribute attribute = setting.CreateAttribute("CameraName");
                        nodeCamera.Attributes.Append(attribute);
                        nodeCamera.Attributes["CameraName"].InnerText = viewGrid.GetLabel(j,i);
                        nodeCamera.InnerXml = "<row>"+j.ToString()+"</row>"+
			                                  "<col>"+i.ToString()+"</col>"+
				                                "<monday/>"+
				                                "<tuesday/>"+
				                                "<wednesday/>"+
			                                	"<thursday/>"+
			                                   	"<friday/>"+
				                                "<saturday/>"+
				                                "<sunday/>";
                        node.AppendChild(nodeCamera.Clone());
                        nodeCamera = null;
                    }
                
                }
                
                
            } 
            else 
            {
            }     
        
        }
       
        void lbxCameras_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (((ListBox)sender).SelectedIndex != -1)
                ((ListBox)sender).DoDragDrop(((ListBox)sender).Text,DragDropEffects.All);
        }
        void viewGrid_DragEnter(object sender, DragEventArgs de)
        {
            if (de.Data.GetDataPresent(DataFormats.Text))
            {
                de.Effect = DragDropEffects.Copy;
            }
            else
            {
                de.Effect = DragDropEffects.None;
            }

        }
        void viewGrid_DragDrop(object sender, DragEventArgs de)
        {
            string cameraName = "";
            cameraName = (string)de.Data.GetData(DataFormats.Text);
            Point pt = viewGrid.PointToClient(new Point(de.X,de.Y));
            viewGrid.SetLabel(cameraName, pt);
        }
      
    }
}
