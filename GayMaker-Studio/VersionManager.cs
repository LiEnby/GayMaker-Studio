using GMTools;
using Ionic.Zip;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Threading;
using System.Windows.Forms;

namespace GayMaker_Studio
{

    public partial class VersionManager : Form
    {
        //private const int NUMBER_OF_CDN_URLS = 4; //Uncomment for GMS2
        private const int NUMBER_OF_CDN_URLS = 2;

        private string currentDownload = "";

        private void CopyDir(string source, string target)
        {

            if (!Directory.Exists(target)) Directory.CreateDirectory(target);
            string[] sysEntries = Directory.GetFileSystemEntries(source);

            foreach (string sysEntry in sysEntries)
            {
                string fileName = Path.GetFileName(sysEntry);
                string targetPath = Path.Combine(target, fileName);
                if (Directory.Exists(sysEntry))
                    CopyDir(sysEntry, targetPath);
                else
                {
                    File.Copy(sysEntry, targetPath, true);
                }
            }
        }

        private string getUrlFileName(string url)
        {
            string filename = Path.GetFileName(new Uri(url).LocalPath);
            if (!Path.HasExtension(filename))
                filename = Path.ChangeExtension(filename, ".zip");
            return filename;
        }

        public VersionManager()
        {
            //Bypass Windows DPI Scaling
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            InitializeComponent();
        }

        private void VersionManager_Load(object sender, EventArgs e)
        {
            this.Owner = Program.GMS;
            Directory.CreateDirectory(@"versions");

            for (int cdnIndex = 1; cdnIndex <= NUMBER_OF_CDN_URLS; cdnIndex++)
            {
                Thread downloadThread = new Thread(() =>
                {
                    CDN.UseCDN(CDNUrls.FromIndex(cdnIndex));
                });

                downloadThread.Start();

                while (downloadThread.IsAlive)
                    Application.DoEvents();


                foreach (String Version in CDN.GetVersions("ps4"))
                {
                    if (Version != "1.4.9999" || DownloadList.Items.Contains(Version))
                        DownloadList.Items.Add(Version);
                }
            }

            foreach (String dir in Directory.GetDirectories(@"versions"))
            {
                DownloadedList.Items.Add(Path.GetFileName(dir));
                DownloadList.Items.Remove(Path.GetFileName(dir));
            }
        }

        private void startDownload(string URL, string path)
        {
            currentDownload = getUrlFileName(URL);
            DownloadProgress.Value = 0;
            DownloadProgress.Style = ProgressBarStyle.Continuous;


            WebClient wc = new WebClient();
            wc.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            wc.Dispose();

            WebClient client = new WebClient();
            client.Headers.Add("pragma", "no-cache");


            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileAsync(new Uri(URL), path);

            while (client.IsBusy)
                Application.DoEvents();

            StatusText.Text = "Waiting...";
            DownloadProgress.Value = 0;
            DownloadProgress.Style = ProgressBarStyle.Continuous;
        }

        private void extractFile(string zipfile, string path, string password = "")
        {

            DownloadProgress.Style = ProgressBarStyle.Marquee;
            Thread extractThread = new Thread(() =>
            {

                if (Directory.Exists(path))
                {
                    while (true)
                    {
                        try
                        {
                            Directory.Delete(path, true);
                        }
                        catch (Exception) { };
                        break;
                    }
                }


                Thread.CurrentThread.IsBackground = true;
                Invoke((Action)delegate { StatusText.Text = "Extracting: " + Path.GetFileName(zipfile); });


                using (ZipFile archive = new ZipFile(zipfile))
                {
                    archive.Password = password;
                    archive.Encryption = EncryptionAlgorithm.PkzipWeak;
                    archive.ExtractAll(path);
                }

            });

            extractThread.Start();

            while (extractThread.IsAlive)
                Application.DoEvents();

            StatusText.Text = "Waiting...";
            DownloadProgress.Value = 0;
            DownloadProgress.Style = ProgressBarStyle.Continuous;


            File.Delete(zipfile);
        }


        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadProgress.Value = e.ProgressPercentage;
            StatusText.Text = "Downloading: "+ currentDownload + " " +  e.ProgressPercentage + "% (" + e.BytesReceived + "b / " + e.TotalBytesToReceive + "b)";
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (DownloadList.SelectedIndex <= -1) { return; }
            DownloadList.Enabled = false;
            DownloadButton.Enabled = false;
            ControlBox = false;

            string version = DownloadList.SelectedItem.ToString();

            for (int cdnIndex = 1; cdnIndex <= NUMBER_OF_CDN_URLS; cdnIndex++)
            {
                Thread downloadThread = new Thread(() =>
                {
                    CDN.UseCDN(CDNUrls.FromIndex(cdnIndex));
                });

                downloadThread.Start();

                while (downloadThread.IsAlive)
                    Application.DoEvents();

                string ps4Url = CDN.GetModuleForVersion(version, "ps4");
                if (ps4Url != "NF")
                {
                    string ps4Filename = getUrlFileName(ps4Url);
                    string ps4Password = CDN.GetPassword(ps4Filename);

                    string gamemakerUrl = CDN.GetModuleForVersion(version, "original");
                    string gamemakerFilename = getUrlFileName(gamemakerUrl);
                    string gamemakerPassword = CDN.GetPassword(gamemakerFilename);

                    startDownload(ps4Url, ps4Filename);
                    extractFile(ps4Filename, @"_ps4", ps4Password);

                    startDownload(gamemakerUrl, gamemakerFilename);
                    extractFile(gamemakerFilename, @"_gamemaker", gamemakerPassword);

                    DownloadProgress.Style = ProgressBarStyle.Marquee;
                    StatusText.Text = "Copying Files...";
                    Application.DoEvents();

                    Thread copyThread = new Thread(() =>
                    {

                        Directory.CreateDirectory(@"versions\\" + version + "\\Runner");
                        Directory.CreateDirectory(@"versions\\" + version + "\\Shaders");

                        if (version.StartsWith("1."))
                        {
                            try
                            {
                                File.Copy(@"_gamemaker\\GMAssetCompiler.exe", @"versions\\" + version + "\\GMAssetCompiler.exe", true);
                                File.Copy(@"_gamemaker\\ffmpeg.exe", @"versions\\" + version + "\\ffmpeg.exe", true);

                                File.Copy(@"_gamemaker\\BouncyCastle.Crypto.dll", @"versions\\" + version + "\\BouncyCastle.Crypto.dll", true);
                                File.Copy(@"_gamemaker\\spine-csharp.dll", @"versions\\" + version + "\\spine-csharp.dll", true);
                                File.Copy(@"_gamemaker\\SharpCompress.dll", @"versions\\" + version + "\\SharpCompress.dll", true);
                                File.Copy(@"_gamemaker\\Ionic.Zip.Reduced.dll", @"versions\\" + version + "\\Ionic.Zip.Reduced.dll", true);
                                File.Copy(@"_gamemaker\\Newtonsoft.Json.dll", @"versions\\" + version + "\\Newtonsoft.Json.dll", true);
                            }
                            catch (Exception) { };
                        }
                        else if(version.StartsWith("2."))
                        {
                            try
                            {
                                File.Copy(@"_gamemaker\\bin\\GMAssetCompiler.exe", @"versions\\" + version + "\\GMAssetCompiler.exe", true);
                                File.Copy(@"_gamemaker\\bin\\ffmpeg.exe", @"versions\\" + version + "\\ffmpeg.exe", true);
                                File.Copy(@"_gamemaker\\bin\\Newtonsoft.Json.dll", @"versions\\" + version + "\\Newtonsoft.Json.dll", true);

                                File.Copy(@"_gamemaker\\bin\\BouncyCastle.Crypto.dll", @"versions\\" + version + "\\BouncyCastle.Crypto.dll", true);
                                File.Copy(@"_gamemaker\\bin\\spine-csharp.dll", @"versions\\" + version + "\\spine-csharp.dll", true);
                                File.Copy(@"_gamemaker\\bin\\SharpCompress.dll", @"versions\\" + version + "\\SharpCompress.dll", true);
                                File.Copy(@"_gamemaker\\bin\\Ionic.Zip.Reduced.dll", @"versions\\" + version + "\\Ionic.Zip.Reduced.dll", true);
                            }
                            catch (Exception) { };
                        }


                        CopyDir(@"Runner", @"versions\\" + version + "\\Runner");

                        if(version.StartsWith("1."))
                        {
                            CopyDir(@"_gamemaker\\Shaders", @"versions\\" + version + "\\Shaders");
                        }
                        else if(version.StartsWith("2."))
                        {
                            CopyDir(@"_gamemaker\\bin\Shaders", @"versions\\" + version + "\\Shaders");
                            CopyDir(@"_gamemaker\\BaseProject", @"versions\\" + version + "\\BaseProject");
                            CopyDir(@"_ps4\\BaseProject", @"versions\\" + version + "\\BaseProject");
                        }
                            

                        File.Delete(@"versions\\" + version + "\\Runner\\eboot.bin");

                        try
                        {

                            File.Copy(@"_ps4\\PS4\\PSSL_PShaderCommon.shader", @"versions\\" + version + "\\Shaders\\PSSL_PShaderCommon.shade", true);
                            File.Copy(@"_ps4\\PS4\\PSSL_VShaderCommon.shader", @"versions\\" + version + "\\Shaders\\PSSL_VShaderCommon.shader", true);
                            File.Copy(@"_ps4\\PS4\\HLSL_to_PSSL.h", @"versions\\" + version + "\\Shaders\\HLSL_to_PSSL.h", true);

                        }
                        catch (Exception){ };
                        
                        });
                    copyThread.Start();

                    while (copyThread.IsAlive)
                        Application.DoEvents();

                    if(version.StartsWith("2.") || version == "1.4.9999")
                    {
                        DownloadProgress.Style = ProgressBarStyle.Marquee;
                        StatusText.Text = "Applying SceVerDown Magic (by dots_tb)...";
                        Application.DoEvents();

                        ELF.Tools.SceVerDown(@"_ps4\\PS4\\PS4Runner.elf", 0x05008001);
                    }

                    DownloadProgress.Style = ProgressBarStyle.Marquee;
                    StatusText.Text = "Running Make FSELF (by flat_z)...";
                    Application.DoEvents();

                    ELF.Tools.MakeFself(@"_ps4\\PS4\\PS4Runner.elf", @"versions\\" + version + "\\Runner\\eboot.bin");

                    DownloadProgress.Style = ProgressBarStyle.Marquee;
                    StatusText.Text = "Deleting Unused Files...";
                    Application.DoEvents();

                    Thread deleteThread = new Thread(() =>
                    {
                        while(true)
                        {
                            try
                            {
                                Directory.Delete(@"_ps4", true);
                                Directory.Delete(@"_gamemaker", true);
                            }
                            catch (Exception) { };
                            break;
                        }
                    });

                    deleteThread.Start();

                    while (deleteThread.IsAlive)
                        Application.DoEvents();

                    DownloadProgress.Style = ProgressBarStyle.Continuous;
                    DownloadProgress.Value = 0;
                    StatusText.Text = "Waiting...";

                    DownloadedList.Items.Add(version);
                    DownloadList.Items.Remove(version);

                    DownloadList.Enabled = true;
                    DownloadButton.Enabled = true;
                    ControlBox = true;

                }
            }
        }

        private void DeleteVersion_Click(object sender, EventArgs e)
        {
            if (DownloadedList.SelectedIndex == -1) { return; }
            string toRemove = DownloadedList.SelectedItem.ToString();
            if (toRemove == "1.4.9999")
            {
                MessageBox.Show("Cannot delete builtin 1.4.9999 version!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Directory.Exists(@"versions\\" + toRemove))
                {
                    while (true)
                    {
                        try
                        {
                            Directory.Delete(@"versions\\" + toRemove, true);
                        }
                        catch (Exception) { };
                        break;
                    }
                }
                
                DownloadedList.Items.Remove(toRemove);
                DownloadList.Items.Add(toRemove);
            }
        }

    }
}
