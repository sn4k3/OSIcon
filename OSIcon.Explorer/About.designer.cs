namespace OSIcon.Explorer
{
    partial class About
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
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lbProductName = new System.Windows.Forms.Label();
            this.lbProductVersion = new System.Windows.Forms.Label();
            this.lbLibWWW = new System.Windows.Forms.LinkLabel();
            this.lbAuthor = new System.Windows.Forms.Label();
            this.gbOSIconLibrary = new System.Windows.Forms.GroupBox();
            this.lbOSIconLibraryVersion = new System.Windows.Forms.Label();
            this.gbOSIconExplorer = new System.Windows.Forms.GroupBox();
            this.gbOSIconLibrary.SuspendLayout();
            this.gbOSIconExplorer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(6, 77);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = true;
            this.tbDescription.Size = new System.Drawing.Size(279, 106);
            this.tbDescription.TabIndex = 0;
            // 
            // lbProductName
            // 
            this.lbProductName.AutoSize = true;
            this.lbProductName.Location = new System.Drawing.Point(6, 24);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(75, 13);
            this.lbProductName.TabIndex = 1;
            this.lbProductName.Text = "Product Name";
            // 
            // lbProductVersion
            // 
            this.lbProductVersion.AutoSize = true;
            this.lbProductVersion.Location = new System.Drawing.Point(6, 46);
            this.lbProductVersion.Name = "lbProductVersion";
            this.lbProductVersion.Size = new System.Drawing.Size(82, 13);
            this.lbProductVersion.TabIndex = 2;
            this.lbProductVersion.Text = "Product Version";
            // 
            // lbLibWWW
            // 
            this.lbLibWWW.AutoSize = true;
            this.lbLibWWW.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbLibWWW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLibWWW.Location = new System.Drawing.Point(0, 336);
            this.lbLibWWW.Name = "lbLibWWW";
            this.lbLibWWW.Size = new System.Drawing.Size(94, 15);
            this.lbLibWWW.TabIndex = 4;
            this.lbLibWWW.TabStop = true;
            this.lbLibWWW.Text = "OSIcon Website";
            this.lbLibWWW.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbLibWWW_LinkClicked);
            // 
            // lbAuthor
            // 
            this.lbAuthor.AutoSize = true;
            this.lbAuthor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAuthor.Location = new System.Drawing.Point(6, 51);
            this.lbAuthor.Name = "lbAuthor";
            this.lbAuthor.Size = new System.Drawing.Size(64, 23);
            this.lbAuthor.TabIndex = 5;
            this.lbAuthor.Text = "Author";
            // 
            // gbOSIconLibrary
            // 
            this.gbOSIconLibrary.Controls.Add(this.lbOSIconLibraryVersion);
            this.gbOSIconLibrary.Controls.Add(this.lbAuthor);
            this.gbOSIconLibrary.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbOSIconLibrary.Location = new System.Drawing.Point(0, 189);
            this.gbOSIconLibrary.Name = "gbOSIconLibrary";
            this.gbOSIconLibrary.Size = new System.Drawing.Size(342, 88);
            this.gbOSIconLibrary.TabIndex = 6;
            this.gbOSIconLibrary.TabStop = false;
            this.gbOSIconLibrary.Text = "OSIcon Library";
            // 
            // lbOSIconLibraryVersion
            // 
            this.lbOSIconLibraryVersion.AutoSize = true;
            this.lbOSIconLibraryVersion.Location = new System.Drawing.Point(6, 26);
            this.lbOSIconLibraryVersion.Name = "lbOSIconLibraryVersion";
            this.lbOSIconLibraryVersion.Size = new System.Drawing.Size(42, 13);
            this.lbOSIconLibraryVersion.TabIndex = 6;
            this.lbOSIconLibraryVersion.Text = "Version";
            // 
            // gbOSIconExplorer
            // 
            this.gbOSIconExplorer.Controls.Add(this.lbProductName);
            this.gbOSIconExplorer.Controls.Add(this.lbProductVersion);
            this.gbOSIconExplorer.Controls.Add(this.tbDescription);
            this.gbOSIconExplorer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbOSIconExplorer.Location = new System.Drawing.Point(0, 0);
            this.gbOSIconExplorer.Name = "gbOSIconExplorer";
            this.gbOSIconExplorer.Size = new System.Drawing.Size(342, 189);
            this.gbOSIconExplorer.TabIndex = 7;
            this.gbOSIconExplorer.TabStop = false;
            this.gbOSIconExplorer.Text = "OSIcon Explorer";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbOSIconLibrary);
            this.Controls.Add(this.gbOSIconExplorer);
            this.Controls.Add(this.lbLibWWW);
            this.Name = "About";
            this.Size = new System.Drawing.Size(342, 351);
            this.gbOSIconLibrary.ResumeLayout(false);
            this.gbOSIconLibrary.PerformLayout();
            this.gbOSIconExplorer.ResumeLayout(false);
            this.gbOSIconExplorer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lbProductName;
        private System.Windows.Forms.Label lbProductVersion;
        private System.Windows.Forms.LinkLabel lbLibWWW;
        private System.Windows.Forms.Label lbAuthor;
        private System.Windows.Forms.GroupBox gbOSIconLibrary;
        private System.Windows.Forms.Label lbOSIconLibraryVersion;
        private System.Windows.Forms.GroupBox gbOSIconExplorer;
    }
}
