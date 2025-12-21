using System.IO.Compression;
using System.Configuration.Install;
using System.ComponentModel;
using System.IO;
using System;
using System.Collections;

[RunInstaller(true)]
public class PostInstallActions : Installer
{
    public override void Install(System.Collections.IDictionary stateSaver)
    {
        base.Install(stateSaver);
        string baseDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        string archivePath = Path.Combine(baseDir, "libvlc.zip");
        string extractPath = Path.Combine(baseDir, "libvlc");
        if (!Directory.Exists(extractPath))
        {
            Directory.CreateDirectory(extractPath);
        }
        if (File.Exists(archivePath))
        {
            ZipFile.ExtractToDirectory(archivePath, extractPath);
            File.Delete(archivePath);
        }
    }
    public override void Uninstall(IDictionary savedState)
    {
        base.Uninstall(savedState);

        string baseDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        string extractPath = Path.Combine(baseDir, "libvlc");
        string xmlPath = Path.Combine(baseDir, "xml");

        if (Directory.Exists(extractPath))
        {
            try
            {
                Directory.Delete(extractPath, recursive: true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        if (Directory.Exists(xmlPath))
        {
            try
            {
                Directory.Delete(xmlPath, recursive: true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
