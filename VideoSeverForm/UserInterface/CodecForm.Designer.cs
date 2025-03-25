namespace VideoServer.UserInterface
{
    partial class CodecForm
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
            this.gbVideo = new System.Windows.Forms.GroupBox();
            this.lbVideo = new System.Windows.Forms.Label();
            this.btSelectVideo = new System.Windows.Forms.Button();
            this.lbxVideo = new System.Windows.Forms.ListBox();
            this.gbAudio = new System.Windows.Forms.GroupBox();
            this.lbAudio = new System.Windows.Forms.Label();
            this.btSelectAudio = new System.Windows.Forms.Button();
            this.lbxAudio = new System.Windows.Forms.ListBox();
            this.gbVideo.SuspendLayout();
            this.gbAudio.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbVideo
            // 
            this.gbVideo.Controls.Add(this.lbVideo);
            this.gbVideo.Controls.Add(this.btSelectVideo);
            this.gbVideo.Controls.Add(this.lbxVideo);
            this.gbVideo.Location = new System.Drawing.Point(17, 16);
            this.gbVideo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbVideo.Name = "gbVideo";
            this.gbVideo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbVideo.Size = new System.Drawing.Size(280, 249);
            this.gbVideo.TabIndex = 0;
            this.gbVideo.TabStop = false;
            this.gbVideo.Text = "Відео";
            // 
            // lbVideo
            // 
            this.lbVideo.AutoSize = true;
            this.lbVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbVideo.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbVideo.Location = new System.Drawing.Point(9, 27);
            this.lbVideo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbVideo.Name = "lbVideo";
            this.lbVideo.Size = new System.Drawing.Size(0, 17);
            this.lbVideo.TabIndex = 4;
            // 
            // btSelectVideo
            // 
            this.btSelectVideo.BackColor = System.Drawing.Color.DimGray;
            this.btSelectVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSelectVideo.ForeColor = System.Drawing.Color.Black;
            this.btSelectVideo.Location = new System.Drawing.Point(8, 213);
            this.btSelectVideo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btSelectVideo.Name = "btSelectVideo";
            this.btSelectVideo.Size = new System.Drawing.Size(263, 28);
            this.btSelectVideo.TabIndex = 3;
            this.btSelectVideo.Text = "Вибрати";
            this.btSelectVideo.UseVisualStyleBackColor = false;
            this.btSelectVideo.Click += new System.EventHandler(this.btSelectVideo_Click);
            // 
            // lbxVideo
            // 
            this.lbxVideo.FormattingEnabled = true;
            this.lbxVideo.ItemHeight = 16;
            this.lbxVideo.Location = new System.Drawing.Point(9, 50);
            this.lbxVideo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbxVideo.Name = "lbxVideo";
            this.lbxVideo.Size = new System.Drawing.Size(261, 148);
            this.lbxVideo.TabIndex = 0;
            // 
            // gbAudio
            // 
            this.gbAudio.Controls.Add(this.lbAudio);
            this.gbAudio.Controls.Add(this.btSelectAudio);
            this.gbAudio.Controls.Add(this.lbxAudio);
            this.gbAudio.Location = new System.Drawing.Point(315, 16);
            this.gbAudio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbAudio.Name = "gbAudio";
            this.gbAudio.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbAudio.Size = new System.Drawing.Size(281, 250);
            this.gbAudio.TabIndex = 1;
            this.gbAudio.TabStop = false;
            this.gbAudio.Text = "Аудіо";
            // 
            // lbAudio
            // 
            this.lbAudio.AutoSize = true;
            this.lbAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAudio.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbAudio.Location = new System.Drawing.Point(8, 27);
            this.lbAudio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAudio.Name = "lbAudio";
            this.lbAudio.Size = new System.Drawing.Size(0, 17);
            this.lbAudio.TabIndex = 5;
            // 
            // btSelectAudio
            // 
            this.btSelectAudio.BackColor = System.Drawing.Color.DimGray;
            this.btSelectAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSelectAudio.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btSelectAudio.Location = new System.Drawing.Point(9, 213);
            this.btSelectAudio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btSelectAudio.Name = "btSelectAudio";
            this.btSelectAudio.Size = new System.Drawing.Size(263, 28);
            this.btSelectAudio.TabIndex = 2;
            this.btSelectAudio.Text = "Вибрати";
            this.btSelectAudio.UseVisualStyleBackColor = false;
            this.btSelectAudio.Click += new System.EventHandler(this.btSelectAudio_Click);
            // 
            // lbxAudio
            // 
            this.lbxAudio.FormattingEnabled = true;
            this.lbxAudio.ItemHeight = 16;
            this.lbxAudio.Location = new System.Drawing.Point(9, 50);
            this.lbxAudio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbxAudio.Name = "lbxAudio";
            this.lbxAudio.Size = new System.Drawing.Size(261, 148);
            this.lbxAudio.TabIndex = 1;
            // 
            // CodecForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 295);
            this.Controls.Add(this.gbAudio);
            this.Controls.Add(this.gbVideo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CodecForm";
            this.Text = "CodecForm";
            this.Load += new System.EventHandler(this.CodecForm_Load);
            this.gbVideo.ResumeLayout(false);
            this.gbVideo.PerformLayout();
            this.gbAudio.ResumeLayout(false);
            this.gbAudio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbVideo;
        private System.Windows.Forms.GroupBox gbAudio;
        private System.Windows.Forms.Button btSelectVideo;
        private System.Windows.Forms.ListBox lbxVideo;
        private System.Windows.Forms.Button btSelectAudio;
        private System.Windows.Forms.ListBox lbxAudio;
        private System.Windows.Forms.Label lbVideo;
        private System.Windows.Forms.Label lbAudio;
    }
}