
namespace OSIcon.Explorer
{
    partial class Main
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
            this.tabC = new System.Windows.Forms.TabControl();
            this.tbExplorer = new System.Windows.Forms.TabPage();
            this.tbIconAssociations = new System.Windows.Forms.TabPage();
            this.tbTests = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.tbWindowsThumbnails = new System.Windows.Forms.TabPage();
            this.tbIconExplorer = new System.Windows.Forms.TabPage();
            this.tbAbout = new System.Windows.Forms.TabPage();
            this.explorer = new OSIcon.Explorer.Explorer();
            this.iconsAndTypes = new OSIcon.Explorer.IconsAndTypes();
            this.windowsThumbnails = new OSIcon.Explorer.WindowsThumbnails();
            this.iconExplorer = new OSIcon.Explorer.IconExplorer();
            this.about = new OSIcon.Explorer.About();
            this.tabC.SuspendLayout();
            this.tbExplorer.SuspendLayout();
            this.tbIconAssociations.SuspendLayout();
            this.tbTests.SuspendLayout();
            this.tbWindowsThumbnails.SuspendLayout();
            this.tbIconExplorer.SuspendLayout();
            this.tbAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabC
            // 
            this.tabC.Controls.Add(this.tbExplorer);
            this.tabC.Controls.Add(this.tbIconAssociations);
            this.tabC.Controls.Add(this.tbTests);
            this.tabC.Controls.Add(this.tbWindowsThumbnails);
            this.tabC.Controls.Add(this.tbIconExplorer);
            this.tabC.Controls.Add(this.tbAbout);
            this.tabC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabC.Location = new System.Drawing.Point(0, 0);
            this.tabC.Name = "tabC";
            this.tabC.SelectedIndex = 0;
            this.tabC.Size = new System.Drawing.Size(789, 433);
            this.tabC.TabIndex = 0;
            this.tabC.SelectedIndexChanged += new System.EventHandler(this.tabC_SelectedIndexChanged);
            // 
            // tbExplorer
            // 
            this.tbExplorer.Controls.Add(this.explorer);
            this.tbExplorer.Location = new System.Drawing.Point(4, 22);
            this.tbExplorer.Name = "tbExplorer";
            this.tbExplorer.Padding = new System.Windows.Forms.Padding(3);
            this.tbExplorer.Size = new System.Drawing.Size(781, 407);
            this.tbExplorer.TabIndex = 0;
            this.tbExplorer.Text = "Explorer";
            this.tbExplorer.UseVisualStyleBackColor = true;
            // 
            // tbIconAssociations
            // 
            this.tbIconAssociations.Controls.Add(this.iconsAndTypes);
            this.tbIconAssociations.Location = new System.Drawing.Point(4, 22);
            this.tbIconAssociations.Name = "tbIconAssociations";
            this.tbIconAssociations.Padding = new System.Windows.Forms.Padding(3);
            this.tbIconAssociations.Size = new System.Drawing.Size(781, 407);
            this.tbIconAssociations.TabIndex = 1;
            this.tbIconAssociations.Text = "Icon Associations";
            this.tbIconAssociations.UseVisualStyleBackColor = true;
            // 
            // tbTests
            // 
            this.tbTests.Controls.Add(this.listView1);
            this.tbTests.Controls.Add(this.button1);
            this.tbTests.Location = new System.Drawing.Point(4, 22);
            this.tbTests.Name = "tbTests";
            this.tbTests.Padding = new System.Windows.Forms.Padding(3);
            this.tbTests.Size = new System.Drawing.Size(781, 407);
            this.tbTests.TabIndex = 2;
            this.tbTests.Text = "Tests";
            this.tbTests.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Location = new System.Drawing.Point(28, 88);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(493, 276);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 100;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbWindowsThumbnails
            // 
            this.tbWindowsThumbnails.Controls.Add(this.windowsThumbnails);
            this.tbWindowsThumbnails.Location = new System.Drawing.Point(4, 22);
            this.tbWindowsThumbnails.Name = "tbWindowsThumbnails";
            this.tbWindowsThumbnails.Padding = new System.Windows.Forms.Padding(3);
            this.tbWindowsThumbnails.Size = new System.Drawing.Size(781, 407);
            this.tbWindowsThumbnails.TabIndex = 3;
            this.tbWindowsThumbnails.Text = "Windows Thumbnails";
            this.tbWindowsThumbnails.UseVisualStyleBackColor = true;
            // 
            // tbIconExplorer
            // 
            this.tbIconExplorer.Controls.Add(this.iconExplorer);
            this.tbIconExplorer.Location = new System.Drawing.Point(4, 22);
            this.tbIconExplorer.Name = "tbIconExplorer";
            this.tbIconExplorer.Padding = new System.Windows.Forms.Padding(3);
            this.tbIconExplorer.Size = new System.Drawing.Size(781, 407);
            this.tbIconExplorer.TabIndex = 4;
            this.tbIconExplorer.Text = "Icon Explorer";
            this.tbIconExplorer.UseVisualStyleBackColor = true;
            // 
            // tbAbout
            // 
            this.tbAbout.Controls.Add(this.about);
            this.tbAbout.Location = new System.Drawing.Point(4, 22);
            this.tbAbout.Name = "tbAbout";
            this.tbAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tbAbout.Size = new System.Drawing.Size(781, 407);
            this.tbAbout.TabIndex = 5;
            this.tbAbout.Text = "About";
            this.tbAbout.UseVisualStyleBackColor = true;
            // 
            // explorer
            // 
            this.explorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.explorer.Location = new System.Drawing.Point(3, 3);
            this.explorer.Name = "explorer";
            this.explorer.Size = new System.Drawing.Size(775, 401);
            this.explorer.TabIndex = 0;
            // 
            // iconsAndTypes
            // 
            this.iconsAndTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconsAndTypes.Location = new System.Drawing.Point(3, 3);
            this.iconsAndTypes.Name = "iconsAndTypes";
            this.iconsAndTypes.Size = new System.Drawing.Size(775, 401);
            this.iconsAndTypes.TabIndex = 0;
            // 
            // windowsThumbnails
            // 
            this.windowsThumbnails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowsThumbnails.Location = new System.Drawing.Point(3, 3);
            this.windowsThumbnails.Name = "windowsThumbnails";
            this.windowsThumbnails.Size = new System.Drawing.Size(775, 401);
            this.windowsThumbnails.TabIndex = 1;
            // 
            // iconExplorer
            // 
            this.iconExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconExplorer.Location = new System.Drawing.Point(3, 3);
            this.iconExplorer.Name = "iconExplorer";
            this.iconExplorer.Size = new System.Drawing.Size(775, 401);
            this.iconExplorer.TabIndex = 0;
            // 
            // about
            // 
            this.about.Dock = System.Windows.Forms.DockStyle.Fill;
            this.about.Location = new System.Drawing.Point(3, 3);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(775, 401);
            this.about.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 433);
            this.Controls.Add(this.tabC);
            this.MinimumSize = new System.Drawing.Size(740, 471);
            this.Name = "Main";
            this.Text = "OSIcon Explorer";
            this.tabC.ResumeLayout(false);
            this.tbExplorer.ResumeLayout(false);
            this.tbIconAssociations.ResumeLayout(false);
            this.tbTests.ResumeLayout(false);
            this.tbWindowsThumbnails.ResumeLayout(false);
            this.tbIconExplorer.ResumeLayout(false);
            this.tbAbout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabC;
        private System.Windows.Forms.TabPage tbExplorer;
        private System.Windows.Forms.TabPage tbIconAssociations;
        private Explorer explorer;
        private IconsAndTypes iconsAndTypes;
        private System.Windows.Forms.TabPage tbTests;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TabPage tbWindowsThumbnails;
        private WindowsThumbnails windowsThumbnails;
        private System.Windows.Forms.TabPage tbIconExplorer;
        private System.Windows.Forms.TabPage tbAbout;
        private About about;
        private IconExplorer iconExplorer;
    }
}

