namespace VideoServer.UserInterface
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.gbAbout = new System.Windows.Forms.GroupBox();
            this.btOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gbAbout
            // 
            this.gbAbout.BackColor = System.Drawing.Color.Gray;
            this.gbAbout.Location = new System.Drawing.Point(13, 13);
            this.gbAbout.Margin = new System.Windows.Forms.Padding(4);
            this.gbAbout.Name = "gbAbout";
            this.gbAbout.Padding = new System.Windows.Forms.Padding(4);
            this.gbAbout.Size = new System.Drawing.Size(443, 153);
            this.gbAbout.TabIndex = 0;
            this.gbAbout.TabStop = false;
            // 
            // btOk
            // 
            this.btOk.BackColor = System.Drawing.Color.Silver;
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOk.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btOk.Location = new System.Drawing.Point(329, 188);
            this.btOk.Margin = new System.Windows.Forms.Padding(4);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(127, 28);
            this.btOk.TabIndex = 1;
            this.btOk.Text = "Закрити";
            this.btOk.UseVisualStyleBackColor = false;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(467, 229);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.gbAbout);
            this.ForeColor = System.Drawing.Color.SlateGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Про програму";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAbout;
        private System.Windows.Forms.Button btOk;
    }
}