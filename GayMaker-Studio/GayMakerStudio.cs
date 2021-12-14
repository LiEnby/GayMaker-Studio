using LibOrbisPkg.GP4;
using LibOrbisPkg.PKG;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace GayMaker_Studio
{
    public partial class GayMakerStudio : Form
    {
        public String CurrentVerison = "1.2.1";
        bool HasShaders = false;

        public GayMakerStudio()
        {

            //Bypass Windows DPI Scaling
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            InitializeComponent();
        }

        public String GetProjectPath() //For GlobalGameSettings
        {
            return projectPath.Text;
        }

        private bool isValidContentId(string contentId)
        {
            if(contentId.Length == 36)
                if (Char.IsLetter(contentId[0]))
                    if (Char.IsUpper(contentId[0]))
                        if (Char.IsLetter(contentId[1]))
                            if (Char.IsUpper(contentId[1]))
                                if (Char.IsNumber(contentId[2]))
                                    if (Char.IsNumber(contentId[3]))
                                        if (Char.IsNumber(contentId[4]))
                                            if (Char.IsNumber(contentId[5]))
                                                if (contentId[6] == '-')
                                                    if (Char.IsLetter(contentId[7]))
                                                        if (Char.IsUpper(contentId[7]))
                                                            if (Char.IsLetter(contentId[8]))
                                                                if (Char.IsUpper(contentId[8]))
                                                                    if (Char.IsLetter(contentId[9]))
                                                                        if (Char.IsUpper(contentId[9]))
                                                                            if (Char.IsLetter(contentId[10]))
                                                                                if (Char.IsUpper(contentId[10]))
                                                                                    if (Char.IsNumber(contentId[11]))
                                                                                        if (Char.IsNumber(contentId[12]))
                                                                                            if (Char.IsNumber(contentId[13]))
                                                                                                if (Char.IsNumber(contentId[14]))
                                                                                                    if (Char.IsNumber(contentId[15]))
                                                                                                        if (contentId[16] == '_')
                                                                                                            if (Char.IsNumber(contentId[17]))
                                                                                                                if (Char.IsNumber(contentId[18]))
                                                                                                                    if (contentId[19] == '-')
                                                                                                                        if ((Char.IsNumber(contentId[20])) || (Char.IsLetter(contentId[20]) && Char.IsUpper(contentId[20])))
                                                                                                                            if ((Char.IsNumber(contentId[21])) || (Char.IsLetter(contentId[21]) && Char.IsUpper(contentId[21])))
                                                                                                                                if ((Char.IsNumber(contentId[22])) || (Char.IsLetter(contentId[22]) && Char.IsUpper(contentId[22])))
                                                                                                                                    if ((Char.IsNumber(contentId[23])) || (Char.IsLetter(contentId[23]) && Char.IsUpper(contentId[23])))
                                                                                                                                        if ((Char.IsNumber(contentId[24])) || (Char.IsLetter(contentId[24]) && Char.IsUpper(contentId[24])))
                                                                                                                                            if ((Char.IsNumber(contentId[25])) || (Char.IsLetter(contentId[25]) && Char.IsUpper(contentId[25])))
                                                                                                                                                if ((Char.IsNumber(contentId[26])) || (Char.IsLetter(contentId[26]) && Char.IsUpper(contentId[26])))
                                                                                                                                                    if ((Char.IsNumber(contentId[27])) || (Char.IsLetter(contentId[27]) && Char.IsUpper(contentId[27])))
                                                                                                                                                        if ((Char.IsNumber(contentId[28])) || (Char.IsLetter(contentId[28]) && Char.IsUpper(contentId[28])))
                                                                                                                                                            if ((Char.IsNumber(contentId[29])) || (Char.IsLetter(contentId[29]) && Char.IsUpper(contentId[29])))
                                                                                                                                                                if ((Char.IsNumber(contentId[30])) || (Char.IsLetter(contentId[30]) && Char.IsUpper(contentId[30])))
                                                                                                                                                                    if ((Char.IsNumber(contentId[31])) || (Char.IsLetter(contentId[31]) && Char.IsUpper(contentId[31])))
                                                                                                                                                                        if ((Char.IsNumber(contentId[32])) || (Char.IsLetter(contentId[32]) && Char.IsUpper(contentId[32])))
                                                                                                                                                                            if ((Char.IsNumber(contentId[33])) || (Char.IsLetter(contentId[33]) && Char.IsUpper(contentId[33])))
                                                                                                                                                                                if ((Char.IsNumber(contentId[34])) || (Char.IsLetter(contentId[34]) && Char.IsUpper(contentId[34])))
                                                                                                                                                                                    if ((Char.IsNumber(contentId[35])) || (Char.IsLetter(contentId[35]) && Char.IsUpper(contentId[35])))
                                                                                                                                                                                        return true;
            return false;




        }

        private bool canMakePkg()
        {
            if (File.Exists(projectPath.Text))
                if (isValidContentId(contentID.Text))
                    return true;
            return false;
        }

        private void reloadIcons()
        {
            IconPreview.BackgroundImage.Dispose();
            IconPreview2.BackgroundImage.Dispose();
            StartupPreview.BackgroundImage.Dispose();

            Image IBG = new Bitmap(iconPath.Text);
            IconPreview.BackgroundImage = IBG;
            IconPreview2.BackgroundImage = IBG;

            Image PBG = new Bitmap(picPath.Text);
            StartupPreview.BackgroundImage = PBG;
        }

        private void GayMakerStudio_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\GayMakerStudio");
                key.SetValue("project", projectPath.Text);
                key.SetValue("icon0", iconPath.Text);
                key.SetValue("pic1", picPath.Text);
                key.SetValue("title", titleName.Text);
                key.SetValue("contentID", contentID.Text);
                key.SetValue("version", VersionSelect.SelectedIndex);
                key.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to save settings to registry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckForUpdates()
        {
            WebClient wc = new WebClient();

            wc.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            String UpdateString = wc.DownloadString("https://raw.githubusercontent.com/KuromeSan/GayMaker-Studio/master/latest.md");
            String[] Data = UpdateString.Split('~');
            if (Data[0] != CurrentVerison)
            {
                DialogResult yesOrNo = MessageBox.Show("An update to GayMaker: Studio was found, Version: " + Data[0] + "\nWant to download it?\n\nThis system software update improves system performance.", "UPDATE FOUND!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (yesOrNo == DialogResult.Yes)
                {
                    DownloadingUpdate updateForm = new DownloadingUpdate();
                    this.Hide();
                    updateForm.ShowDialog();
                    this.Close();
                    this.Dispose();
                }
            }
        }

        private void GayMakerStudio_Load(object sender, EventArgs e)
        {
            this.Text += CurrentVerison;
            ReloadVersions();


            String OldEXEPath = Path.ChangeExtension(Assembly.GetExecutingAssembly().Location,".old");
            if(File.Exists(OldEXEPath))
            {
                File.Delete(OldEXEPath);
            }

            try
            {
                CheckForUpdates();
            }
            catch (Exception) { };



            try
            {
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\GayMakerStudio");

                projectPath.Text = key.GetValue("project").ToString();
                iconPath.Text = key.GetValue("icon0").ToString();
                picPath.Text = key.GetValue("pic1").ToString();
                titleName.Text = key.GetValue("title").ToString();
                contentID.Text = key.GetValue("contentID").ToString();

                int VerIndex = 0;
                int.TryParse(key.GetValue("version").ToString(), out VerIndex);
                VersionSelect.SelectedIndex = VerIndex;

                homeScreen.Checked = true;
                startupScreen.Checked = false;

                homePreview.Visible = true;
                StartupPreview.Visible = false;

                key.Close();

                reloadIcons();
            }
            catch (Exception) { };


            if (!File.Exists(iconPath.Text))
            {
                iconPath.Text = "img\\icon0.png";
            }

            if (!File.Exists(picPath.Text))
            {
                picPath.Text = "img\\pic1.png";
            }

            if (!File.Exists(projectPath.Text))
            {
                projectPath.Text = "(none)";
            }
            else
            {
                GlobalGameSettings.Enabled = true;
            }

            CreatePKG.Enabled = canMakePkg();
        }

        private void titleName_TextChanged(object sender, EventArgs e)
        {
            homeScreen.Checked = true;
            Title.Text = titleName.Text;
        }

        private void homeScreen_CheckedChanged(object sender, EventArgs e)
        {
            homePreview.Visible = true;
            StartupPreview.Visible = false;
        }

        private void startupScreen_CheckedChanged(object sender, EventArgs e)
        {
            homePreview.Visible = false ;
            StartupPreview.Visible = true;
        }

        private void contentID_TextChanged(object sender, EventArgs e)
        {
            if(isValidContentId(contentID.Text))
            {
                titleID.Text = contentID.Text.Substring(7, 9);
            }
            else
            {
                titleID.Text = "(INVALID)";
            }

            CreatePKG.Enabled = canMakePkg();
        }

        private void browseProject_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "GameMaker Studio Project Files|*.project.gmx;*.yyp|GameMaker Studio 1.x Project Files|*.project.gmx|GameMaker Studio 2.x Project Files|*.yyp";
            openFileDialog1.Title = "Select a GameMaker Studio Project File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                titleName.Text = "GameMaker: Studio";
                iconPath.Text = "img\\icon0.png";
                picPath.Text = "img\\pic1.png";
                contentID.Text = "IV0000-GMSP00001_00-GAMEMAKERSTUDIO0";
                projectPath.Text = openFileDialog1.FileName;

                CreatePKG.Enabled = true;
                GlobalGameSettings.Enabled = true;
                reloadIcons();
            }
        }

        private void browseIcon_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Portable Network Graphics|*.PNG";
            openFileDialog1.Title = "Select a PNG File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(openFileDialog1.FileName);
                if (img.Height == 512 && img.Width == 512)
                {
                    IconPreview.BackgroundImage.Dispose();
                    IconPreview2.BackgroundImage.Dispose();

                    IconPreview.BackgroundImage = img;
                    IconPreview2.BackgroundImage = img;

                    homeScreen.Checked = true;
                    iconPath.Text = openFileDialog1.FileName;
                }
                else
                {
                    img.Dispose(); //fix issue #2
                    MessageBox.Show("Image is not 512x512!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void browsePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Portable Network Graphics|*.PNG";
            openFileDialog1.Title = "Select a PNG File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(openFileDialog1.FileName);
                if (img.Height == 1080 && img.Width == 1920)
                {
                    StartupPreview.BackgroundImage.Dispose();
                    StartupPreview.BackgroundImage = img;
                    startupScreen.Checked = true;
                    picPath.Text = openFileDialog1.FileName;
                }
                else
                {
                    img.Dispose(); //fix issue #2
                    MessageBox.Show("Image is not 1920x1080 !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void IconPreview_Click(object sender, EventArgs e)
        {
            startupScreen.Checked = true;
        }

        private void GlobalGameSettings_MouseEnter(object sender, EventArgs e)
        {
            GlobalGameSettings.ForeColor = Color.Blue;
            GlobalGameSettings.Font = new Font(label1.Font.Name, label1.Font.SizeInPoints, FontStyle.Underline);
            this.Cursor = Cursors.Hand;
        }

        private void GlobalGameSettings_MouseLeave(object sender, EventArgs e)
        {
            GlobalGameSettings.ForeColor = Color.Black;
            GlobalGameSettings.Font = new Font(label1.Font.Name, label1.Font.SizeInPoints, FontStyle.Regular);
            this.Cursor = Cursors.Arrow;
        }

        private void GlobalGameSettings_DoubleClick(object sender, EventArgs e)
        {
            GameSettings GlobalGames = new GameSettings();
            GlobalGames.ShowDialog();
        }


        private void CopyDir(string source, string target)
        {
            GmacOut.AppendText("Copying Directory:\n  \"" + source + "\"\n-> \"" + target + "\"\n");

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
                    GmacOut.AppendText("Copying \"" + fileName + "\"\n");
                    File.Copy(sysEntry, targetPath, true);
                }
            }
        }

        private void Make24Bit(string Src, string Dst)
        {
            GmacOut.AppendText("Making " + Src + " 24 bit color depth!");
            Bitmap orig = new Bitmap(Src);
            if ((orig.PixelFormat != PixelFormat.Format24bppRgb))
            {
                Bitmap clone = orig.Clone(new Rectangle(0, 0, orig.Width, orig.Height), PixelFormat.Format24bppRgb);
                clone.Save(@Dst);
                clone.Dispose();
                GmacOut.AppendText(" Done!\n");
            }
            else
            {
                GmacOut.AppendText(" No need!\n");
                File.Copy(Src, Dst);
            }
            orig.Dispose();


        }

        private bool CompileProject(string Src, string Dst)
        {
            string GMVer = VersionSelect.SelectedItem.ToString();


            String TexturePageSize = "1028";
            String SHEnabled = "False";

            if (GMVer.StartsWith("1."))
            {
                XmlDocument DefaultConfig = new XmlDocument();
                DefaultConfig.Load(Path.GetDirectoryName(projectPath.Text) + "\\Configs\\Default.config.gmx");
                TexturePageSize = DefaultConfig.GetElementsByTagName("option_ps4_texture_page")[0].InnerText;
                SHEnabled = DefaultConfig.GetElementsByTagName("option_shortcircuit")[0].InnerText;
            }


            string versionBit = GMVer.Split('.')[2];

            if(GMVer.StartsWith("2."))
            {
                GmacOut.AppendText("Creating license.plist...\n");
                String LicenseFile = GMLicense.LicenseFormat.CreateLicense("ps4", GMLicense.Keys.GetPrivateKey());

                if (!Directory.Exists(Dst+"\\GameMakerLicense"))
                {
                    Directory.CreateDirectory(Dst + "\\GameMakerLicense");
                }

                File.WriteAllText(Dst + "\\GameMakerLicense\\licence.plist",LicenseFile);
                GmacOut.AppendText("Written license file to: " + Dst + "\\GameMakerLicense\\license.plist\n");
            }

            string args;
            if (HasShaders && GMVer.StartsWith("1."))
            {
                args = "/c /m=ps4 /config=\"Default\" /tgt=4294967296 /obob=True /obpp=False /obru=True /obes=False /i=3 /j=4 /cvm /tp=" + TexturePageSize + " /mv=1 /iv=0 /rv=0 /bv=" + versionBit + " /sh="+ SHEnabled+" /ps4sdk=\"" + Directory.GetCurrentDirectory() + "\\ps4sdk\" /gn=\"" + titleName.Text + "\" /o=\"" + Dst + "\" \"" + Src + "\"";
            }
            else if(GMVer.StartsWith("1."))
            {
                args = "/c /m=ps4 /config=\"Default\" /tgt=4294967296 /obob=True /obpp=False /obru=True /obes=False /i=3 /j=4 /cvm /tp=" + TexturePageSize + " /mv=1 /iv=0 /rv=0 /bv=" + versionBit + " /sh=" + SHEnabled + " /gn=\"" + titleName.Text + "\" /o=\"" + Dst + "\" \"" + Src + "\"";
            }
            else if(HasShaders && GMVer.StartsWith("2."))
            {
                args = "/c /zpex /zpuf=\""+Dst + "\\GameMakerLicense\" /baseproject=\"" +Directory.GetCurrentDirectory()+"\\versions\\"+GMVer+ "\\BaseProject\\BaseProject.yyp\" /m=PS4 /config=\"default\" /tgt=4294967296 /obob=True /obpp=False /obru=True /obes=False /i=3 /j=4 /cvm /mv=1 /iv=0 /rv=0 /bv=0 /sh=False /ps4sdk=\"" + Directory.GetCurrentDirectory() + "\\ps4sdk\" /gn=\"" + titleName.Text + "\" /o=\"" + Dst + "\" \"" + Src + "\"";
            }
            else
            {
                args = "/c /zpex /zpuf=\"" + Dst + "\\GameMakerLicense\" /baseproject=\"" + Directory.GetCurrentDirectory() + "\\versions\\" + GMVer + "\\BaseProject\\BaseProject.yyp\" /m=PS4 /config=\"default\" /tgt=4294967296 /obob=True /obpp=False /obru=True /obes=False /i=3 /j=4 /cvm /mv=1 /iv=0 /rv=0 /bv=0 /sh=False /gn=\"" + titleName.Text + "\" /o=\"" + Dst + "\" \"" + Src + "\"";
            }

            GmacOut.AppendText("-- GMASSETCOMPILER BEGIN --\n");

            GmacOut.AppendText("GMAssetCompiler.exe " + args + "\n");
            Process gmac = new Process();
            if (GMVer == "1.4.9999")
            {
                gmac.StartInfo.FileName = "GMAssetCompiler.exe";
            }
            else
            {
                gmac.StartInfo.FileName = "versions\\" + GMVer + "\\GMAssetCompiler.exe";
                gmac.StartInfo.WorkingDirectory = "versions\\" + GMVer;
            }

            gmac.StartInfo.Arguments = args;
            gmac.StartInfo.UseShellExecute = false;
            gmac.StartInfo.CreateNoWindow = true;
            gmac.StartInfo.RedirectStandardOutput = true;
            gmac.StartInfo.RedirectStandardError = true;
            gmac.ErrorDataReceived += new DataReceivedEventHandler(gmacWrite);
            gmac.OutputDataReceived += new DataReceivedEventHandler(gmacWrite);
            GMAC.GetPermissionToExecute();
            gmac.Start();
            gmac.BeginOutputReadLine();
            gmac.BeginErrorReadLine();

            while (!gmac.HasExited)
            {
                Application.DoEvents();
            }
            if (gmac.ExitCode != 0)
            {

                MessageBox.Show("GMAssetCompiler.exe Error Code: " + gmac.ExitCode.ToString(), "GMAC Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Directory.Delete(Dst, true);
                return false;
            }
            gmac.Dispose();
            GmacOut.AppendText("-- GMASSETCOMPILER FINISHED! --\n");

            if (GMVer.StartsWith("2."))
            {
                GmacOut.AppendText("Removing license.plist...");
                File.Delete(Dst + "\\GameMakerLicense\\license.plist");
                Directory.Delete(Dst + "\\GameMakerLicense", true);
                GmacOut.AppendText("OK!\n");
            }

            GmacOut.AppendText("Renaming to game.win...");
            foreach (String file in Directory.GetFiles(Dst))
            {
                if (file.EndsWith(".win"))
                {
                    File.Move(file, Dst + "\\game.win");
                }

                if (file.EndsWith(".yydebug"))
                {
                    File.Delete(file);
                }
            }
            GmacOut.AppendText("OK!\n");
            return true;
        }



        void gmacWrite(object sender, DataReceivedEventArgs e)
        {
            Trace.WriteLine(e.Data);
            this.BeginInvoke(new MethodInvoker(() =>
            {
                GmacOut.AppendText(e.Data + "\n");
            }));
        }

        private void AddFile(Gp4Project proj, string targetPath, string origPath)
        {
            var f = origPath;
            var fileEntry = new Gp4File
            {
                OrigPath = f,
                TargetPath = targetPath + Path.GetFileName(origPath)
            };
            proj.files.Items.Add(fileEntry);
        }

        private void AddFileTree(Gp4Project proj, Dir parent, string path)
        {
            var newDir = proj.AddDir(parent, Path.GetFileName(path));
            foreach (var d in Directory.EnumerateDirectories(path))
            {
                AddFileTree(proj, newDir, d);
            }
            var targetPath = newDir.Path;
            foreach (var f in Directory.EnumerateFiles(path))
            {
                AddFile(proj, targetPath, f);
            }
        }

        private void CreatePKG_Click(object sender, EventArgs e)
        {
            string GMVer = VersionSelect.SelectedItem.ToString();

            if(Path.GetExtension(projectPath.Text).ToLower() == ".yyp" && GMVer.StartsWith("1."))
            {
                MessageBox.Show("Cannot build GMS2 Project using GMS1.4", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(Path.GetExtension(projectPath.Text).ToLower() == ".gmx" && GMVer.StartsWith("2."))
            {
                MessageBox.Show("Cannot build GMS1.4 Project using GMS2", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tempdir = "";

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PS4 Packages|*.PKG";
            saveFileDialog1.Title = "Save PKG File";
            saveFileDialog1.FileName = contentID.Text;
            CreatePKG.Enabled = false;
            
            if(GMVer.StartsWith("1."))
                HasShaders = File.ReadAllText(projectPath.Text).Contains("</shaders>"); //Too lazy to parse XML properly.
            else if(GMVer.StartsWith("2."))
                HasShaders = File.ReadAllText(projectPath.Text).Contains("GMShader"); //Too lazy to parse XML properly.
            if (HasShaders)
            {
                if (!Directory.Exists(@"ps4sdk"))
                {
                    DialogResult msgResult = MessageBox.Show("It's been detected that you are using Shaders in your GM Project\nHowever no copy of the PS4 Shader Compiler (orbis-wave-psslc.exe) was found.\nBrowse to orbis-wave-psslc.exe?", "Shader Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (msgResult == DialogResult.Yes)
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = "orbis-wave-psslc.exe|orbis-wave-psslc.exe";
                        openFileDialog.Title = "Browse to PS4 Shader Compiler.";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {

                            if (!Directory.Exists(@"ps4sdk"))
                            {
                                GmacOut.AppendText("Creating PS4SDK Directory Structure\n");
                                Directory.CreateDirectory("ps4sdk");
                                Directory.CreateDirectory("ps4sdk/host_tools");
                                Directory.CreateDirectory("ps4sdk/host_tools/bin");
                            }
                            File.Copy(openFileDialog.FileName, @"ps4sdk/host_tools/bin/orbis-wave-psslc.exe");

                        }
                        else
                        {
                            CreatePKG.Enabled = true;
                            return;
                        }
                    }
                    else
                    {
                        CreatePKG.Enabled = true;
                        return;
                    }

                }
            }


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tempdir = Path.GetDirectoryName(saveFileDialog1.FileName) + "\\_temp";

                if (Directory.Exists(tempdir))
                {
                    Directory.Delete(tempdir, true);
                }
                Directory.CreateDirectory(tempdir);

                if (GMVer == "1.4.9999")
                {
                    CopyDir(@"Runner", tempdir);
                }
                else
                {
                    CopyDir("versions\\" + GMVer + "\\Runner", tempdir);
                }


                Make24Bit(iconPath.Text, tempdir + "\\sce_sys\\icon0.png");
                Make24Bit(picPath.Text, tempdir + "\\sce_sys\\pic1.png");

                if (!CompileProject(projectPath.Text, tempdir + "\\games"))
                {
                    Directory.Delete(tempdir, true);
                    CreatePKG.Enabled = true;
                    return;
                }
            }
            else
            {
                CreatePKG.Enabled = true;
                return;
            }

            FileStream fd = File.Open(tempdir + "\\sce_sys\\param.sfo", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            GmacOut.AppendText("Writing " + titleName.Text + " to TITLE of param.sfo\n");
            fd.Seek(0x350, SeekOrigin.Begin);
            foreach (Byte by in ASCIIEncoding.ASCII.GetBytes(titleName.Text))
            {
                fd.WriteByte(by);
            }


            GmacOut.AppendText("Writing " + titleID.Text + " to TITLE_ID of param.sfo\n");
            fd.Seek(0x3D0, SeekOrigin.Begin);
            foreach (Byte by in ASCIIEncoding.ASCII.GetBytes(titleID.Text))
            {
                fd.WriteByte(by);
            }

            GmacOut.AppendText("Writing " + contentID.Text + " to CONTENT_ID of param.sfo!\n");
            fd.Seek(0x284, SeekOrigin.Begin);
            foreach (Byte by in ASCIIEncoding.ASCII.GetBytes(contentID.Text))
            {
                fd.WriteByte(by);
            }
            fd.Close();


            GmacOut.AppendText("Creating GP4 ...");

            Gp4Project proj = Gp4Project.Create(VolumeType.pkg_ps4_app);
            Dir root = null;
            foreach (var file in Directory.GetFileSystemEntries(tempdir))
            {
                if (File.Exists(file))
                {
                    AddFile(proj, "", file);
                }
                else if (Directory.Exists(file))
                {
                    AddFileTree(proj, root, file);
                }
            }

            proj.volume.Package.ContentId = contentID.Text;
            proj.volume.Package.Passcode = "00000000000000000000000000000000";

            GmacOut.AppendText("OK!\n");


            if (File.Exists(saveFileDialog1.FileName))
            {
                File.Delete(saveFileDialog1.FileName);
            }

            GmacOut.AppendText("Building PKG ...");
            Thread thr = new Thread(() =>
            {
                PkgBuilder pkg = new PkgBuilder(PkgProperties.FromGp4(proj, ""));
                pkg.Write(saveFileDialog1.FileName);
            });
            thr.Start();

            while (thr.IsAlive)
            {
                Application.DoEvents();
            }

            GmacOut.AppendText("OK!\n");



            GmacOut.AppendText("Deleting " + tempdir + " ...");
            Directory.Delete(tempdir, true);
            GmacOut.AppendText("OK!\n");

            GmacOut.AppendText("Done!\n");
            CreatePKG.Enabled = true;
            MessageBox.Show("PKG Created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ReloadVersions()
        {
            VersionSelect.Items.Clear();
            VersionSelect.Items.Add("1.4.9999");
            try
            {
                foreach (String version in Directory.GetDirectories(@"versions"))
                {
                    VersionSelect.Items.Add(Path.GetFileName(version));
                }
            }
            catch (Exception) { };

            VersionSelect.Items.Add("Manager");

            VersionSelect.SelectedIndex = 0;
        }

        private void VersionSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //1.4.9999 comes built in

            if(VersionSelect.Text.StartsWith("1."))
            {
                GameSettings.Enabled = true;
            }
            else
            {
                GlobalGameSettings.Enabled = false;
            }

            if (VersionSelect.SelectedItem.ToString() == "Manager")
            {
                VersionSelect.SelectedIndex -= 1;
                this.Enabled = false;
                VersionManager VM = new VersionManager();
                VM.Show();
                VM.FormClosing += VM_FormClosing;
            }
        }

        private void VM_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Enabled = true;
            ReloadVersions();
            this.Focus();
        }


    }
}
