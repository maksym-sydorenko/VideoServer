namespace axis
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.cbTypeStream = new System.Windows.Forms.ComboBox();
            this.cbhSaveMoving = new System.Windows.Forms.CheckBox();
            this.cbhSave = new System.Windows.Forms.CheckBox();
            this.btSelectPath = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.cbResolution = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(148, 15);
            this.tbName.Margin = new System.Windows.Forms.Padding(4);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(339, 22);
            this.tbName.TabIndex = 0;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Назва камери";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "URL:";
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(119, 49);
            this.tbUrl.Margin = new System.Windows.Forms.Padding(4);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(368, 22);
            this.tbUrl.TabIndex = 1;
            this.tbUrl.TextChanged += new System.EventHandler(this.tbUrl_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Login:";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(119, 81);
            this.tbLogin.Margin = new System.Windows.Forms.Padding(4);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(187, 22);
            this.tbLogin.TabIndex = 2;
            this.tbLogin.TextChanged += new System.EventHandler(this.tbLogin_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 117);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Password:";
            // 
            // tbPassword
            // 
            this.tbPassword.AcceptsReturn = true;
            this.tbPassword.Location = new System.Drawing.Point(119, 113);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(187, 22);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.UseSystemPasswordChar = true;
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 153);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Тип відеопотока";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 282);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Шлях збереження данних:";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(232, 278);
            this.tbPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(203, 22);
            this.tbPath.TabIndex = 7;
            this.tbPath.TextChanged += new System.EventHandler(this.tbPath_TextChanged);
            // 
            // cbTypeStream
            // 
            this.cbTypeStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeStream.FormattingEnabled = true;
            this.cbTypeStream.Items.AddRange(new object[] {
            "MJPEG"});
            this.cbTypeStream.Location = new System.Drawing.Point(173, 145);
            this.cbTypeStream.Margin = new System.Windows.Forms.Padding(4);
            this.cbTypeStream.Name = "cbTypeStream";
            this.cbTypeStream.Size = new System.Drawing.Size(111, 24);
            this.cbTypeStream.TabIndex = 4;
            this.cbTypeStream.SelectedIndexChanged += new System.EventHandler(this.cbTypeStream_SelectedIndexChanged);
            // 
            // cbhSaveMoving
            // 
            this.cbhSaveMoving.AutoSize = true;
            this.cbhSaveMoving.Location = new System.Drawing.Point(44, 250);
            this.cbhSaveMoving.Margin = new System.Windows.Forms.Padding(4);
            this.cbhSaveMoving.Name = "cbhSaveMoving";
            this.cbhSaveMoving.Size = new System.Drawing.Size(167, 20);
            this.cbhSaveMoving.TabIndex = 16;
            this.cbhSaveMoving.Text = "Зберегати тільки рух";
            this.cbhSaveMoving.UseVisualStyleBackColor = true;
            this.cbhSaveMoving.CheckedChanged += new System.EventHandler(this.cbhSaveMoving_CheckedChanged);
            // 
            // cbhSave
            // 
            this.cbhSave.AutoSize = true;
            this.cbhSave.Location = new System.Drawing.Point(44, 218);
            this.cbhSave.Margin = new System.Windows.Forms.Padding(4);
            this.cbhSave.Name = "cbhSave";
            this.cbhSave.Size = new System.Drawing.Size(184, 20);
            this.cbhSave.TabIndex = 15;
            this.cbhSave.Text = "Зберегати потік в файл";
            this.cbhSave.UseVisualStyleBackColor = true;
            this.cbhSave.CheckedChanged += new System.EventHandler(this.cbhSave_CheckedChanged);
            // 
            // btSelectPath
            // 
            this.btSelectPath.Location = new System.Drawing.Point(444, 274);
            this.btSelectPath.Margin = new System.Windows.Forms.Padding(4);
            this.btSelectPath.Name = "btSelectPath";
            this.btSelectPath.Size = new System.Drawing.Size(44, 28);
            this.btSelectPath.TabIndex = 8;
            this.btSelectPath.Text = "...";
            this.btSelectPath.UseVisualStyleBackColor = true;
            this.btSelectPath.Click += new System.EventHandler(this.btSelectPath_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(317, 153);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Розмір";
            // 
            // cbResolution
            // 
            this.cbResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResolution.FormattingEnabled = true;
            this.cbResolution.Items.AddRange(new object[] {
            "160x120",
            "320x240",
            "640x480"});
            this.cbResolution.Location = new System.Drawing.Point(376, 145);
            this.cbResolution.Margin = new System.Windows.Forms.Padding(4);
            this.cbResolution.Name = "cbResolution";
            this.cbResolution.Size = new System.Drawing.Size(111, 24);
            this.cbResolution.TabIndex = 5;
            this.cbResolution.SelectedIndexChanged += new System.EventHandler(this.cbResolution_SelectedIndexChanged);
            // 
            // SetupPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btSelectPath);
            this.Controls.Add(this.cbhSave);
            this.Controls.Add(this.cbhSaveMoving);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbResolution);
            this.Controls.Add(this.cbTypeStream);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.label5);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.ComboBox cbTypeStream;
        private System.Windows.Forms.CheckBox cbhSaveMoving;
        private System.Windows.Forms.CheckBox cbhSave;
        private System.Windows.Forms.Button btSelectPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbResolution;
    }
}