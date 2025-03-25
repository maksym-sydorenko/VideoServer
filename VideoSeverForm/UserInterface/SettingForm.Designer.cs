namespace VideoServer.UserInterface
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.tpbSettings = new System.Windows.Forms.TabControl();
            this.tpEmailes = new System.Windows.Forms.TabPage();
            this.tpCodecs = new System.Windows.Forms.TabPage();
            this.tpbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpbSettings
            // 
            this.tpbSettings.CausesValidation = false;
            this.tpbSettings.Controls.Add(this.tpEmailes);
            this.tpbSettings.Controls.Add(this.tpCodecs);
            this.tpbSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpbSettings.Location = new System.Drawing.Point(0, 0);
            this.tpbSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpbSettings.Name = "tpbSettings";
            this.tpbSettings.SelectedIndex = 0;
            this.tpbSettings.Size = new System.Drawing.Size(616, 343);
            this.tpbSettings.TabIndex = 0;
            // 
            // tpEmailes
            // 
            this.tpEmailes.BackColor = System.Drawing.Color.Transparent;
            this.tpEmailes.Location = new System.Drawing.Point(4, 25);
            this.tpEmailes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpEmailes.Name = "tpEmailes";
            this.tpEmailes.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpEmailes.Size = new System.Drawing.Size(608, 314);
            this.tpEmailes.TabIndex = 0;
            this.tpEmailes.Text = "Почта";
            this.tpEmailes.UseVisualStyleBackColor = true;
            // 
            // tpCodecs
            // 
            this.tpCodecs.BackColor = System.Drawing.Color.Transparent;
            this.tpCodecs.Location = new System.Drawing.Point(4, 25);
            this.tpCodecs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpCodecs.Name = "tpCodecs";
            this.tpCodecs.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpCodecs.Size = new System.Drawing.Size(608, 314);
            this.tpCodecs.TabIndex = 1;
            this.tpCodecs.Text = "Кодаки";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 343);
            this.Controls.Add(this.tpbSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Налаштування";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.tpbSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tpbSettings;
        private System.Windows.Forms.TabPage tpCodecs;
        private System.Windows.Forms.TabPage tpEmailes;
    }
}