using System;
using System.Drawing;
using System.Windows.Forms;

namespace OSIcon.Explorer
{
    public partial class IconExplorer : UserControl
    {
        public IconExplorer()
        {
            InitializeComponent();
        }

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
    }
}
