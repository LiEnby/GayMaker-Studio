using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace GayMaker_Studio
{
    public partial class GameSettings : Form
    {

        String ProjectPath;
        XmlDocument DefaultConfig = new XmlDocument();

        public GameSettings()
        {
            //Bypass Windows DPI Scaling
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            InitializeComponent();
        }

        private void GameSettings_Load(object sender, EventArgs e)
        {
            Program.GMS.Enabled = false;

            ProjectPath = Path.GetDirectoryName(Program.GMS.GetProjectPath());
            Console.WriteLine(ProjectPath);
            DefaultConfig.Load(ProjectPath + "\\Configs\\Default.config.gmx");

            XmlNode TP = DefaultConfig.GetElementsByTagName("option_ps4_texture_page")[0];
            XmlNode IT = DefaultConfig.GetElementsByTagName("option_ps4_interpolate")[0];
            XmlNode SC = DefaultConfig.GetElementsByTagName("option_ps4_scale")[0];
            XmlNode DC = DefaultConfig.GetElementsByTagName("option_ps4_displaycursor")[0];


            try
            {
                //If global game settings was never opened then its true/false for some reason
                DisplayCursor.Checked = bool.Parse(DC.InnerText);
                Interporlate.Checked = bool.Parse(IT.InnerText);

            }
            catch
            {
                //Otherwise its -1 / 0 (GM IS WEIRD) 
                if (int.Parse(DC.InnerText) == 0)
                {
                    DisplayCursor.Checked = false;
                }
                else
                {
                    DisplayCursor.Checked = true;
                }

                if (int.Parse(IT.InnerText) == 0)
                {
                    Interporlate.Checked = false;
                }
                else
                {
                    Interporlate.Checked = true;
                }

                if (int.Parse(SC.InnerText) == 0)
                {
                    FullScale.Checked = true;
                    KeepAspect.Checked = false;
                }
                else
                {
                    FullScale.Checked = false;
                    KeepAspect.Checked = true;
                }
            };

            

            TexturePageSize.Text = int.Parse(TP.InnerText).ToString();

        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {

                if (DisplayCursor.Checked)
                {
                    XmlNode DC = DefaultConfig.GetElementsByTagName("option_ps4_displaycursor")[0];
                    DC.InnerText = "-1";
                }
                else
                {
                    XmlNode DC = DefaultConfig.GetElementsByTagName("option_ps4_displaycursor")[0];
                    DC.InnerText = "0";
                }

                if (Interporlate.Checked)
                {
                    XmlNode IT = DefaultConfig.GetElementsByTagName("option_ps4_interpolate")[0];
                    IT.InnerText = "-1";
                }
                else
                {
                    XmlNode IT = DefaultConfig.GetElementsByTagName("option_ps4_interpolate")[0];
                    IT.InnerText = "0";
                }

                if (KeepAspect.Checked)
                {
                    XmlNode SC = DefaultConfig.GetElementsByTagName("option_ps4_scale")[0];
                    SC.InnerText = "-1";
                }
                else
                {
                    XmlNode SC = DefaultConfig.GetElementsByTagName("option_ps4_scale")[0];
                    SC.InnerText = "0";
                }

                XmlNode TP = DefaultConfig.GetElementsByTagName("option_ps4_texture_page")[0];
                TP.InnerText = TexturePageSize.Text;

                XmlWriterSettings settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true };
                XmlWriter writer = XmlWriter.Create(ProjectPath + "\\Configs\\Default.config.gmx", settings);
                DefaultConfig.Save(writer);
                writer.Close();

                }

                catch (Exception)
                {
                    MessageBox.Show("There was an error while saving settings!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                Program.GMS.Enabled = true;

                Close();

        }

        private void GameSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.GMS.Enabled = true;
        }
    }
}