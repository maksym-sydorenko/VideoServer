namespace IPCamera
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
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.cbhSaveMoving = new System.Windows.Forms.CheckBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.lbFilePath = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDetectObjects = new System.Windows.Forms.CheckBox();
            this.clbxDetectedObjects = new System.Windows.Forms.CheckedListBox();
            this.mtbServerYOLO = new System.Windows.Forms.MaskedTextBox();
            this.cbTypeStream = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbServerYOLO = new System.Windows.Forms.Label();
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
            this.btSelectPath.Location = new System.Drawing.Point(492, 171);
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
            this.cbhSave.Location = new System.Drawing.Point(43, 146);
            this.cbhSave.Margin = new System.Windows.Forms.Padding(4);
            this.cbhSave.Name = "cbhSave";
            this.cbhSave.Size = new System.Drawing.Size(186, 21);
            this.cbhSave.TabIndex = 36;
            this.cbhSave.Text = "Зберегати потік в файл";
            this.cbhSave.UseVisualStyleBackColor = true;
            this.cbhSave.CheckedChanged += new System.EventHandler(this.cbhSave_CheckedChanged);
            // 
            // cbhSaveMoving
            // 
            this.cbhSaveMoving.AutoSize = true;
            this.cbhSaveMoving.Enabled = false;
            this.cbhSaveMoving.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbhSaveMoving.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbhSaveMoving.Location = new System.Drawing.Point(263, 146);
            this.cbhSaveMoving.Margin = new System.Windows.Forms.Padding(4);
            this.cbhSaveMoving.Name = "cbhSaveMoving";
            this.cbhSaveMoving.Size = new System.Drawing.Size(168, 21);
            this.cbhSaveMoving.TabIndex = 37;
            this.cbhSaveMoving.Text = "Зберегати тільки рух";
            this.cbhSaveMoving.UseVisualStyleBackColor = true;
            this.cbhSaveMoving.CheckedChanged += new System.EventHandler(this.cbhSaveMoving_CheckedChanged);
            // 
            // tbPath
            // 
            this.tbPath.Enabled = false;
            this.tbPath.Location = new System.Drawing.Point(263, 175);
            this.tbPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(197, 22);
            this.tbPath.TabIndex = 28;
            this.tbPath.TextChanged += new System.EventHandler(this.tbPath_TextChanged);
            // 
            // lbFilePath
            // 
            this.lbFilePath.AutoSize = true;
            this.lbFilePath.Enabled = false;
            this.lbFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbFilePath.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbFilePath.Location = new System.Drawing.Point(40, 176);
            this.lbFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFilePath.Name = "lbFilePath";
            this.lbFilePath.Size = new System.Drawing.Size(179, 17);
            this.lbFilePath.TabIndex = 38;
            this.lbFilePath.Text = "Шлях збереження данних:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(103, 20);
            this.tbName.Margin = new System.Windows.Forms.Padding(4);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(433, 22);
            this.tbName.TabIndex = 21;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // tbPassword
            // 
            this.tbPassword.AcceptsReturn = true;
            this.tbPassword.Location = new System.Drawing.Point(399, 84);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(137, 22);
            this.tbPassword.TabIndex = 24;
            this.tbPassword.UseSystemPasswordChar = true;
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(318, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Password:";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(103, 84);
            this.tbLogin.Margin = new System.Windows.Forms.Padding(4);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(126, 22);
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
            this.tbUrl.Location = new System.Drawing.Point(103, 50);
            this.tbUrl.Margin = new System.Windows.Forms.Padding(4);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(433, 22);
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
            // cbxDetectObjects
            // 
            this.cbxDetectObjects.AutoSize = true;
            this.cbxDetectObjects.Enabled = false;
            this.cbxDetectObjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxDetectObjects.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbxDetectObjects.Location = new System.Drawing.Point(43, 216);
            this.cbxDetectObjects.Margin = new System.Windows.Forms.Padding(4);
            this.cbxDetectObjects.Name = "cbxDetectObjects";
            this.cbxDetectObjects.Size = new System.Drawing.Size(124, 21);
            this.cbxDetectObjects.TabIndex = 40;
            this.cbxDetectObjects.Text = "Детектування";
            this.cbxDetectObjects.UseVisualStyleBackColor = true;
            this.cbxDetectObjects.CheckedChanged += new System.EventHandler(this.cbxDetectObjects_CheckedChanged);
            // 
            // clbxDetectedObjects
            // 
            this.clbxDetectedObjects.FormattingEnabled = true;
            this.clbxDetectedObjects.Location = new System.Drawing.Point(255, 216);
            this.clbxDetectedObjects.Name = "clbxDetectedObjects";
            this.clbxDetectedObjects.Size = new System.Drawing.Size(281, 89);
            this.clbxDetectedObjects.TabIndex = 41;
            this.clbxDetectedObjects.Visible = false;
            // 
            // mtbServerYOLO
            // 
            this.mtbServerYOLO.Location = new System.Drawing.Point(43, 283);
            this.mtbServerYOLO.Mask = "###.###.###.###";
            this.mtbServerYOLO.Name = "mtbServerYOLO";
            this.mtbServerYOLO.Size = new System.Drawing.Size(206, 22);
            this.mtbServerYOLO.TabIndex = 42;
            this.mtbServerYOLO.Visible = false;
            // 
            // cbTypeStream
            // 
            this.cbTypeStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeStream.FormattingEnabled = true;
            this.cbTypeStream.Items.AddRange(new object[] {
            "JPEG",
            "MJPEG",
            "STREAM"});
            this.cbTypeStream.Location = new System.Drawing.Point(159, 114);
            this.cbTypeStream.Margin = new System.Windows.Forms.Padding(4);
            this.cbTypeStream.Name = "cbTypeStream";
            this.cbTypeStream.Size = new System.Drawing.Size(81, 24);
            this.cbTypeStream.TabIndex = 25;
            this.cbTypeStream.SelectedIndexChanged += new System.EventHandler(this.cbTypeStream_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(40, 122);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 34;
            this.label4.Text = "Тип відеопотоку";
            // 
            // lbServerYOLO
            // 
            this.lbServerYOLO.AutoSize = true;
            this.lbServerYOLO.Enabled = false;
            this.lbServerYOLO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbServerYOLO.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbServerYOLO.Location = new System.Drawing.Point(40, 263);
            this.lbServerYOLO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbServerYOLO.Name = "lbServerYOLO";
            this.lbServerYOLO.Size = new System.Drawing.Size(166, 17);
            this.lbServerYOLO.TabIndex = 43;
            this.lbServerYOLO.Text = "Шлях до  сервера YOLO";
            // 
            // SetupPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.lbServerYOLO);
            this.Controls.Add(this.mtbServerYOLO);
            this.Controls.Add(this.clbxDetectedObjects);
            this.Controls.Add(this.cbxDetectObjects);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btSelectPath);
            this.Controls.Add(this.cbhSave);
            this.Controls.Add(this.cbhSaveMoving);
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
            this.Size = new System.Drawing.Size(540, 308);
            this.Load += new System.EventHandler(this.SetupPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btSelectPath;
        private System.Windows.Forms.CheckBox cbhSave;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox cbhSaveMoving;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label lbFilePath;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxDetectObjects;
        private System.Windows.Forms.CheckedListBox clbxDetectedObjects;
        private System.Windows.Forms.MaskedTextBox mtbServerYOLO;
        private System.Windows.Forms.ComboBox cbTypeStream;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbServerYOLO;
    }
}