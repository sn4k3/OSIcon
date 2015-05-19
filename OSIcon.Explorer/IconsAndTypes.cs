/*
 * OSIcon
 * Author: Tiago Conceição
 * 
 * https://github.com/sn4k3/OSIcon
 * http://www.codeproject.com/Articles/50064/OSIcon
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OSIcon.Explorer
{
    public partial class IconsAndTypes : UserControl
    {
        #region Variables
        /// <summary>
        /// Icon dictionary
        /// </summary>
        private Dictionary<string, string> _iconList;
        #endregion

        #region Constructor
        public IconsAndTypes()
        {
            InitializeComponent();
        }
        #endregion

        #region Overrides
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Extra Large icon size was introduced on XP and above so:
            if(Utilities.IsXpOrAbove())
                chbIconSizeExtraLarge.Enabled = true;
            // Jumbo icon size was introduced on Vista and above so:
            if (Utilities.IsVistaOrAbove())
            {
                chbIconSizeJumbo.Enabled = true;
                chbIconSizeJumbo.Checked = true;
            }
            // Populate List with all available extensions
            PopulateList();
        }
        #endregion

        #region Methods
        // Populate list with all known extensions
        private void PopulateList()
        {
            // Start profile function
            DateTime dt = DateTime.Now;
            // Get all available extensions
            _iconList = IconReader.GetFileTypeAndIcon();
            // Clear list
            lbExtensions.BeginUpdate();
            lbExtensions.Items.Clear();
            // Populate list
            foreach (var list in _iconList)
                lbExtensions.Items.Add(list.Key);
            lbExtensions.EndUpdate();
            // Draw Initial image for preview
            ResetPictureBox();
            //  End profiling and show
            lbLoadTime.Text = string.Format("Loaded in: {0}ms", (DateTime.Now - dt).TotalMilliseconds);
        }

        private void ResetPictureBox()
        {
            pbIconPreview.Image = pbIconPreview.InitialImage;
            pbIconSmall.Image = pbIconSmall.InitialImage;
            pbIconLarge.Image = pbIconLarge.InitialImage;
            pbIconExtraLarge.Image = pbIconExtraLarge.InitialImage;
        }

        // Use that to show icon error image and set labels text
        private void SetError()
        {
            pbIconPreview.Image = pbIconPreview.ErrorImage;
            lbFileType.Text = @"File Type: Unknown";
            lbDisplayName.Text = @"Display Name: Unknown";
            lbIconIndex.Text = @"Icon Index: -1";
        }
        #endregion

        #region Events

        // Change image for extension
        private void lbExtensions_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No selected extension
            if (lbExtensions.SelectedIndex < 0)
            {
                pbIconPreview.Image = pbIconPreview.ErrorImage;
                return;
            }
            // extension exist in our dictionary?
            var extension = lbExtensions.SelectedItem.ToString();
            if (!_iconList.ContainsKey(extension))
            {
                pbIconPreview.Image = pbIconPreview.ErrorImage;
                return;
            }
            var iconsize = IconSize.Small;
            // Define selected icon size
            if (chbIconSizeLarge.Checked)
                iconsize = IconSize.Large;
            else if (chbIconSizeExtraLarge.Checked)
                iconsize = IconSize.ExtraLarge;
            else if (chbIconSizeJumbo.Checked)
                iconsize = IconSize.Jumbo;
            // Extract icon from file
            var iconInfo = IconReader.ExtractIconFromFileEx(_iconList[extension], iconsize);
            if (iconInfo == null)
            {
                SetError();
                return;
            }
            lbFile.Text = string.Format("File: {0}", _iconList[extension]);
            lbFileType.Text = string.Format("File Type: {0}", iconInfo.TypeName);
            lbDisplayName.Text = string.Format("Display Name: {0}", iconInfo.DisplayName);
            lbIconIndex.Text = string.Format("Icon Index: {0}", iconInfo.Index);
            // Draw icon
            pbIconPreview.Image = iconInfo.Icon.ToBitmap();

            var iconInfoSmall = IconReader.ExtractIconFromFileEx(_iconList[extension], IconSize.Small);
            if (iconInfoSmall != null)
            {
                pbIconSmall.Image = iconInfoSmall.Bitmap;
            }

            
            var iconInfoLarge = IconReader.ExtractIconFromFileEx(_iconList[extension], IconSize.Large);
            if (iconInfoLarge != null)
            {
                pbIconLarge.Image = iconInfoLarge.Bitmap;
            }

            if (chbIconSizeExtraLarge.Enabled)
            {
                var iconInfoExtraLarge = IconReader.ExtractIconFromFileEx(_iconList[extension], IconSize.ExtraLarge);
                if (iconInfoExtraLarge != null)
                {
                    pbIconExtraLarge.Image = iconInfoExtraLarge.Bitmap;
                }
            }

            iconInfo.Icon.Dispose();
        }

        // Search for extensions
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            // Fix text if does not contain '.'
            if (!tbSearch.Text.StartsWith("."))
            {
                tbSearch.Text = string.Format(".{0}", tbSearch.Text);
                // Continue writing at end
                tbSearch.SelectionStart = tbSearch.Text.Length;
                tbSearch.SelectionLength = tbSearch.Text.Length;
            }
            if(!_iconList.ContainsKey(tbSearch.Text)) return;
            lbExtensions.SelectedItem = tbSearch.Text;
        }

        // Change icon size
        private void IconSize_CheckedChanged(object sender, EventArgs e)
        {
            lbExtensions_SelectedIndexChanged(lbExtensions, EventArgs.Empty);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            // Reload extensions
            if(sender == btnReload)
            {
                PopulateList();
                return;
            }
            // Save current image to file
            if(sender == btnSaveImage)
            {
                using (SaveFileDialog svFile = new SaveFileDialog())
                {
                    svFile.RestoreDirectory = true;
                    svFile.Filter = @"PNG Files (*.png)|*.png";
                    if (svFile.ShowDialog() == DialogResult.OK)
                    {
                        pbIconPreview.Image.Save(svFile.FileName);
                    }
                }
                return;
            }
        }
        #endregion
    }
}
