namespace OSIcon.Explorer
{
    partial class WindowsThumbnails
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
            this.lbSelectaWindow = new System.Windows.Forms.Label();
            this.cbWindows = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pbOutput = new System.Windows.Forms.PictureBox();
            this.tbOpacity = new System.Windows.Forms.TrackBar();
            this.lbRequirements = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // lbSelectaWindow
            // 
            this.lbSelectaWindow.AutoSize = true;
            this.lbSelectaWindow.Location = new System.Drawing.Point(13, 16);
            this.lbSelectaWindow.Name = "lbSelectaWindow";
            this.lbSelectaWindow.Size = new System.Drawing.Size(88, 13);
            this.lbSelectaWindow.TabIndex = 0;
            this.lbSelectaWindow.Text = "Select a window:";
            // 
            // cbWindows
            // 
            this.cbWindows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWindows.FormattingEnabled = true;
            this.cbWindows.Location = new System.Drawing.Point(107, 13);
            this.cbWindows.Name = "cbWindows";
            this.cbWindows.Size = new System.Drawing.Size(366, 21);
            this.cbWindows.TabIndex = 1;
            this.cbWindows.SelectedIndexChanged += new System.EventHandler(this.cbWindows_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(479, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.ButtonClick);
            // 
            // pbOutput
            // 
            this.pbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbOutput.Location = new System.Drawing.Point(16, 68);
            this.pbOutput.Name = "pbOutput";
            this.pbOutput.Size = new System.Drawing.Size(538, 251);
            this.pbOutput.TabIndex = 3;
            this.pbOutput.TabStop = false;
            // 
            // tbOpacity
            // 
            this.tbOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOpacity.Location = new System.Drawing.Point(16, 325);
            this.tbOpacity.Maximum = 255;
            this.tbOpacity.Name = "tbOpacity";
            this.tbOpacity.Size = new System.Drawing.Size(538, 45);
            this.tbOpacity.TabIndex = 4;
            this.tbOpacity.Value = 255;
            this.tbOpacity.Scroll += new System.EventHandler(this.tbOpacity_Scroll);
            // 
            // lbRequirements
            // 
            this.lbRequirements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRequirements.AutoSize = true;
            this.lbRequirements.Font = new System.Drawing.Font("Lucida Sans", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRequirements.ForeColor = System.Drawing.Color.Red;
            this.lbRequirements.Location = new System.Drawing.Point(30, 173);
            this.lbRequirements.Name = "lbRequirements";
            this.lbRequirements.Size = new System.Drawing.Size(506, 33);
            this.lbRequirements.TabIndex = 5;
            this.lbRequirements.Text = "Windows Vista or above feature";
            this.lbRequirements.Visible = false;
            // 
            // WindowsThumbnails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbRequirements);
            this.Controls.Add(this.pbOutput);
            this.Controls.Add(this.tbOpacity);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cbWindows);
            this.Controls.Add(this.lbSelectaWindow);
            this.Name = "WindowsThumbnails";
            this.Size = new System.Drawing.Size(574, 373);
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSelectaWindow;
        private System.Windows.Forms.ComboBox cbWindows;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.PictureBox pbOutput;
        private System.Windows.Forms.TrackBar tbOpacity;
        private System.Windows.Forms.Label lbRequirements;
    }
}
