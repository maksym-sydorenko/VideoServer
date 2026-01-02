using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Management;
using VideoServer.email;
namespace VideoServer.UserInterface
{

    public partial class AlarmForm : Form
    {
        DiscsSpace ds = null;
        public AlarmForm()
        {
            InitializeComponent();
        }
        private void AlarmForm_Load(object sender, EventArgs e)
        {

            ds = new DiscsSpace();
            for (int i = 0; i < ds.Count; i++)
            {
                cbDisk.Items.Add(ds[i].Name);
                cbDisk.SelectedIndex = 0;
            }
        }
        private void btAccept_Click(object sender, EventArgs e)
        {

        }

        private void tbrDiskSpace_Scroll(object sender, EventArgs e)
        {
            tbWhenFreeSize.Text = ((tbrDiskSpace.Value * 100 / tbrDiskSpace.Maximum)).ToString() + "%";
            //ds[cbDisk.SelectedIndex].LimitSpace = tbWhenFreeSize.Text;
        }

        private void cbDisk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDisk.SelectedIndex != -1)
            {
                tbDiskFree.Text = ds[cbDisk.SelectedIndex].FreeSpace;
                tbDiskAll.Text = ds[cbDisk.SelectedIndex].TotalSpace;

            }
        }
        /// <summary>
        /// 
        /// </summary>

        private void SendMail(string sendTo, string subject, string text)
        {
            Mapi ma = new Mapi();
            if (!ma.Logon(IntPtr.Zero))
                throw new Exception("MAPILogon failed! : " + ma.Error());

            ma.AddRecip(sendTo, null, false);
            if (!ma.Send(subject, text))
                throw new Exception("MAPISendMail failed! : " + ma.Error());
            ma.Logoff();

        }


    }
    struct Disc
    {
        public Disc(string name, string totalSpace, string freeSpace)
        {
            Name = name;
            TotalSpace = totalSpace;
            FreeSpace = freeSpace;

        }
        public string Name;
        public string TotalSpace;
        public string FreeSpace;

    }
    class DiscsSpace
    {
        List<Disc> disc = null;
        public DiscsSpace()
        {
            disc = new List<Disc>();
            string s = "";
            string sLetter = "";
            string sFSType = "";
            string query = "SELECT * FROM Win32_LogicalDisk WHERE FileSystem IS NOT NULL";
            ManagementObjectSearcher sucher = new ManagementObjectSearcher(query);
            ManagementObjectCollection oReturnCollection = sucher.Get();
            foreach (ManagementObject m in oReturnCollection)
            {
                sLetter = m["DeviceID"].ToString();
                sFSType = m["FileSystem"].ToString();
                s += sLetter + " " + CalcSize(m["FreeSpace"].ToString(), 1) + " " + sFSType + "\n";
                Disc d = new Disc(sLetter, CalcSize(m["Size"].ToString(), 1), CalcSize(m["FreeSpace"].ToString(), 1));
                disc.Add(d);
            }
        }
        private static string CalcSize(string sVal, int iType)
        {
            string sCalc = "";
            float Mbytes = 0;
            switch (iType)
            {
                case 1:
                    Mbytes = (float)((Convert.ToInt64(sVal) / 1024) / 1024);
                    break;
                case 2:
                    Mbytes = (float)(Convert.ToInt64(sVal) / 1024);
                    break;
            }
            if (Mbytes > 1024)
            {
                Mbytes = Mbytes / 1024;
                sCalc = Mbytes.ToString("N2") + " GB ";
            }
            else
                sCalc = Mbytes.ToString() + " MB ";
            return sCalc;
        }
        public Disc this[int i]
        {
            get { return disc[i]; }
        }
        public int Count
        {
            get { return disc.Count; }
        }
    }
}
