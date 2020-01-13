namespace GayMaker_Studio
{
    partial class GayMakerStudio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GayMakerStudio));
            this.homeScreen = new System.Windows.Forms.RadioButton();
            this.startupScreen = new System.Windows.Forms.RadioButton();
            this.IconPreview = new System.Windows.Forms.PictureBox();
            this.Title = new System.Windows.Forms.Label();
            this.homePreview = new System.Windows.Forms.Panel();
            this.IconPreview2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GameSettings = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.VersionSelect = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GlobalGameSettings = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.titleName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.titleID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.contentID = new System.Windows.Forms.TextBox();
            this.browsePic = new System.Windows.Forms.Button();
            this.picPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.browseIcon = new System.Windows.Forms.Button();
            this.iconPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.browseProject = new System.Windows.Forms.Button();
            this.projectPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.CreatePKG = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GmacOut = new System.Windows.Forms.TextBox();
            this.StartupPreview = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.IconPreview)).BeginInit();
            this.homePreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconPreview2)).BeginInit();
            this.GameSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // homeScreen
            // 
            this.homeScreen.AutoSize = true;
            this.homeScreen.Location = new System.Drawing.Point(69, 4);
            this.homeScreen.Name = "homeScreen";
            this.homeScreen.Size = new System.Drawing.Size(53, 17);
            this.homeScreen.TabIndex = 0;
            this.homeScreen.TabStop = true;
            this.homeScreen.Text = "Home";
            this.homeScreen.UseVisualStyleBackColor = true;
            this.homeScreen.CheckedChanged += new System.EventHandler(this.homeScreen_CheckedChanged);
            // 
            // startupScreen
            // 
            this.startupScreen.AutoSize = true;
            this.startupScreen.Location = new System.Drawing.Point(128, 4);
            this.startupScreen.Name = "startupScreen";
            this.startupScreen.Size = new System.Drawing.Size(59, 17);
            this.startupScreen.TabIndex = 1;
            this.startupScreen.TabStop = true;
            this.startupScreen.Text = "Startup";
            this.startupScreen.UseVisualStyleBackColor = true;
            this.startupScreen.CheckedChanged += new System.EventHandler(this.startupScreen_CheckedChanged);
            // 
            // IconPreview
            // 
            this.IconPreview.BackColor = System.Drawing.Color.Transparent;
            this.IconPreview.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("IconPreview.BackgroundImage")));
            this.IconPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.IconPreview.Location = new System.Drawing.Point(144, 105);
            this.IconPreview.Name = "IconPreview";
            this.IconPreview.Size = new System.Drawing.Size(165, 166);
            this.IconPreview.TabIndex = 3;
            this.IconPreview.TabStop = false;
            this.IconPreview.Click += new System.EventHandler(this.IconPreview_Click);
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(312, 278);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(292, 23);
            this.Title.TabIndex = 4;
            this.Title.Text = "GameMaker: Studio";
            // 
            // homePreview
            // 
            this.homePreview.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("homePreview.BackgroundImage")));
            this.homePreview.Controls.Add(this.IconPreview2);
            this.homePreview.Controls.Add(this.IconPreview);
            this.homePreview.Controls.Add(this.Title);
            this.homePreview.Location = new System.Drawing.Point(3, 25);
            this.homePreview.Name = "homePreview";
            this.homePreview.Size = new System.Drawing.Size(960, 544);
            this.homePreview.TabIndex = 5;
            // 
            // IconPreview2
            // 
            this.IconPreview2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("IconPreview2.BackgroundImage")));
            this.IconPreview2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.IconPreview2.Location = new System.Drawing.Point(316, 104);
            this.IconPreview2.Name = "IconPreview2";
            this.IconPreview2.Size = new System.Drawing.Size(100, 102);
            this.IconPreview2.TabIndex = 5;
            this.IconPreview2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Preview:";
            // 
            // GameSettings
            // 
            this.GameSettings.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GameSettings.Controls.Add(this.label8);
            this.GameSettings.Controls.Add(this.VersionSelect);
            this.GameSettings.Controls.Add(this.pictureBox1);
            this.GameSettings.Controls.Add(this.GlobalGameSettings);
            this.GameSettings.Controls.Add(this.label7);
            this.GameSettings.Controls.Add(this.titleName);
            this.GameSettings.Controls.Add(this.label6);
            this.GameSettings.Controls.Add(this.titleID);
            this.GameSettings.Controls.Add(this.label5);
            this.GameSettings.Controls.Add(this.contentID);
            this.GameSettings.Controls.Add(this.browsePic);
            this.GameSettings.Controls.Add(this.picPath);
            this.GameSettings.Controls.Add(this.label4);
            this.GameSettings.Controls.Add(this.browseIcon);
            this.GameSettings.Controls.Add(this.iconPath);
            this.GameSettings.Controls.Add(this.label3);
            this.GameSettings.Controls.Add(this.browseProject);
            this.GameSettings.Controls.Add(this.projectPath);
            this.GameSettings.Controls.Add(this.label2);
            this.GameSettings.Location = new System.Drawing.Point(968, 25);
            this.GameSettings.Name = "GameSettings";
            this.GameSettings.Size = new System.Drawing.Size(368, 301);
            this.GameSettings.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(182, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "GM Version:";
            // 
            // VersionSelect
            // 
            this.VersionSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VersionSelect.FormattingEnabled = true;
            this.VersionSelect.Items.AddRange(new object[] {
            "1.4.9999"});
            this.VersionSelect.Location = new System.Drawing.Point(253, 270);
            this.VersionSelect.Name = "VersionSelect";
            this.VersionSelect.Size = new System.Drawing.Size(103, 21);
            this.VersionSelect.TabIndex = 17;
            this.VersionSelect.SelectedIndexChanged += new System.EventHandler(this.VersionSelect_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(6, 272);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 18);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // GlobalGameSettings
            // 
            this.GlobalGameSettings.AutoSize = true;
            this.GlobalGameSettings.Enabled = false;
            this.GlobalGameSettings.Location = new System.Drawing.Point(29, 276);
            this.GlobalGameSettings.Name = "GlobalGameSettings";
            this.GlobalGameSettings.Size = new System.Drawing.Size(109, 13);
            this.GlobalGameSettings.TabIndex = 15;
            this.GlobalGameSettings.Text = "Global Game Settings";
            this.GlobalGameSettings.DoubleClick += new System.EventHandler(this.GlobalGameSettings_DoubleClick);
            this.GlobalGameSettings.MouseEnter += new System.EventHandler(this.GlobalGameSettings_MouseEnter);
            this.GlobalGameSettings.MouseLeave += new System.EventHandler(this.GlobalGameSettings_MouseLeave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Title:";
            // 
            // titleName
            // 
            this.titleName.Location = new System.Drawing.Point(6, 186);
            this.titleName.MaxLength = 40;
            this.titleName.Multiline = true;
            this.titleName.Name = "titleName";
            this.titleName.Size = new System.Drawing.Size(355, 78);
            this.titleName.TabIndex = 13;
            this.titleName.Text = "GameMaker: Studio";
            this.titleName.TextChanged += new System.EventHandler(this.titleName_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Title ID:";
            // 
            // titleID
            // 
            this.titleID.Location = new System.Drawing.Point(262, 147);
            this.titleID.Name = "titleID";
            this.titleID.ReadOnly = true;
            this.titleID.Size = new System.Drawing.Size(100, 20);
            this.titleID.TabIndex = 11;
            this.titleID.Text = "GMSP00001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Content ID:";
            // 
            // contentID
            // 
            this.contentID.Location = new System.Drawing.Point(3, 147);
            this.contentID.MaxLength = 36;
            this.contentID.Name = "contentID";
            this.contentID.Size = new System.Drawing.Size(253, 20);
            this.contentID.TabIndex = 9;
            this.contentID.Text = "IV0000-GMSP00001_00-GAMEMAKERSTUDIO0";
            this.contentID.TextChanged += new System.EventHandler(this.contentID_TextChanged);
            // 
            // browsePic
            // 
            this.browsePic.Location = new System.Drawing.Point(280, 108);
            this.browsePic.Name = "browsePic";
            this.browsePic.Size = new System.Drawing.Size(75, 23);
            this.browsePic.TabIndex = 8;
            this.browsePic.Text = "Browse";
            this.browsePic.UseVisualStyleBackColor = true;
            this.browsePic.Click += new System.EventHandler(this.browsePic_Click);
            // 
            // picPath
            // 
            this.picPath.Location = new System.Drawing.Point(6, 108);
            this.picPath.Name = "picPath";
            this.picPath.ReadOnly = true;
            this.picPath.Size = new System.Drawing.Size(268, 20);
            this.picPath.TabIndex = 7;
            this.picPath.Text = "img\\pic1.png";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Pic1.png (PNG 1920x1080):";
            // 
            // browseIcon
            // 
            this.browseIcon.Location = new System.Drawing.Point(280, 66);
            this.browseIcon.Name = "browseIcon";
            this.browseIcon.Size = new System.Drawing.Size(75, 23);
            this.browseIcon.TabIndex = 5;
            this.browseIcon.Text = "Browse";
            this.browseIcon.UseVisualStyleBackColor = true;
            this.browseIcon.Click += new System.EventHandler(this.browseIcon_Click);
            // 
            // iconPath
            // 
            this.iconPath.Location = new System.Drawing.Point(6, 69);
            this.iconPath.Name = "iconPath";
            this.iconPath.ReadOnly = true;
            this.iconPath.Size = new System.Drawing.Size(268, 20);
            this.iconPath.TabIndex = 4;
            this.iconPath.Text = "img\\icon0.png";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Icon0.png (PNG 512x512):";
            // 
            // browseProject
            // 
            this.browseProject.Location = new System.Drawing.Point(280, 28);
            this.browseProject.Name = "browseProject";
            this.browseProject.Size = new System.Drawing.Size(75, 23);
            this.browseProject.TabIndex = 2;
            this.browseProject.Text = "Browse";
            this.browseProject.UseVisualStyleBackColor = true;
            this.browseProject.Click += new System.EventHandler(this.browseProject_Click);
            // 
            // projectPath
            // 
            this.projectPath.Location = new System.Drawing.Point(6, 30);
            this.projectPath.Name = "projectPath";
            this.projectPath.ReadOnly = true;
            this.projectPath.Size = new System.Drawing.Size(268, 20);
            this.projectPath.TabIndex = 1;
            this.projectPath.Text = "(none)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Project File (.gmx / .yyp):";
            // 
            // Logo
            // 
            this.Logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Logo.BackgroundImage")));
            this.Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Logo.Location = new System.Drawing.Point(1022, 332);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(257, 206);
            this.Logo.TabIndex = 8;
            this.Logo.TabStop = false;
            // 
            // CreatePKG
            // 
            this.CreatePKG.Enabled = false;
            this.CreatePKG.Location = new System.Drawing.Point(1022, 544);
            this.CreatePKG.Name = "CreatePKG";
            this.CreatePKG.Size = new System.Drawing.Size(257, 23);
            this.CreatePKG.TabIndex = 9;
            this.CreatePKG.Text = "Make PKG";
            this.CreatePKG.UseVisualStyleBackColor = true;
            this.CreatePKG.Click += new System.EventHandler(this.CreatePKG_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.GmacOut);
            this.panel1.Location = new System.Drawing.Point(3, 573);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1333, 107);
            this.panel1.TabIndex = 10;
            // 
            // GmacOut
            // 
            this.GmacOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GmacOut.Location = new System.Drawing.Point(0, 0);
            this.GmacOut.Multiline = true;
            this.GmacOut.Name = "GmacOut";
            this.GmacOut.ReadOnly = true;
            this.GmacOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GmacOut.Size = new System.Drawing.Size(1329, 103);
            this.GmacOut.TabIndex = 0;
            // 
            // StartupPreview
            // 
            this.StartupPreview.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StartupPreview.BackgroundImage")));
            this.StartupPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StartupPreview.Location = new System.Drawing.Point(3, 25);
            this.StartupPreview.Name = "StartupPreview";
            this.StartupPreview.Size = new System.Drawing.Size(960, 544);
            this.StartupPreview.TabIndex = 6;
            // 
            // GayMakerStudio
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1344, 691);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CreatePKG);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.GameSettings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startupScreen);
            this.Controls.Add(this.homeScreen);
            this.Controls.Add(this.homePreview);
            this.Controls.Add(this.StartupPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GayMakerStudio";
            this.Text = "GayMaker: Studio v";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GayMakerStudio_FormClosing);
            this.Load += new System.EventHandler(this.GayMakerStudio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IconPreview)).EndInit();
            this.homePreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IconPreview2)).EndInit();
            this.GameSettings.ResumeLayout(false);
            this.GameSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton homeScreen;
        private System.Windows.Forms.RadioButton startupScreen;
        private System.Windows.Forms.PictureBox IconPreview;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Panel homePreview;
        private System.Windows.Forms.PictureBox IconPreview2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel GameSettings;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Button CreatePKG;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox GmacOut;
        private System.Windows.Forms.Button browseProject;
        private System.Windows.Forms.TextBox projectPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button browseIcon;
        private System.Windows.Forms.TextBox iconPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox titleName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox titleID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox contentID;
        private System.Windows.Forms.Button browsePic;
        private System.Windows.Forms.TextBox picPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel StartupPreview;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label GlobalGameSettings;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox VersionSelect;
    }
}

