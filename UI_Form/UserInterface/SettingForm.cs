using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace VideoServer.UserInterface
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
            Interfaces.Settings.LoadFromRegistry();
            GetDisks();

            dtbDetectionLevel.Value = Interfaces.Settings.AlarmLevel;

            tbPath.Text = Interfaces.Settings.GlobalPath;
            cbxGlobalPath.Checked = Interfaces.Settings.GlobalPathEnabled;
            try
            {
                cbDisk.SelectedItem = Interfaces.Settings.GlobalDisk;
            }
            catch (Exception ex)
            {
                Interfaces.Settings.GlobalPathEnabled = false;
                cbxGlobalPath.Checked = Interfaces.Settings.GlobalPathEnabled;
            }
        }

        void GetDisks()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            cbDisk.Items.Clear();
            foreach (DriveInfo drive in drives)
            {
                LogAdd($"Диск: {drive.Name}\n");
                LogAdd($"Тип: {drive.DriveType}\n");
                cbDisk.Items.Add( drive.Name );

                if (drive.IsReady)
                {
                    LogAdd($"Мітка: {drive.VolumeLabel}\n");
                    LogAdd($"Файлова система: {drive.DriveFormat}\n");
                    LogAdd($"Вільно: {drive.AvailableFreeSpace / (1024 * 1024 * 1024)} ГБ\n");
                    LogAdd($"Загальний розмір: {drive.TotalSize / (1024 * 1024 * 1024)} ГБ\n");
                }
                LogAdd("\n");
            }
            cbDisk.SelectedIndex = 0;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btSetDetectionLevel_Click(object sender, EventArgs e)
        {
            try
            {
                Interfaces.Settings.AlarmLevel = (double)(dtbDetectionLevel.Value);
                Interfaces.Settings.SaveToRegistry(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxGlobalPath_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cbDisk.Enabled = cbxGlobalPath.Checked;
                tbPath.Enabled = cbxGlobalPath.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btSetDiskPath_Click(object sender, EventArgs e)
        {
            try
            {
                Interfaces.Settings.GlobalPathEnabled = true;
                Interfaces.Settings.GlobalDisk = cbDisk.SelectedItem.ToString();
                Interfaces.Settings.GlobalPath = tbPath.Text;
                Interfaces.Settings.SaveToRegistry(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Debug log
        private const int log_size = 10000;
        StringBuilder _strLog = new StringBuilder();
        private void LogAdd(String log)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => LogAdd(log)));
            }
            else
            {
                //_strLog.Append(String.Format("[{0}] {1} \n", DateTime.Now.ToString("mm-ss:fff") , log.Replace('\n',' ')));
                log = log.Replace('\0', ' ');
                _strLog.Append(log);
                if (_strLog.Length > log_size)
                {
                    _strLog.Clear();
                }
                rtbDiskInfo.Text = _strLog.ToString();
                rtbDiskInfo.ScrollToCaret();
            }
        }

        private void LogClear()
        {
            _strLog.Clear();
            rtbDiskInfo.Text = _strLog.ToString();
        }
        #endregion

    }
}
