using VideoServer.Tools;
namespace VideoServer
{
    partial class MainForm
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
            if (_camera != null)
            {
                _camera.Stop();
            }
            if (_camers != null)
            {
                foreach (Camera cam in _camers)
                {
                    cam?.Stop();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.cameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addViewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.delViewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeCameraItem = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.fitToScreenCameraItem = new System.Windows.Forms.MenuItem();
            this.fullScreenCameraItem = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.cameraInfoItem = new System.Windows.Forms.MenuItem();
            this.treeView = new System.Windows.Forms.TreeView();
            this._viewPanel = new VideoServer.Controls.ViewPanel();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.cmenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 423);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(929, 26);
            this.statusStrip.TabIndex = 3;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.ShowDropDownArrow = false;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(93, 24);
            this.toolStripStatusLabel1.Text = "                    ";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cameraToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.previewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(929, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // cameraToolStripMenuItem
            // 
            this.cameraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCameraToolStripMenuItem,
            this.delCameraToolStripMenuItem,
            this.ShowCameraToolStripMenuItem,
            this.editToolStripMenuItem});
            this.cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            this.cameraToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.cameraToolStripMenuItem.Text = "Камера";
            // 
            // addCameraToolStripMenuItem
            // 
            this.addCameraToolStripMenuItem.Name = "addCameraToolStripMenuItem";
            this.addCameraToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.addCameraToolStripMenuItem.Text = "Додати";
            this.addCameraToolStripMenuItem.Click += new System.EventHandler(this.addCameraToolStripMenuItem_Click);
            // 
            // delCameraToolStripMenuItem
            // 
            this.delCameraToolStripMenuItem.Name = "delCameraToolStripMenuItem";
            this.delCameraToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.delCameraToolStripMenuItem.Text = "Видалити";
            this.delCameraToolStripMenuItem.Click += new System.EventHandler(this.delCameraToolStripMenuItem_Click);
            // 
            // ShowCameraToolStripMenuItem
            // 
            this.ShowCameraToolStripMenuItem.Name = "ShowCameraToolStripMenuItem";
            this.ShowCameraToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.ShowCameraToolStripMenuItem.Text = "Підключитися";
            this.ShowCameraToolStripMenuItem.Click += new System.EventHandler(this.conCameraToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.editToolStripMenuItem.Text = "Редагувати";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addViewToolStripMenuItem1,
            this.delViewToolStripMenuItem1,
            this.showViewToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.viewToolStripMenuItem.Text = "Вікно";
            // 
            // addViewToolStripMenuItem1
            // 
            this.addViewToolStripMenuItem1.Name = "addViewToolStripMenuItem1";
            this.addViewToolStripMenuItem1.Size = new System.Drawing.Size(158, 26);
            this.addViewToolStripMenuItem1.Text = "Додати";
            this.addViewToolStripMenuItem1.Click += new System.EventHandler(this.addViewToolStripMenuItem1_Click);
            // 
            // delViewToolStripMenuItem1
            // 
            this.delViewToolStripMenuItem1.Name = "delViewToolStripMenuItem1";
            this.delViewToolStripMenuItem1.Size = new System.Drawing.Size(158, 26);
            this.delViewToolStripMenuItem1.Text = "Видалити";
            this.delViewToolStripMenuItem1.Click += new System.EventHandler(this.delViewToolStripMenuItem1_Click);
            // 
            // showViewToolStripMenuItem
            // 
            this.showViewToolStripMenuItem.Name = "showViewToolStripMenuItem";
            this.showViewToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.showViewToolStripMenuItem.Text = "Показати";
            this.showViewToolStripMenuItem.Click += new System.EventHandler(this.showViewToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.settingToolStripMenuItem.Text = "Налаштування";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullToolStripMenuItem,
            this.fitToolStripMenuItem});
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.previewToolStripMenuItem.Text = "Екран";
            // 
            // fullToolStripMenuItem
            // 
            this.fullToolStripMenuItem.Name = "fullToolStripMenuItem";
            this.fullToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.fullToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.fullToolStripMenuItem.Text = "На повний екран";
            this.fullToolStripMenuItem.Click += new System.EventHandler(this.fullToolStripMenuItem_Click);
            // 
            // fitToolStripMenuItem
            // 
            this.fitToolStripMenuItem.Name = "fitToolStripMenuItem";
            this.fitToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.fitToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.fitToolStripMenuItem.Text = "Розсунути";
            this.fitToolStripMenuItem.Click += new System.EventHandler(this.fitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.helpToolStripMenuItem.Text = "Допомога";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.aboutToolStripMenuItem.Text = "Про програму";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // cmenuStrip
            // 
            this.cmenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.showToolStripMenuItem,
            this.editToolStripMenuItem1});
            this.cmenuStrip.Name = "contextMenuStrip";
            this.cmenuStrip.ShowImageMargin = false;
            this.cmenuStrip.Size = new System.Drawing.Size(130, 100);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.addToolStripMenuItem.Text = "Додати";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.deleteToolStripMenuItem.Text = "Видалити";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.showToolStripMenuItem.Text = "Показати";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(129, 24);
            this.editToolStripMenuItem1.Text = "Редагувати";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem1_Click);
            // 
            // closeCameraItem
            // 
            this.closeCameraItem.Index = -1;
            this.closeCameraItem.Text = "Close view";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = -1;
            this.menuItem4.Text = "-";
            // 
            // fitToScreenCameraItem
            // 
            this.fitToScreenCameraItem.Index = -1;
            this.fitToScreenCameraItem.Shortcut = System.Windows.Forms.Shortcut.F10;
            this.fitToScreenCameraItem.Text = "Fit to screen";
            // 
            // fullScreenCameraItem
            // 
            this.fullScreenCameraItem.Index = -1;
            this.fullScreenCameraItem.Shortcut = System.Windows.Forms.Shortcut.F11;
            this.fullScreenCameraItem.Text = "Full screen";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = -1;
            this.menuItem7.Text = "-";
            // 
            // cameraInfoItem
            // 
            this.cameraInfoItem.Index = -1;
            this.cameraInfoItem.Text = "Camera info";
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.Color.Silver;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView.ForeColor = System.Drawing.SystemColors.Info;
            this.treeView.Location = new System.Drawing.Point(0, 28);
            this.treeView.Margin = new System.Windows.Forms.Padding(4);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(253, 395);
            this.treeView.TabIndex = 1;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // _viewPanel
            // 
            this._viewPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._viewPanel.CellHeight = 480;
            this._viewPanel.CellWidth = 640;
            this._viewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._viewPanel.Location = new System.Drawing.Point(253, 28);
            this._viewPanel.Margin = new System.Windows.Forms.Padding(4);
            this._viewPanel.Name = "_viewPanel";
            this._viewPanel.Size = new System.Drawing.Size(676, 395);
            this._viewPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(929, 449);
            this.Controls.Add(this._viewPanel);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Система відео нагляду";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.cmenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem cameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addViewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem delViewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripDropDownButton toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.MenuItem closeCameraItem;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem fitToScreenCameraItem;
        private System.Windows.Forms.MenuItem fullScreenCameraItem;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem cameraInfoItem;
        private System.Windows.Forms.TreeView treeView;
        private VideoServer.Controls.ViewPanel _viewPanel;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitToolStripMenuItem;

       
    }
}

