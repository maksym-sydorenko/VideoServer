using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoServer.UserInterface
{
    public partial class SettingForm : Form
    {
        UserInterface.CodecForm codecForm = new CodecForm();
        UserInterface.AlarmForm alarmForm = new AlarmForm();

        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
           

            //alarmForm.Size = new Size(900, 412);
            alarmForm.TopLevel = false;
            tpEmailes.Controls.Add(alarmForm);
            alarmForm.Show();

            codecForm.TopLevel = false;
            tpCodecs.Controls.Add(codecForm);
            codecForm.Show();
            
        }
    }
}
