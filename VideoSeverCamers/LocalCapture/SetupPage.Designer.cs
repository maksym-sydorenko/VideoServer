namespace LocalCaptureDevice
{
    partial class SetupPage 
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
            this.label6 = new System.Windows.Forms.Label();
            this.lbPath = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.cbhSaveMoving = new System.Windows.Forms.CheckBox();
            this.cbhSave = new System.Windows.Forms.CheckBox();
            this.btSelectPath = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.cbCaptureDevice = new System.Windows.Forms.ComboBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbInterval = new System.Windows.Forms.Label();
            this.cbPeriod = new System.Windows.Forms.ComboBox();
            this.cbTypeStream = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(40, 73);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Локальна камера";
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.Enabled = false;
            this.lbPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPath.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbPath.Location = new System.Drawing.Point(40, 282);
            this.lbPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(179, 17);
            this.lbPath.TabIndex = 17;
            this.lbPath.Text = "Шлях збереження данних:";
            this.lbPath.Click += new System.EventHandler(this.lbPath_Click);
            // 
            // tbPath
            // 
            this.tbPath.Enabled = false;
            this.tbPath.Location = new System.Drawing.Point(260, 278);
            this.tbPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(175, 22);
            this.tbPath.TabIndex = 7;
            this.tbPath.Text = "D:\\";
            this.tbPath.TextChanged += new System.EventHandler(this.tbPath_TextChanged);
            // 
            // cbhSaveMoving
            // 
            this.cbhSaveMoving.AutoSize = true;
            this.cbhSaveMoving.Enabled = false;
            this.cbhSaveMoving.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbhSaveMoving.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbhSaveMoving.Location = new System.Drawing.Point(44, 250);
            this.cbhSaveMoving.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbhSaveMoving.Name = "cbhSaveMoving";
            this.cbhSaveMoving.Size = new System.Drawing.Size(168, 21);
            this.cbhSaveMoving.TabIndex = 16;
            this.cbhSaveMoving.Text = "Зберегати тільки рух";
            this.cbhSaveMoving.UseVisualStyleBackColor = true;
            this.cbhSaveMoving.CheckedChanged += new System.EventHandler(this.cbhSaveMoving_CheckedChanged);
            // 
            // cbhSave
            // 
            this.cbhSave.AutoSize = true;
            this.cbhSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbhSave.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbhSave.Location = new System.Drawing.Point(44, 218);
            this.cbhSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbhSave.Name = "cbhSave";
            this.cbhSave.Size = new System.Drawing.Size(186, 21);
            this.cbhSave.TabIndex = 15;
            this.cbhSave.Text = "Зберегати потік в файл";
            this.cbhSave.UseVisualStyleBackColor = true;
            this.cbhSave.CheckedChanged += new System.EventHandler(this.cbhSave_CheckedChanged);
            // 
            // btSelectPath
            // 
            this.btSelectPath.Enabled = false;
            this.btSelectPath.Location = new System.Drawing.Point(444, 274);
            this.btSelectPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btSelectPath.Name = "btSelectPath";
            this.btSelectPath.Size = new System.Drawing.Size(44, 28);
            this.btSelectPath.TabIndex = 8;
            this.btSelectPath.Text = "...";
            this.btSelectPath.UseVisualStyleBackColor = true;
            this.btSelectPath.Click += new System.EventHandler(this.btSelectPath_Click);
            // 
            // cbCaptureDevice
            // 
            this.cbCaptureDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCaptureDevice.FormattingEnabled = true;
            this.cbCaptureDevice.Location = new System.Drawing.Point(208, 63);
            this.cbCaptureDevice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCaptureDevice.Name = "cbCaptureDevice";
            this.cbCaptureDevice.Size = new System.Drawing.Size(279, 24);
            this.cbCaptureDevice.TabIndex = 21;
            this.cbCaptureDevice.SelectedIndexChanged += new System.EventHandler(this.cbCaptureDevice_SelectedIndexChanged);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbName.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbName.Location = new System.Drawing.Point(40, 23);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(100, 17);
            this.lbName.TabIndex = 22;
            this.lbName.Text = "Назва камери";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(157, 20);
            this.tbName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(329, 22);
            this.tbName.TabIndex = 23;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // lbInterval
            // 
            this.lbInterval.AutoSize = true;
            this.lbInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbInterval.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbInterval.Location = new System.Drawing.Point(40, 159);
            this.lbInterval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbInterval.Name = "lbInterval";
            this.lbInterval.Size = new System.Drawing.Size(53, 17);
            this.lbInterval.TabIndex = 27;
            this.lbInterval.Text = "Період";
            this.lbInterval.Visible = false;
            // 
            // cbPeriod
            // 
            this.cbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeriod.FormattingEnabled = true;
            this.cbPeriod.Items.AddRange(new object[] {
            "3 s",
            "10 s",
            "20 s",
            "1 min",
            "2 min"});
            this.cbPeriod.Location = new System.Drawing.Point(116, 155);
            this.cbPeriod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(91, 24);
            this.cbPeriod.TabIndex = 25;
            this.cbPeriod.Visible = false;
            this.cbPeriod.SelectedIndexChanged += new System.EventHandler(this.cbPeriod_SelectedIndexChanged);
            // 
            // cbTypeStream
            // 
            this.cbTypeStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeStream.FormattingEnabled = true;
            this.cbTypeStream.Items.AddRange(new object[] {
            "LOCAL"});
            this.cbTypeStream.Location = new System.Drawing.Point(193, 116);
            this.cbTypeStream.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbTypeStream.Name = "cbTypeStream";
            this.cbTypeStream.Size = new System.Drawing.Size(91, 24);
            this.cbTypeStream.TabIndex = 24;
            this.cbTypeStream.Visible = false;
            this.cbTypeStream.SelectedIndexChanged += new System.EventHandler(this.cbTypeStream_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(40, 123);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Тип відеопотока";
            this.label4.Visible = false;
            // 
            // SetupPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbInterval);
            this.Controls.Add(this.cbPeriod);
            this.Controls.Add(this.cbTypeStream);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.cbCaptureDevice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btSelectPath);
            this.Controls.Add(this.cbhSave);
            this.Controls.Add(this.cbhSaveMoving);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.lbPath);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SetupPage";
            this.Size = new System.Drawing.Size(515, 337);
            this.Load += new System.EventHandler(this.SetupPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.CheckBox cbhSaveMoving;
        private System.Windows.Forms.CheckBox cbhSave;
        private System.Windows.Forms.Button btSelectPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ComboBox cbCaptureDevice;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbInterval;
        private System.Windows.Forms.ComboBox cbPeriod;
        private System.Windows.Forms.ComboBox cbTypeStream;
        private System.Windows.Forms.Label label4;

    }
}