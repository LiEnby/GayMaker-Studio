namespace GayMaker_Studio
{
    partial class VersionManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionManager));
            this.label1 = new System.Windows.Forms.Label();
            this.DownloadList = new System.Windows.Forms.ListBox();
            this.DownloadProgress = new System.Windows.Forms.ProgressBar();
            this.StatusText = new System.Windows.Forms.Label();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DownloadedList = new System.Windows.Forms.ListBox();
            this.DeleteVersion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Downloads:";
            // 
            // DownloadList
            // 
            this.DownloadList.FormattingEnabled = true;
            this.DownloadList.Location = new System.Drawing.Point(12, 25);
            this.DownloadList.Name = "DownloadList";
            this.DownloadList.Size = new System.Drawing.Size(461, 186);
            this.DownloadList.TabIndex = 1;
            // 
            // DownloadProgress
            // 
            this.DownloadProgress.Location = new System.Drawing.Point(12, 262);
            this.DownloadProgress.Name = "DownloadProgress";
            this.DownloadProgress.Size = new System.Drawing.Size(461, 23);
            this.DownloadProgress.TabIndex = 2;
            // 
            // StatusText
            // 
            this.StatusText.AutoSize = true;
            this.StatusText.Location = new System.Drawing.Point(9, 246);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(52, 13);
            this.StatusText.TabIndex = 3;
            this.StatusText.Text = "Waiting...";
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(12, 220);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(461, 23);
            this.DownloadButton.TabIndex = 4;
            this.DownloadButton.Text = "Download This Version";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Allready Downloaded:";
            // 
            // DownloadedList
            // 
            this.DownloadedList.FormattingEnabled = true;
            this.DownloadedList.Items.AddRange(new object[] {
            "1.4.9999"});
            this.DownloadedList.Location = new System.Drawing.Point(12, 304);
            this.DownloadedList.Name = "DownloadedList";
            this.DownloadedList.Size = new System.Drawing.Size(461, 199);
            this.DownloadedList.TabIndex = 6;
            // 
            // DeleteVersion
            // 
            this.DeleteVersion.Location = new System.Drawing.Point(12, 509);
            this.DeleteVersion.Name = "DeleteVersion";
            this.DeleteVersion.Size = new System.Drawing.Size(461, 23);
            this.DeleteVersion.TabIndex = 7;
            this.DeleteVersion.Text = "Delete This Version";
            this.DeleteVersion.UseVisualStyleBackColor = true;
            this.DeleteVersion.Click += new System.EventHandler(this.DeleteVersion_Click);
            // 
            // VersionManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(485, 544);
            this.Controls.Add(this.DeleteVersion);
            this.Controls.Add(this.DownloadedList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.DownloadProgress);
            this.Controls.Add(this.DownloadList);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VersionManager";
            this.ShowInTaskbar = false;
            this.Text = "GameMaker Studio Version Manager";
            this.Load += new System.EventHandler(this.VersionManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox DownloadList;
        private System.Windows.Forms.ProgressBar DownloadProgress;
        private System.Windows.Forms.Label StatusText;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox DownloadedList;
        private System.Windows.Forms.Button DeleteVersion;
    }
}