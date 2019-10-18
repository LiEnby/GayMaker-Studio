using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Cache;
using System.Reflection;
using System.Windows.Forms;


namespace GayMaker_Studio
{
    public partial class DownloadingUpdate : Form
    {
        public DownloadingUpdate()
        {
            //Bypass Windows DPI Scaling
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            InitializeComponent();
        }

        private void startDownload()
        {
            WebClient wc = new WebClient();
            wc.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            String UpdateString = wc.DownloadString("https://bitbucket.org/SilicaAndPina/gaymaker-studio/raw/master/latest.md");
            String[] Data = UpdateString.Split('~');
            String UpdateUrl = Data[1];
            wc.Dispose();

            WebClient client = new WebClient();
            client.Headers.Add("pragma", "no-cache");

            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            client.DownloadFileAsync(new Uri(UpdateUrl), "upgrade.zip");
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {

            label1.Text = "Extracting...";
            Application.DoEvents();

            String EXEPath = Assembly.GetExecutingAssembly().Location;

            File.Move(EXEPath, Path.ChangeExtension(EXEPath, ".old"));

            ZipArchive archive = new ZipArchive(File.OpenRead("upgrade.zip"));
            
            foreach (ZipArchiveEntry file in archive.Entries)
            {
                if (File.Exists(file.FullName))
                {
                    File.Delete(file.FullName);
                }   
            }

            archive.Dispose();

            ZipFile.ExtractToDirectory("upgrade.zip", Path.GetDirectoryName(EXEPath));

            File.Delete("upgrade.zip");

            Application.Restart();

        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadProgress.Value = e.ProgressPercentage;
            label1.Text = "Downloading: " + e.ProgressPercentage + "%";
        }


        private void DownloadingUpdate_Load(object sender, EventArgs e)
        {
            startDownload();
        }
    }
}
