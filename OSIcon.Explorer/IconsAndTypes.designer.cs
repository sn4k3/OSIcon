namespace OSIcon.Explorer
{
    partial class IconsAndTypes
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbExtensions = new System.Windows.Forms.ListBox();
            this.chbIconSizeLarge = new System.Windows.Forms.RadioButton();
            this.chbIconSizeSmall = new System.Windows.Forms.RadioButton();
            this.gbIconSize = new System.Windows.Forms.GroupBox();
            this.chbIconSizeJumbo = new System.Windows.Forms.RadioButton();
            this.chbIconSizeExtraLarge = new System.Windows.Forms.RadioButton();
            this.pbIconPreview = new System.Windows.Forms.PictureBox();
            this.gbPreview = new System.Windows.Forms.GroupBox();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.lbLoadTime = new System.Windows.Forms.Label();
            this.lbFileType = new System.Windows.Forms.Label();
            this.lbDisplayName = new System.Windows.Forms.Label();
            this.lbIconIndex = new System.Windows.Forms.Label();
            this.lbFile = new System.Windows.Forms.Label();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.pbIconSmall = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbIconLarge = new System.Windows.Forms.PictureBox();
            this.pbIconExtraLarge = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbIconSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconPreview)).BeginInit();
            this.gbPreview.SuspendLayout();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconSmall)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconExtraLarge)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbExtensions
            // 
            this.lbExtensions.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbExtensions.FormattingEnabled = true;
            this.lbExtensions.Location = new System.Drawing.Point(0, 0);
            this.lbExtensions.Name = "lbExtensions";
            this.lbExtensions.Size = new System.Drawing.Size(177, 425);
            this.lbExtensions.TabIndex = 0;
            this.lbExtensions.SelectedIndexChanged += new System.EventHandler(this.lbExtensions_SelectedIndexChanged);
            // 
            // chbIconSizeLarge
            // 
            this.chbIconSizeLarge.AutoSize = true;
            this.chbIconSizeLarge.Checked = true;
            this.chbIconSizeLarge.Location = new System.Drawing.Point(6, 42);
            this.chbIconSizeLarge.Name = "chbIconSizeLarge";
            this.chbIconSizeLarge.Size = new System.Drawing.Size(90, 17);
            this.chbIconSizeLarge.TabIndex = 8;
            this.chbIconSizeLarge.TabStop = true;
            this.chbIconSizeLarge.Text = "Large (32x32)";
            this.chbIconSizeLarge.UseVisualStyleBackColor = true;
            this.chbIconSizeLarge.CheckedChanged += new System.EventHandler(this.IconSize_CheckedChanged);
            // 
            // chbIconSizeSmall
            // 
            this.chbIconSizeSmall.AutoSize = true;
            this.chbIconSizeSmall.Location = new System.Drawing.Point(6, 19);
            this.chbIconSizeSmall.Name = "chbIconSizeSmall";
            this.chbIconSizeSmall.Size = new System.Drawing.Size(91, 17);
            this.chbIconSizeSmall.TabIndex = 7;
            this.chbIconSizeSmall.Text = "Small  (16x16)";
            this.chbIconSizeSmall.UseVisualStyleBackColor = true;
            this.chbIconSizeSmall.CheckedChanged += new System.EventHandler(this.IconSize_CheckedChanged);
            // 
            // gbIconSize
            // 
            this.gbIconSize.Controls.Add(this.chbIconSizeJumbo);
            this.gbIconSize.Controls.Add(this.chbIconSizeExtraLarge);
            this.gbIconSize.Controls.Add(this.chbIconSizeSmall);
            this.gbIconSize.Controls.Add(this.chbIconSizeLarge);
            this.gbIconSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbIconSize.Location = new System.Drawing.Point(183, 52);
            this.gbIconSize.Name = "gbIconSize";
            this.gbIconSize.Size = new System.Drawing.Size(135, 116);
            this.gbIconSize.TabIndex = 9;
            this.gbIconSize.TabStop = false;
            this.gbIconSize.Text = "Icon Size";
            // 
            // chbIconSizeJumbo
            // 
            this.chbIconSizeJumbo.AutoSize = true;
            this.chbIconSizeJumbo.Enabled = false;
            this.chbIconSizeJumbo.Location = new System.Drawing.Point(6, 88);
            this.chbIconSizeJumbo.Name = "chbIconSizeJumbo";
            this.chbIconSizeJumbo.Size = new System.Drawing.Size(106, 17);
            this.chbIconSizeJumbo.TabIndex = 10;
            this.chbIconSizeJumbo.Text = "Jumbo (256x256)";
            this.chbIconSizeJumbo.UseVisualStyleBackColor = true;
            this.chbIconSizeJumbo.CheckedChanged += new System.EventHandler(this.IconSize_CheckedChanged);
            // 
            // chbIconSizeExtraLarge
            // 
            this.chbIconSizeExtraLarge.AutoSize = true;
            this.chbIconSizeExtraLarge.Enabled = false;
            this.chbIconSizeExtraLarge.Location = new System.Drawing.Point(6, 65);
            this.chbIconSizeExtraLarge.Name = "chbIconSizeExtraLarge";
            this.chbIconSizeExtraLarge.Size = new System.Drawing.Size(117, 17);
            this.chbIconSizeExtraLarge.TabIndex = 9;
            this.chbIconSizeExtraLarge.Text = "Extra Large (48x48)";
            this.chbIconSizeExtraLarge.UseVisualStyleBackColor = true;
            this.chbIconSizeExtraLarge.CheckedChanged += new System.EventHandler(this.IconSize_CheckedChanged);
            // 
            // pbIconPreview
            // 
            this.pbIconPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbIconPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbIconPreview.Location = new System.Drawing.Point(3, 16);
            this.pbIconPreview.Name = "pbIconPreview";
            this.pbIconPreview.Size = new System.Drawing.Size(294, 281);
            this.pbIconPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbIconPreview.TabIndex = 1;
            this.pbIconPreview.TabStop = false;
            // 
            // gbPreview
            // 
            this.gbPreview.Controls.Add(this.pbIconPreview);
            this.gbPreview.Location = new System.Drawing.Point(324, 3);
            this.gbPreview.Name = "gbPreview";
            this.gbPreview.Size = new System.Drawing.Size(300, 300);
            this.gbPreview.TabIndex = 10;
            this.gbPreview.TabStop = false;
            this.gbPreview.Text = "Preview";
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.tbSearch);
            this.gbSearch.Location = new System.Drawing.Point(183, 3);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(135, 43);
            this.gbSearch.TabIndex = 11;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search";
            // 
            // tbSearch
            // 
            this.tbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSearch.Location = new System.Drawing.Point(3, 16);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(129, 20);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.Text = ".";
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(183, 174);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(135, 42);
            this.btnReload.TabIndex = 12;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.ButtonClick);
            // 
            // lbLoadTime
            // 
            this.lbLoadTime.AutoSize = true;
            this.lbLoadTime.Location = new System.Drawing.Point(180, 271);
            this.lbLoadTime.Name = "lbLoadTime";
            this.lbLoadTime.Size = new System.Drawing.Size(79, 13);
            this.lbLoadTime.TabIndex = 13;
            this.lbLoadTime.Text = "Loaded in: 0ms";
            // 
            // lbFileType
            // 
            this.lbFileType.AutoSize = true;
            this.lbFileType.Location = new System.Drawing.Point(210, 333);
            this.lbFileType.Name = "lbFileType";
            this.lbFileType.Size = new System.Drawing.Size(96, 13);
            this.lbFileType.TabIndex = 14;
            this.lbFileType.Text = "File Type: Unknow";
            // 
            // lbDisplayName
            // 
            this.lbDisplayName.AutoSize = true;
            this.lbDisplayName.Location = new System.Drawing.Point(188, 355);
            this.lbDisplayName.Name = "lbDisplayName";
            this.lbDisplayName.Size = new System.Drawing.Size(118, 13);
            this.lbDisplayName.TabIndex = 15;
            this.lbDisplayName.Text = "Display Name: Unknow";
            // 
            // lbIconIndex
            // 
            this.lbIconIndex.AutoSize = true;
            this.lbIconIndex.Location = new System.Drawing.Point(204, 377);
            this.lbIconIndex.Name = "lbIconIndex";
            this.lbIconIndex.Size = new System.Drawing.Size(72, 13);
            this.lbIconIndex.TabIndex = 16;
            this.lbIconIndex.Text = "Icon Index: -1";
            // 
            // lbFile
            // 
            this.lbFile.AutoSize = true;
            this.lbFile.Location = new System.Drawing.Point(237, 311);
            this.lbFile.Name = "lbFile";
            this.lbFile.Size = new System.Drawing.Size(69, 13);
            this.lbFile.TabIndex = 17;
            this.lbFile.Text = "File: Unknow";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(183, 226);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(135, 42);
            this.btnSaveImage.TabIndex = 18;
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.ButtonClick);
            // 
            // pbIconSmall
            // 
            this.pbIconSmall.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbIconSmall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbIconSmall.Location = new System.Drawing.Point(3, 16);
            this.pbIconSmall.Name = "pbIconSmall";
            this.pbIconSmall.Size = new System.Drawing.Size(69, 69);
            this.pbIconSmall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbIconSmall.TabIndex = 19;
            this.pbIconSmall.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbIconSmall);
            this.groupBox1.Location = new System.Drawing.Point(630, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(75, 88);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "16x16";
            // 
            // pbIconLarge
            // 
            this.pbIconLarge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbIconLarge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbIconLarge.Location = new System.Drawing.Point(3, 16);
            this.pbIconLarge.Name = "pbIconLarge";
            this.pbIconLarge.Size = new System.Drawing.Size(69, 69);
            this.pbIconLarge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbIconLarge.TabIndex = 20;
            this.pbIconLarge.TabStop = false;
            // 
            // pbIconExtraLarge
            // 
            this.pbIconExtraLarge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbIconExtraLarge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbIconExtraLarge.Location = new System.Drawing.Point(3, 16);
            this.pbIconExtraLarge.Name = "pbIconExtraLarge";
            this.pbIconExtraLarge.Size = new System.Drawing.Size(69, 69);
            this.pbIconExtraLarge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbIconExtraLarge.TabIndex = 21;
            this.pbIconExtraLarge.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pbIconLarge);
            this.groupBox2.Location = new System.Drawing.Point(630, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(75, 88);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "32x32";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pbIconExtraLarge);
            this.groupBox3.Location = new System.Drawing.Point(630, 215);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(75, 88);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "48x48";
            // 
            // IconsAndTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.lbFile);
            this.Controls.Add(this.lbIconIndex);
            this.Controls.Add(this.lbDisplayName);
            this.Controls.Add(this.lbFileType);
            this.Controls.Add(this.lbLoadTime);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.gbPreview);
            this.Controls.Add(this.gbIconSize);
            this.Controls.Add(this.lbExtensions);
            this.Name = "IconsAndTypes";
            this.Size = new System.Drawing.Size(711, 425);
            this.gbIconSize.ResumeLayout(false);
            this.gbIconSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconPreview)).EndInit();
            this.gbPreview.ResumeLayout(false);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconSmall)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIconLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconExtraLarge)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbExtensions;
        private System.Windows.Forms.RadioButton chbIconSizeLarge;
        private System.Windows.Forms.RadioButton chbIconSizeSmall;
        private System.Windows.Forms.GroupBox gbIconSize;
        private System.Windows.Forms.PictureBox pbIconPreview;
        private System.Windows.Forms.GroupBox gbPreview;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label lbLoadTime;
        private System.Windows.Forms.RadioButton chbIconSizeJumbo;
        private System.Windows.Forms.RadioButton chbIconSizeExtraLarge;
        private System.Windows.Forms.Label lbFileType;
        private System.Windows.Forms.Label lbDisplayName;
        private System.Windows.Forms.Label lbIconIndex;
        private System.Windows.Forms.Label lbFile;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.PictureBox pbIconSmall;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbIconExtraLarge;
        private System.Windows.Forms.PictureBox pbIconLarge;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
