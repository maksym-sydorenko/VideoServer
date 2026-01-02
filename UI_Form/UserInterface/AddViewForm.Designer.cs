namespace VideoServer.UserInterface
{
    partial class AddViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddViewForm));
            this.panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbxCameras = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.viewGrid = new VideoServer.Controls.ViewGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btBack = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btFinish = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel.Location = new System.Drawing.Point(16, 6);
            this.panel.Margin = new System.Windows.Forms.Padding(4);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(101, 266);
            this.panel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.lbxCameras);
            this.panel1.Location = new System.Drawing.Point(125, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(139, 218);
            this.panel1.TabIndex = 3;
            // 
            // lbxCameras
            // 
            this.lbxCameras.AllowDrop = true;
            this.lbxCameras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxCameras.FormattingEnabled = true;
            this.lbxCameras.ItemHeight = 16;
            this.lbxCameras.Location = new System.Drawing.Point(5, 4);
            this.lbxCameras.Margin = new System.Windows.Forms.Padding(4);
            this.lbxCameras.Name = "lbxCameras";
            this.lbxCameras.Size = new System.Drawing.Size(129, 210);
            this.lbxCameras.TabIndex = 0;
            this.lbxCameras.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbxCameras_MouseDown);
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel2.Controls.Add(this.viewGrid);
            this.panel2.Location = new System.Drawing.Point(272, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 217);
            this.panel2.TabIndex = 3;
            // 
            // viewGrid
            // 
            this.viewGrid.AllowDrop = true;
            this.viewGrid.Cols = ((short)(2));
            this.viewGrid.Location = new System.Drawing.Point(4, 4);
            this.viewGrid.Margin = new System.Windows.Forms.Padding(4);
            this.viewGrid.Name = "viewGrid";
            this.viewGrid.Rows = ((short)(2));
            this.viewGrid.Size = new System.Drawing.Size(384, 209);
            this.viewGrid.TabIndex = 0;
            this.viewGrid.Text = "viewGrid1";
            this.viewGrid.Click += new System.EventHandler(this.viewGrid_Click);
            // 
            // panel3
            // 
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Controls.Add(this.btBack);
            this.panel3.Controls.Add(this.btCancel);
            this.panel3.Controls.Add(this.btFinish);
            this.panel3.Location = new System.Drawing.Point(125, 226);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(539, 46);
            this.panel3.TabIndex = 4;
            // 
            // btBack
            // 
            this.btBack.BackColor = System.Drawing.Color.Silver;
            this.btBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btBack.ForeColor = System.Drawing.Color.Black;
            this.btBack.Location = new System.Drawing.Point(97, 4);
            this.btBack.Margin = new System.Windows.Forms.Padding(4);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(147, 38);
            this.btBack.TabIndex = 7;
            this.btBack.Text = "Назад";
            this.btBack.UseVisualStyleBackColor = false;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.Silver;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.ForeColor = System.Drawing.Color.Black;
            this.btCancel.Location = new System.Drawing.Point(407, 4);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(128, 38);
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "Вихід";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btFinish
            // 
            this.btFinish.BackColor = System.Drawing.Color.Silver;
            this.btFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btFinish.ForeColor = System.Drawing.Color.Black;
            this.btFinish.Location = new System.Drawing.Point(252, 4);
            this.btFinish.Margin = new System.Windows.Forms.Padding(4);
            this.btFinish.Name = "btFinish";
            this.btFinish.Size = new System.Drawing.Size(147, 38);
            this.btFinish.TabIndex = 5;
            this.btFinish.Text = "Зберегти";
            this.btFinish.UseVisualStyleBackColor = false;
            this.btFinish.Click += new System.EventHandler(this.btFinish_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setTimeToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(267, 28);
            // 
            // setTimeToolStripMenuItem
            // 
            this.setTimeToolStripMenuItem.Name = "setTimeToolStripMenuItem";
            this.setTimeToolStripMenuItem.Size = new System.Drawing.Size(266, 24);
            this.setTimeToolStripMenuItem.Text = "Установить график работы";
            // 
            // AddViewForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(680, 278);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Позначити камери";
            this.Load += new System.EventHandler(this.AddViewForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

     
       

       
      

       

       

        #endregion

        private VideoServer.Controls.ViewGrid viewGrid;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btFinish;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem setTimeToolStripMenuItem;
        private System.Windows.Forms.ListBox lbxCameras;
    }
}