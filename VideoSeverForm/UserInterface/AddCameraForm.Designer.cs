namespace VideoServer.UserInterface
{
    partial class AddCameraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCameraForm));
            this.btClose = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.cbCameraType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btCheck = new System.Windows.Forms.Button();
            this.pnCameraForm = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cameraViwer = new VideoServer.Controls.CameraViwer();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.BackColor = System.Drawing.Color.Silver;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btClose.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btClose.Location = new System.Drawing.Point(187, 4);
            this.btClose.Margin = new System.Windows.Forms.Padding(4);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(172, 38);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "<Закрити>";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btAdd
            // 
            this.btAdd.BackColor = System.Drawing.Color.Silver;
            this.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAdd.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btAdd.Location = new System.Drawing.Point(4, 4);
            this.btAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(175, 38);
            this.btAdd.TabIndex = 1;
            this.btAdd.Text = "<Додати>";
            this.btAdd.UseVisualStyleBackColor = false;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // cbCameraType
            // 
            this.cbCameraType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCameraType.FormattingEnabled = true;
            this.cbCameraType.Location = new System.Drawing.Point(177, 11);
            this.cbCameraType.Margin = new System.Windows.Forms.Padding(4);
            this.cbCameraType.Name = "cbCameraType";
            this.cbCameraType.Size = new System.Drawing.Size(356, 24);
            this.cbCameraType.TabIndex = 3;
            this.cbCameraType.SelectedIndexChanged += new System.EventHandler(this.cbCameraType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Тип камери";
            // 
            // btCheck
            // 
            this.btCheck.BackColor = System.Drawing.Color.Silver;
            this.btCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCheck.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btCheck.Location = new System.Drawing.Point(367, 4);
            this.btCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btCheck.Name = "btCheck";
            this.btCheck.Size = new System.Drawing.Size(168, 38);
            this.btCheck.TabIndex = 5;
            this.btCheck.Text = "<Перевірити>";
            this.btCheck.UseVisualStyleBackColor = false;
            this.btCheck.Click += new System.EventHandler(this.btCheck_Click);
            // 
            // pnCameraForm
            // 
            this.pnCameraForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnCameraForm.BackColor = System.Drawing.Color.Gray;
            this.pnCameraForm.Location = new System.Drawing.Point(4, 55);
            this.pnCameraForm.Margin = new System.Windows.Forms.Padding(4);
            this.pnCameraForm.Name = "pnCameraForm";
            this.pnCameraForm.Size = new System.Drawing.Size(539, 370);
            this.pnCameraForm.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Controls.Add(this.btAdd);
            this.panel3.Controls.Add(this.btCheck);
            this.panel3.Controls.Add(this.btClose);
            this.panel3.Location = new System.Drawing.Point(4, 433);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(539, 46);
            this.panel3.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.cameraViwer);
            this.panel1.Location = new System.Drawing.Point(547, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 476);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.cbCameraType);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(4, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(539, 46);
            this.panel2.TabIndex = 6;
            // 
            // cameraViwer
            // 
            this.cameraViwer.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.cameraViwer.Location = new System.Drawing.Point(4, 4);
            this.cameraViwer.Margin = new System.Windows.Forms.Padding(4);
            this.cameraViwer.Name = "cameraViwer";
            this.cameraViwer.Size = new System.Drawing.Size(560, 468);
            this.cameraViwer.TabIndex = 0;
            // 
            // AddCameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1120, 511);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnCameraForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCameraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Додати камеру";
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.ComboBox cbCameraType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCheck;
        private VideoServer.Controls.CameraViwer cameraViwer;
        private System.Windows.Forms.Panel pnCameraForm;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}