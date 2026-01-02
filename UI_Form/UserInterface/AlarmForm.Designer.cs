namespace VideoServer.UserInterface
{
    partial class AlarmForm
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
            this.gbDiskSpace = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDisk = new System.Windows.Forms.ComboBox();
            this.tbDiskAll = new System.Windows.Forms.TextBox();
            this.tbDiskFree = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbWhenFreeSize = new System.Windows.Forms.TextBox();
            this.tbrDiskSpace = new System.Windows.Forms.TrackBar();
            this.gbMeil = new System.Windows.Forms.GroupBox();
            this.tbEmail4 = new System.Windows.Forms.TextBox();
            this.tbEmail2 = new System.Windows.Forms.TextBox();
            this.tbEmail3 = new System.Windows.Forms.TextBox();
            this.tbEmail1 = new System.Windows.Forms.TextBox();
            this.btAccept = new System.Windows.Forms.Button();
            this.gbDiskSpace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrDiskSpace)).BeginInit();
            this.gbMeil.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDiskSpace
            // 
            this.gbDiskSpace.Controls.Add(this.label5);
            this.gbDiskSpace.Controls.Add(this.cbDisk);
            this.gbDiskSpace.Controls.Add(this.tbDiskAll);
            this.gbDiskSpace.Controls.Add(this.tbDiskFree);
            this.gbDiskSpace.Controls.Add(this.label4);
            this.gbDiskSpace.Controls.Add(this.label3);
            this.gbDiskSpace.Controls.Add(this.label2);
            this.gbDiskSpace.Controls.Add(this.label1);
            this.gbDiskSpace.Controls.Add(this.tbWhenFreeSize);
            this.gbDiskSpace.Controls.Add(this.tbrDiskSpace);
            this.gbDiskSpace.Location = new System.Drawing.Point(16, 15);
            this.gbDiskSpace.Margin = new System.Windows.Forms.Padding(4);
            this.gbDiskSpace.Name = "gbDiskSpace";
            this.gbDiskSpace.Padding = new System.Windows.Forms.Padding(4);
            this.gbDiskSpace.Size = new System.Drawing.Size(284, 266);
            this.gbDiskSpace.TabIndex = 0;
            this.gbDiskSpace.TabStop = false;
            this.gbDiskSpace.Text = "Простір до попередження";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Диск";
            // 
            // cbDisk
            // 
            this.cbDisk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDisk.FormattingEnabled = true;
            this.cbDisk.Location = new System.Drawing.Point(17, 47);
            this.cbDisk.Margin = new System.Windows.Forms.Padding(4);
            this.cbDisk.Name = "cbDisk";
            this.cbDisk.Size = new System.Drawing.Size(87, 24);
            this.cbDisk.TabIndex = 12;
            this.cbDisk.SelectedIndexChanged += new System.EventHandler(this.cbDisk_SelectedIndexChanged);
            // 
            // tbDiskAll
            // 
            this.tbDiskAll.Enabled = false;
            this.tbDiskAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDiskAll.Location = new System.Drawing.Point(117, 47);
            this.tbDiskAll.Margin = new System.Windows.Forms.Padding(4);
            this.tbDiskAll.Name = "tbDiskAll";
            this.tbDiskAll.Size = new System.Drawing.Size(157, 27);
            this.tbDiskAll.TabIndex = 11;
            // 
            // tbDiskFree
            // 
            this.tbDiskFree.Enabled = false;
            this.tbDiskFree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDiskFree.Location = new System.Drawing.Point(117, 101);
            this.tbDiskFree.Margin = new System.Windows.Forms.Padding(4);
            this.tbDiskFree.Name = "tbDiskFree";
            this.tbDiskFree.Size = new System.Drawing.Size(157, 27);
            this.tbDiskFree.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Вільно";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Всього на диску";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 165);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "меньше ніж:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 138);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Попередити коли залишиться";
            // 
            // tbWhenFreeSize
            // 
            this.tbWhenFreeSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbWhenFreeSize.Location = new System.Drawing.Point(117, 158);
            this.tbWhenFreeSize.Margin = new System.Windows.Forms.Padding(4);
            this.tbWhenFreeSize.Name = "tbWhenFreeSize";
            this.tbWhenFreeSize.Size = new System.Drawing.Size(157, 27);
            this.tbWhenFreeSize.TabIndex = 5;
            // 
            // tbrDiskSpace
            // 
            this.tbrDiskSpace.Location = new System.Drawing.Point(8, 201);
            this.tbrDiskSpace.Margin = new System.Windows.Forms.Padding(4);
            this.tbrDiskSpace.Name = "tbrDiskSpace";
            this.tbrDiskSpace.Size = new System.Drawing.Size(268, 56);
            this.tbrDiskSpace.TabIndex = 0;
            this.tbrDiskSpace.Scroll += new System.EventHandler(this.tbrDiskSpace_Scroll);
            // 
            // gbMeil
            // 
            this.gbMeil.Controls.Add(this.tbEmail4);
            this.gbMeil.Controls.Add(this.tbEmail2);
            this.gbMeil.Controls.Add(this.tbEmail3);
            this.gbMeil.Controls.Add(this.tbEmail1);
            this.gbMeil.Controls.Add(this.btAccept);
            this.gbMeil.Location = new System.Drawing.Point(313, 15);
            this.gbMeil.Margin = new System.Windows.Forms.Padding(4);
            this.gbMeil.Name = "gbMeil";
            this.gbMeil.Padding = new System.Windows.Forms.Padding(4);
            this.gbMeil.Size = new System.Drawing.Size(284, 266);
            this.gbMeil.TabIndex = 1;
            this.gbMeil.TabStop = false;
            this.gbMeil.Text = "Адреси попередження";
            // 
            // tbEmail4
            // 
            this.tbEmail4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbEmail4.Location = new System.Drawing.Point(8, 139);
            this.tbEmail4.Margin = new System.Windows.Forms.Padding(4);
            this.tbEmail4.Name = "tbEmail4";
            this.tbEmail4.Size = new System.Drawing.Size(265, 27);
            this.tbEmail4.TabIndex = 4;
            // 
            // tbEmail2
            // 
            this.tbEmail2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbEmail2.Location = new System.Drawing.Point(8, 68);
            this.tbEmail2.Margin = new System.Windows.Forms.Padding(4);
            this.tbEmail2.Name = "tbEmail2";
            this.tbEmail2.Size = new System.Drawing.Size(265, 27);
            this.tbEmail2.TabIndex = 3;
            // 
            // tbEmail3
            // 
            this.tbEmail3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbEmail3.Location = new System.Drawing.Point(9, 103);
            this.tbEmail3.Margin = new System.Windows.Forms.Padding(4);
            this.tbEmail3.Name = "tbEmail3";
            this.tbEmail3.Size = new System.Drawing.Size(265, 27);
            this.tbEmail3.TabIndex = 2;
            // 
            // tbEmail1
            // 
            this.tbEmail1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbEmail1.Location = new System.Drawing.Point(9, 32);
            this.tbEmail1.Margin = new System.Windows.Forms.Padding(4);
            this.tbEmail1.Name = "tbEmail1";
            this.tbEmail1.Size = new System.Drawing.Size(265, 27);
            this.tbEmail1.TabIndex = 1;
            // 
            // btAccept
            // 
            this.btAccept.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAccept.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btAccept.Location = new System.Drawing.Point(8, 224);
            this.btAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(268, 28);
            this.btAccept.TabIndex = 0;
            this.btAccept.Text = "Принять";
            this.btAccept.UseVisualStyleBackColor = false;
            this.btAccept.Click += new System.EventHandler(this.btAccept_Click);
            // 
            // AlarmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(613, 295);
            this.Controls.Add(this.gbMeil);
            this.Controls.Add(this.gbDiskSpace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AlarmForm";
            this.Text = "AlarmForm";
            this.Load += new System.EventHandler(this.AlarmForm_Load);
            this.gbDiskSpace.ResumeLayout(false);
            this.gbDiskSpace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrDiskSpace)).EndInit();
            this.gbMeil.ResumeLayout(false);
            this.gbMeil.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDiskSpace;
        private System.Windows.Forms.GroupBox gbMeil;
        private System.Windows.Forms.Button btAccept;
        private System.Windows.Forms.TrackBar tbrDiskSpace;
        private System.Windows.Forms.TextBox tbEmail4;
        private System.Windows.Forms.TextBox tbEmail2;
        private System.Windows.Forms.TextBox tbEmail3;
        private System.Windows.Forms.TextBox tbEmail1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbWhenFreeSize;
        private System.Windows.Forms.TextBox tbDiskAll;
        private System.Windows.Forms.TextBox tbDiskFree;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDisk;
    }
}