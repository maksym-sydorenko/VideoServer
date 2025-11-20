namespace DLink
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
            this.btSelectPath = new System.Windows.Forms.Button();
            this.cbhSave = new System.Windows.Forms.CheckBox();
            this.lbInterval = new System.Windows.Forms.Label();
            this.cbPeriod = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.cbhSaveMoving = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbProfile = new System.Windows.Forms.ComboBox();
            this.cbTypeStream = new System.Windows.Forms.ComboBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.lbFilePath = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(40, 25);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 30;
            this.label6.Text = "Назва:";
            // 
            // btSelectPath
            // 
            this.btSelectPath.Enabled = false;
            this.btSelectPath.Location = new System.Drawing.Point(444, 276);
            this.btSelectPath.Margin = new System.Windows.Forms.Padding(4);
            this.btSelectPath.Name = "btSelectPath";
            this.btSelectPath.Size = new System.Drawing.Size(44, 28);
            this.btSelectPath.TabIndex = 29;
            this.btSelectPath.Text = "...";
            this.btSelectPath.UseVisualStyleBackColor = true;
            this.btSelectPath.Click += new System.EventHandler(this.btSelectPath_Click);
            // 
            // cbhSave
            // 
            this.cbhSave.AutoSize = true;
            this.cbhSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbhSave.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbhSave.Location = new System.Drawing.Point(44, 219);
            this.cbhSave.Margin = new System.Windows.Forms.Padding(4);
            this.cbhSave.Name = "cbhSave";
            this.cbhSave.Size = new System.Drawing.Size(186, 21);
            this.cbhSave.TabIndex = 36;
            this.cbhSave.Text = "Зберегати потік в файл";
            this.cbhSave.UseVisualStyleBackColor = true;
            this.cbhSave.CheckedChanged += new System.EventHandler(this.cbhSave_CheckedChanged);
            // 
            // lbInterval
            // 
            this.lbInterval.AutoSize = true;
            this.lbInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbInterval.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbInterval.Location = new System.Drawing.Point(293, 154);
            this.lbInterval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbInterval.Name = "lbInterval";
            this.lbInterval.Size = new System.Drawing.Size(53, 17);
            this.lbInterval.TabIndex = 39;
            this.lbInterval.Text = "Період";
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
            this.cbPeriod.Location = new System.Drawing.Point(361, 146);
            this.cbPeriod.Margin = new System.Windows.Forms.Padding(4);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(125, 24);
            this.cbPeriod.TabIndex = 27;
            this.cbPeriod.SelectedIndexChanged += new System.EventHandler(this.cbPeriod_SelectedIndexChanged);
            // 
            // cbhSaveMoving
            // 
            this.cbhSaveMoving.AutoSize = true;
            this.cbhSaveMoving.Enabled = false;
            this.cbhSaveMoving.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbhSaveMoving.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbhSaveMoving.Location = new System.Drawing.Point(44, 251);
            this.cbhSaveMoving.Margin = new System.Windows.Forms.Padding(4);
            this.cbhSaveMoving.Name = "cbhSaveMoving";
            this.cbhSaveMoving.Size = new System.Drawing.Size(168, 21);
            this.cbhSaveMoving.TabIndex = 37;
            this.cbhSaveMoving.Text = "Зберегати тільки рух";
            this.cbhSaveMoving.UseVisualStyleBackColor = true;
            this.cbhSaveMoving.CheckedChanged += new System.EventHandler(this.cbhSaveMoving_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(40, 190);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 17);
            this.label7.TabIndex = 35;
            this.label7.Text = "Профіль";
            // 
            // cbProfile
            // 
            this.cbProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfile.FormattingEnabled = true;
            this.cbProfile.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbProfile.Location = new System.Drawing.Point(155, 186);
            this.cbProfile.Margin = new System.Windows.Forms.Padding(4);
            this.cbProfile.Name = "cbProfile";
            this.cbProfile.Size = new System.Drawing.Size(116, 24);
            this.cbProfile.TabIndex = 26;
            this.cbProfile.SelectedIndexChanged += new System.EventHandler(this.cbResolution_SelectedIndexChanged);
            // 
            // cbTypeStream
            // 
            this.cbTypeStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeStream.FormattingEnabled = true;
            this.cbTypeStream.Items.AddRange(new object[] {
            "JPEG",
            "MJPEG",
            "RTSP"});
            this.cbTypeStream.Location = new System.Drawing.Point(193, 146);
            this.cbTypeStream.Margin = new System.Windows.Forms.Padding(4);
            this.cbTypeStream.Name = "cbTypeStream";
            this.cbTypeStream.Size = new System.Drawing.Size(91, 24);
            this.cbTypeStream.TabIndex = 25;
            this.cbTypeStream.SelectedIndexChanged += new System.EventHandler(this.cbTypeStream_SelectedIndexChanged);
            // 
            // tbPath
            // 
            this.tbPath.Enabled = false;
            this.tbPath.Location = new System.Drawing.Point(248, 279);
            this.tbPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(187, 22);
            this.tbPath.TabIndex = 28;
            this.tbPath.TextChanged += new System.EventHandler(this.tbPath_TextChanged);
            // 
            // lbFilePath
            // 
            this.lbFilePath.AutoSize = true;
            this.lbFilePath.Enabled = false;
            this.lbFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbFilePath.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbFilePath.Location = new System.Drawing.Point(40, 283);
            this.lbFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFilePath.Name = "lbFilePath";
            this.lbFilePath.Size = new System.Drawing.Size(179, 17);
            this.lbFilePath.TabIndex = 38;
            this.lbFilePath.Text = "Шлях збереження данних:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(135, 16);
            this.tbName.Margin = new System.Windows.Forms.Padding(4);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(352, 22);
            this.tbName.TabIndex = 21;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(40, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 34;
            this.label4.Text = "Тип відеопотоку";
            // 
            // tbPassword
            // 
            this.tbPassword.AcceptsReturn = true;
            this.tbPassword.Location = new System.Drawing.Point(135, 114);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(171, 22);
            this.tbPassword.TabIndex = 24;
            this.tbPassword.UseSystemPasswordChar = true;
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(40, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Password:";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(135, 82);
            this.tbLogin.Margin = new System.Windows.Forms.Padding(4);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(171, 22);
            this.tbLogin.TabIndex = 23;
            this.tbLogin.TextChanged += new System.EventHandler(this.tbLogin_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(40, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "Login:";
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(135, 50);
            this.tbUrl.Margin = new System.Windows.Forms.Padding(4);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(352, 22);
            this.tbUrl.TabIndex = 22;
            this.tbUrl.TextChanged += new System.EventHandler(this.tbUrl_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(40, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "URL:";
            // 
            // SetupPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btSelectPath);
            this.Controls.Add(this.cbhSave);
            this.Controls.Add(this.lbInterval);
            this.Controls.Add(this.cbPeriod);
            this.Controls.Add(this.cbhSaveMoving);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbProfile);
            this.Controls.Add(this.cbTypeStream);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.lbFilePath);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SetupPage";
            this.Size = new System.Drawing.Size(515, 337);
            this.Load += new System.EventHandler(this.SetupPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btSelectPath;
        private System.Windows.Forms.CheckBox cbhSave;
        private System.Windows.Forms.Label lbInterval;
        private System.Windows.Forms.ComboBox cbPeriod;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox cbhSaveMoving;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbProfile;
        private System.Windows.Forms.ComboBox cbTypeStream;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label lbFilePath;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label label1;
    }
}