namespace VideoServer.UserInterface
{
    partial class WeekForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeekForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btBack = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbxWeek = new System.Windows.Forms.ListBox();
            this.dgvGrid = new System.Windows.Forms.DataGridView();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Controls.Add(this.btBack);
            this.panel3.Controls.Add(this.btCancel);
            this.panel3.Controls.Add(this.btNext);
            this.panel3.Location = new System.Drawing.Point(109, 183);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(539, 46);
            this.panel3.TabIndex = 6;
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
            // 
            // btNext
            // 
            this.btNext.BackColor = System.Drawing.Color.Silver;
            this.btNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btNext.ForeColor = System.Drawing.Color.Black;
            this.btNext.Location = new System.Drawing.Point(252, 4);
            this.btNext.Margin = new System.Windows.Forms.Padding(4);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(147, 38);
            this.btNext.TabIndex = 5;
            this.btNext.Text = "Прийняти";
            this.btNext.UseVisualStyleBackColor = false;
            // 
            // panel
            // 
            this.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel.BackColor = System.Drawing.Color.Gray;
            this.panel.Location = new System.Drawing.Point(0, 6);
            this.panel.Margin = new System.Windows.Forms.Padding(4);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(101, 223);
            this.panel.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.lbxWeek);
            this.panel1.Controls.Add(this.dgvGrid);
            this.panel1.Location = new System.Drawing.Point(109, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 170);
            this.panel1.TabIndex = 6;
            // 
            // lbxWeek
            // 
            this.lbxWeek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbxWeek.FormattingEnabled = true;
            this.lbxWeek.ItemHeight = 20;
            this.lbxWeek.Items.AddRange(new object[] {
            "Понеділок",
            "Вівторок",
            "Середа",
            "Четвер",
            "П\'ятница",
            "Субота ",
            "Неділя"});
            this.lbxWeek.Location = new System.Drawing.Point(5, 10);
            this.lbxWeek.Margin = new System.Windows.Forms.Padding(4);
            this.lbxWeek.Name = "lbxWeek";
            this.lbxWeek.Size = new System.Drawing.Size(143, 142);
            this.lbxWeek.TabIndex = 1;
            // 
            // dgvGrid
            // 
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrid.Location = new System.Drawing.Point(157, 9);
            this.dgvGrid.Margin = new System.Windows.Forms.Padding(4);
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.RowHeadersWidth = 51;
            this.dgvGrid.Size = new System.Drawing.Size(373, 153);
            this.dgvGrid.TabIndex = 0;
            // 
            // WeekForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(656, 234);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WeekForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тиждень";
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lbxWeek;
        private System.Windows.Forms.DataGridView dgvGrid;
    }
}