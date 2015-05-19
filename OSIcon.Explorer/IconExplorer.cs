/*
 * OSIcon
 * Author: Tiago Conceição
 * 
 * https://github.com/sn4k3/OSIcon
 * http://www.codeproject.com/Articles/50064/OSIcon
 */
using System;
using System.Windows.Forms;

namespace OSIcon.Explorer
{
    public partial class IconExplorer : UserControl
    {
        #region Constructor
        public IconExplorer()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void ButtonClick(object sender, EventArgs e)
        {
            if(sender == btnOpen)
            {
                using(OpenFileDialog openFile = new OpenFileDialog())
                {
                    openFile.RestoreDirectory = true;
                    openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.System);
                    openFile.FileName = "shell32.dll";
                    if (openFile.ShowDialog() == DialogResult.OK) LoadIcons(openFile.FileName);
                }
                return;
            }
        }
        #endregion

        #region Methods
        private void LoadIcons(string filename)
        {
            tbFilename.Text = filename;
            var icons = IconReader.ExtractIconsFromFile(filename, true);
            if(icons.Length == 0) return;
            imageList.Images.Clear();
            trIcons.BeginUpdate();
            trIcons.Nodes.Clear();
            for (int i = 0; i < icons.Length; i++)
            {
                imageList.Images.Add(i.ToString(), icons[i]);
                trIcons.Nodes.Add(i.ToString(), string.Format("Icon {0}", i), i, i);
            }
            trIcons.EndUpdate();
        }
        #endregion
    }
}
