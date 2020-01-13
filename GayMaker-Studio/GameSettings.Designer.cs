namespace GayMaker_Studio
{
    partial class GameSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TexturePageSize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DisplayCursor = new System.Windows.Forms.CheckBox();
            this.Interporlate = new System.Windows.Forms.CheckBox();
            this.FullScale = new System.Windows.Forms.RadioButton();
            this.KeepAspect = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Global Game Settings:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.TexturePageSize);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.DisplayCursor);
            this.panel1.Controls.Add(this.Interporlate);
            this.panel1.Controls.Add(this.FullScale);
            this.panel1.Controls.Add(this.KeepAspect);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 167);
            this.panel1.TabIndex = 1;
            // 
            // TexturePageSize
            // 
            this.TexturePageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TexturePageSize.FormattingEnabled = true;
            this.TexturePageSize.Items.AddRange(new object[] {
            "256",
            "512",
            "1024",
            "2048",
            "4096",
            "8192",
            "16384"});
            this.TexturePageSize.Location = new System.Drawing.Point(6, 74);
            this.TexturePageSize.Name = "TexturePageSize";
            this.TexturePageSize.Size = new System.Drawing.Size(94, 21);
            this.TexturePageSize.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Texture Page Size:";
            // 
            // DisplayCursor
            // 
            this.DisplayCursor.AutoSize = true;
            this.DisplayCursor.Location = new System.Drawing.Point(3, 38);
            this.DisplayCursor.Name = "DisplayCursor";
            this.DisplayCursor.Size = new System.Drawing.Size(201, 17);
            this.DisplayCursor.TabIndex = 4;
            this.DisplayCursor.Text = "Display cursor when touchpad active";
            this.DisplayCursor.UseVisualStyleBackColor = true;
            // 
            // Interporlate
            // 
            this.Interporlate.AutoSize = true;
            this.Interporlate.Location = new System.Drawing.Point(3, 15);
            this.Interporlate.Name = "Interporlate";
            this.Interporlate.Size = new System.Drawing.Size(183, 17);
            this.Interporlate.TabIndex = 3;
            this.Interporlate.Text = "Interporlate colors between pixels";
            this.Interporlate.UseVisualStyleBackColor = true;
            // 
            // FullScale
            // 
            this.FullScale.AutoSize = true;
            this.FullScale.Location = new System.Drawing.Point(3, 143);
            this.FullScale.Name = "FullScale";
            this.FullScale.Size = new System.Drawing.Size(71, 17);
            this.FullScale.TabIndex = 2;
            this.FullScale.TabStop = true;
            this.FullScale.Text = "Full Scale";
            this.FullScale.UseVisualStyleBackColor = true;
            // 
            // KeepAspect
            // 
            this.KeepAspect.AutoSize = true;
            this.KeepAspect.Location = new System.Drawing.Point(3, 120);
            this.KeepAspect.Name = "KeepAspect";
            this.KeepAspect.Size = new System.Drawing.Size(114, 17);
            this.KeepAspect.TabIndex = 1;
            this.KeepAspect.TabStop = true;
            this.KeepAspect.Text = "Keep Aspect Ratio";
            this.KeepAspect.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Scaling Options:";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(12, 198);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(238, 23);
            this.Save.TabIndex = 2;
            this.Save.Text = "Save Changes";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 230);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameSettings";
            this.Text = "Global Game Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameSettings_FormClosing);
            this.Load += new System.EventHandler(this.GameSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox TexturePageSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox DisplayCursor;
        private System.Windows.Forms.CheckBox Interporlate;
        private System.Windows.Forms.RadioButton FullScale;
        private System.Windows.Forms.RadioButton KeepAspect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Save;
    }
}