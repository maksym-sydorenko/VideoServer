using Microsoft.Win32;
using System;
namespace Interfaces
{
    public static class Settings
    {
        static double alarmLevel = 0.03;

        /// <summary>
        /// Alarm Level
        /// </summary>
        public static double AlarmLevel
        {
            get { return alarmLevel; }
            set { alarmLevel = value; }
        }

        /// <summary>
        /// Global Path Enabled
        /// </summary>
        public static bool GlobalPathEnabled { get; set; }

        /// <summary>
        /// Global Path Disk
        /// </summary>
        public static string GlobalDisk { get; set; }

        /// <summary>
        /// Global Path
        /// </summary>
        public static string GlobalPath { get; set; }

        private const string RegistryKeyPath = @"SOFTWARE\SpyVsSpy\VCS";

        /// <summary>
        /// Save To Registry
        /// </summary>
        public static void SaveToRegistry(bool saveAlarmLevel)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryKeyPath))
            {
                if (saveAlarmLevel)
                {
                    key.SetValue("AlarmLevel", AlarmLevel, RegistryValueKind.String);
                }
                else
                {
                    key.SetValue("GlobalPathEnabled", GlobalPathEnabled, RegistryValueKind.DWord);
                    key.SetValue("GlobalDisk", GlobalDisk ?? string.Empty, RegistryValueKind.String);
                    key.SetValue("GlobalPath", GlobalPath ?? string.Empty, RegistryValueKind.String);
                }
            }
        }

        /// <summary>
        /// Load From Registry
        /// </summary>
        public static void LoadFromRegistry()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath))
            {
                if (key == null) return;

                double.TryParse(key.GetValue("AlarmLevel", AlarmLevel.ToString()).ToString(), out alarmLevel);

                GlobalPathEnabled = Convert.ToBoolean((int)key.GetValue("GlobalPathEnabled", GlobalPathEnabled ? 1 : 0));
                GlobalDisk = key.GetValue("GlobalDisk", GlobalDisk ?? string.Empty).ToString();
                GlobalPath = key.GetValue("GlobalPath", GlobalPath ?? string.Empty).ToString();
            }
        }
    }

}
