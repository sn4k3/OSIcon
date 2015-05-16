namespace OSIcon.Explorer
{
    partial class IconExplorer
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trIcons = new System.Windows.Forms.TreeView();
            this.lbFilename = new System.Windows.Forms.Label();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.tbFilename);
            this.panel1.Controls.Add(this.lbFilename);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 37);
            this.panel1.TabIndex = 0;
            // 
            // trIcons
            // 
            this.trIcons.Dock = System.Windows.Forms.DockStyle.Left;
            this.trIcons.ImageIndex = 0;
            this.trIcons.ImageList = this.imageList;
            this.trIcons.Location = new System.Drawing.Point(0, 37);
            this.trIcons.Name = "trIcons";
            this.trIcons.SelectedImageIndex = 0;
            this.trIcons.Size = new System.Drawing.Size(175, 270);
            this.trIcons.TabIndex = 1;
            // 
            // lbFilename
            // 
            this.lbFilename.AutoSize = true;
            this.lbFilename.Location = new System.Drawing.Point(3, 10);
            this.lbFilename.Name = "lbFilename";
            this.lbFilename.Size = new System.Drawing.Size(52, 13);
            this.lbFilename.TabIndex = 0;
            this.lbFilename.Text = "Filename:";
            // 
            // tbFilename
            // 
            this.tbFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilename.Location = new System.Drawing.Point(61, 7);
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.ReadOnly = true;
            this.tbFilename.Size = new System.Drawing.Size(328, 20);
            this.tbFilename.TabIndex = 1;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(395, 5);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(53, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.ButtonClick);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // IconExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trIcons);
            this.Controls.Add(this.panel1);
            this.Name = "IconExplorer";
            this.Size = new System.Drawing.Size(451, 307);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView trIcons;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.Label lbFilename;
        private System.Windows.Forms.ImageList imageList;
    }
}
