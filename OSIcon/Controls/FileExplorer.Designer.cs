namespace OSIcon.Controls
{
    partial class FileExplorer
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
            this.lvFileExplorer = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lbTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.tbAddress = new System.Windows.Forms.ToolStripTextBox();
            this.ddViewStyle = new System.Windows.Forms.ToolStripComboBox();
            this.btnNavigationHistory = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnGoBack = new System.Windows.Forms.ToolStripButton();
            this.btnGoForward = new System.Windows.Forms.ToolStripButton();
            this.btnGoUp = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.statusBar.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvFileExplorer
            // 
            this.lvFileExplorer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chModified,
            this.chType,
            this.chSize});
            this.lvFileExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFileExplorer.FullRowSelect = true;
            this.lvFileExplorer.LabelEdit = true;
            this.lvFileExplorer.Location = new System.Drawing.Point(0, 25);
            this.lvFileExplorer.Name = "lvFileExplorer";
            this.lvFileExplorer.Size = new System.Drawing.Size(670, 277);
            this.lvFileExplorer.TabIndex = 6;
            this.lvFileExplorer.UseCompatibleStateImageBehavior = false;
            this.lvFileExplorer.View = System.Windows.Forms.View.Details;
            this.lvFileExplorer.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvFileExplorer_AfterLabelEdit);
            this.lvFileExplorer.ItemActivate += new System.EventHandler(this.lvFileExplorer_ItemActivate);
            this.lvFileExplorer.SelectedIndexChanged += new System.EventHandler(this.lvFileExplorer_SelectedIndexChanged);
            this.lvFileExplorer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvFileExplorer_KeyDown);
            this.lvFileExplorer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvFileExplorer_MouseUp);
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 200;
            // 
            // chModified
            // 
            this.chModified.Text = "Modified";
            this.chModified.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chModified.Width = 120;
            // 
            // chType
            // 
            this.chType.Text = "Type";
            this.chType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chType.Width = 150;
            // 
            // chSize
            // 
            this.chSize.Text = "Size";
            this.chSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chSize.Width = 150;
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbTotal,
            this.lbSelected});
            this.statusBar.Location = new System.Drawing.Point(0, 302);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(670, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 8;
            this.statusBar.Text = "Status Bar";
            // 
            // lbTotal
            // 
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(327, 17);
            this.lbTotal.Spring = true;
            this.lbTotal.Text = "Total";
            // 
            // lbSelected
            // 
            this.lbSelected.Name = "lbSelected";
            this.lbSelected.Size = new System.Drawing.Size(327, 17);
            this.lbSelected.Spring = true;
            // 
            // toolBar
            // 
            this.toolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGoBack,
            this.btnGoForward,
            this.btnNavigationHistory,
            this.btnGoUp,
            this.tbAddress,
            this.btnRefresh,
            this.ddViewStyle});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(670, 25);
            this.toolBar.TabIndex = 7;
            this.toolBar.Text = "Toolbar";
            // 
            // tbAddress
            // 
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.ReadOnly = true;
            this.tbAddress.Size = new System.Drawing.Size(400, 25);
            // 
            // ddViewStyle
            // 
            this.ddViewStyle.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ddViewStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddViewStyle.Items.AddRange(new object[] {
            "Large Icons",
            "Details",
            "Small Icons",
            "List",
            "Title"});
            this.ddViewStyle.Name = "ddViewStyle";
            this.ddViewStyle.Size = new System.Drawing.Size(121, 25);
            this.ddViewStyle.SelectedIndexChanged += new System.EventHandler(this.ddViewStyle_SelectedIndexChanged);
            // 
            // btnNavigationHistory
            // 
            this.btnNavigationHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNavigationHistory.Enabled = false;
            this.btnNavigationHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNavigationHistory.Name = "btnNavigationHistory";
            this.btnNavigationHistory.Size = new System.Drawing.Size(13, 22);
            this.btnNavigationHistory.Text = "Recent";
            this.btnNavigationHistory.ToolTipText = "Recent";
            // 
            // btnGoBack
            // 
            this.btnGoBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGoBack.Enabled = false;
            this.btnGoBack.Image = global::OSIcon.Properties.Resources.arrow_left;
            this.btnGoBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(23, 22);
            this.btnGoBack.Text = "Back";
            this.btnGoBack.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnGoForward
            // 
            this.btnGoForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGoForward.Enabled = false;
            this.btnGoForward.Image = global::OSIcon.Properties.Resources.arrow_right;
            this.btnGoForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGoForward.Name = "btnGoForward";
            this.btnGoForward.Size = new System.Drawing.Size(23, 22);
            this.btnGoForward.Text = "Forward";
            this.btnGoForward.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnGoUp
            // 
            this.btnGoUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGoUp.Enabled = false;
            this.btnGoUp.Image = global::OSIcon.Properties.Resources.arrow_up;
            this.btnGoUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGoUp.Name = "btnGoUp";
            this.btnGoUp.Size = new System.Drawing.Size(23, 22);
            this.btnGoUp.Text = "Up";
            this.btnGoUp.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::OSIcon.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.ButtonClick);
            // 
            // FileExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvFileExplorer);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.toolBar);
            this.Name = "FileExplorer";
            this.Size = new System.Drawing.Size(670, 324);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chSize;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chModified;
        public System.Windows.Forms.ListView lvFileExplorer;
        public System.Windows.Forms.ToolStripStatusLabel lbSelected;
        public System.Windows.Forms.ToolStripStatusLabel lbTotal;
        public System.Windows.Forms.ToolStripTextBox tbAddress;
        public System.Windows.Forms.ToolStripComboBox ddViewStyle;
        public System.Windows.Forms.StatusStrip statusBar;
        public System.Windows.Forms.ToolStrip toolBar;
        public System.Windows.Forms.ToolStripButton btnGoBack;
        public System.Windows.Forms.ToolStripButton btnGoForward;
        public System.Windows.Forms.ToolStripButton btnGoUp;
        public System.Windows.Forms.ToolStripButton btnRefresh;
        public System.Windows.Forms.ToolStripDropDownButton btnNavigationHistory;
    }
}
