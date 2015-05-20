/*
 * OSIcon
 * Author: Tiago Conceição
 * 
 * https://github.com/sn4k3/OSIcon
 * http://www.codeproject.com/Articles/50064/OSIcon
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace OSIcon.Controls
{
    public partial class FileExplorer : UserControl
    {
        #region Properties
        /// <summary>
        /// Gets or sets if file explorer is handled by the library itself, otherwise you must handle navigation and item creation
        /// </summary>
        public bool HandleFileExplorer { get; set; }

        /// <summary>
        /// Gets or sets if the library can handle the shorcuts on file explorer, such as delete, backspace etc.
        /// </summary>
        public bool HandleShortcuts { get; set; }
        /// <summary>
        /// Current navigation path
        /// </summary>
        public string CurrentPath { get; private set; }

        /// <summary>
        /// Gets the total folders on the current path
        /// </summary>
        public long TotalFolders { get; private set; }

        /// <summary>
        /// Gets the total files in the current path
        /// </summary>
        public long TotalFiles { get; private set; }

        /// <summary>
        /// Gets the total files size in bytes in the current path
        /// </summary>
        public long TotalFilesSize { get; private set; }

        /// <summary>
        /// IconManager Instance
        /// </summary>
        public IconManager IconManager { get; private set; }

        private RewindManager<string> RewindManager;
        #endregion

        #region Constructor
        public FileExplorer()
        {
            InitializeComponent();
            IconManager = new IconManager(true, true, true, true, true);
            RewindManager = new RewindManager<string>();
            HandleFileExplorer = true;
            HandleShortcuts = true;
            lvFileExplorer.SmallImageList = IconManager.ImageList[IconSize.Small];
            lvFileExplorer.LargeImageList = IconManager.ImageList[IconSize.Large];
        }
        #endregion

        #region Overrides/Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Initialize IconManager class and create small, large, extralarge and jumbo ImageLists, and optimize to current OS
            
            // Add folder icons from all sizes
            IconManager.AddFolder();
            // Add all MyComputer drives icons from all sizes
            IconManager.AddComputerDrives();
            // Assign ImageLists to our ListView (Icons Images)
            
            // Add UP image to get back one directory TODO
            //IconManager.ImageList[IconSize.Small].Images.Add(":Up-icon:", Properties.Resources.Up_icon16x16);
            //IconManager.ImageList[IconSize.Large].Images.Add(":Up-icon:", Properties.Resources.Up_icon32x32);
            // ExtraLarge was introduced on XP so if you running XP or above add ExtraLarge capabilities
            if (Utilities.IsXpOrAbove())
            {
                ddViewStyle.Items.Add("ExtraLarge");
                // TODO
                //IconManager.ImageList[IconSize.ExtraLarge].Images.Add(":Up-icon:", Properties.Resources.Up_icon48x48);
            }
            // Jumbo was introduced on Vista so if you running Vista or above add Jumbo capabilities
            if (Utilities.IsVistaOrAbove())
            {
                ddViewStyle.Items.Add("Jumbo");
                // TODO
                //IconManager.ImageList[IconSize.Jumbo].Images.Add(":Up-icon:", Properties.Resources.Up_icon256x256);
            }
            // Start by show MyComputer
            ShowMyComputer();
            // Set current View
            ddViewStyle.SelectedIndex = (int)lvFileExplorer.View;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Show or hide the toolbar component
        /// </summary>
        /// <param name="visible">True to show, otherwise false</param>
        public void ShowToolBar(bool visible = true)
        {
            toolBar.Visible = visible;
        }

        /// <summary>
        /// Show or hide the status bar component
        /// </summary>
        /// <param name="visible">True to show, otherwise false</param>
        public void ShowStatusBar(bool visible = true)
        {
            statusBar.Visible = visible;
        }

        /// <summary>
        /// Select all visible items in the file explorer
        /// </summary>
        public void SelectAll()
        {
            for (var i = 0; i < lvFileExplorer.Items.Count; i++)
            {
                lvFileExplorer.Items[i].Selected = true;
            }
        }

        /// <summary>
        /// Deselect visible items in the file explorer
        /// </summary>
        public void DeselectAll()
        {
            for (var i = 0; i < lvFileExplorer.Items.Count; i++)
            {
                lvFileExplorer.Items[i].Selected = false;
            }
        }

        /// <summary>
        /// Invert the selection of the visible items in the file explorer
        /// </summary>
        public void InvertSelection()
        {
            for (var i = 0; i < lvFileExplorer.Items.Count; i++)
            {
                lvFileExplorer.Items[i].Selected = !lvFileExplorer.Items[i].Selected;
            }
        }
        #endregion

        #region Navigate Methods
        /// <summary>
        /// Show MyComputer on File Explorer
        /// </summary>
        public void ShowMyComputer()
        {
            CurrentPath = string.Empty;
            lvFileExplorer.Tag = string.Empty;
            lvFileExplorer.BeginUpdate();
            lvFileExplorer.Items.Clear();
            foreach (var drive in Directory.GetLogicalDrives())
            //foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                var iconProp = IconManager.AddEx(drive, IconManager.IconsSizeSupported);
                var item = new ListViewItem(iconProp[IconSize.Small].DisplayName)
                {
                    ImageIndex = iconProp[IconSize.Small].ItemIndex
                };
                item.SubItems.Add(string.Empty);
                item.SubItems.Add(iconProp.IconsInfo[IconSize.Small].TypeName);
                item.Tag = drive;
                lvFileExplorer.Items.Add(item);
            }
            lvFileExplorer.EndUpdate();
            tbAddress.Text = @"My Computer";
            lbTotal.Text = string.Format("{0} {1}", lvFileExplorer.Items.Count, Utilities.ConvertPlural(lvFileExplorer.Items.Count, "Drive"));
            lbSelected.Text = string.Empty;

            RewindManager.Add(CurrentPath);
            btnGoUp.Enabled = false;
            btnGoBack.Enabled = RewindManager.CanPrevious;
            btnGoForward.Enabled = RewindManager.CanForward;
        }

        /// <summary>
        /// Navigate a previous folder in the current path
        /// </summary>
        /// <returns>True if navigated successfully, otherwise false.</returns>
        public bool GoPrevious()
        {
            if (!RewindManager.GoPrevious()) return false;
            ShowPathContents(RewindManager.CurrentItem);
            return true;
        }

        /// <summary>
        /// Navigate a forward folder in the current path
        /// </summary>
        /// <returns>True if navigated successfully, otherwise false.</returns>
        public bool GoForward()
        {
            if (!RewindManager.GoForward()) return false;
            ShowPathContents(RewindManager.CurrentItem);
            return true;
        }

        /// <summary>
        /// Navigate a up folder in the current path
        /// </summary>
        /// <returns>True if navigated to a folder, otherwise false will navigate to MyComputer.</returns>
        public bool GoUp()
        {
            if (string.IsNullOrEmpty(CurrentPath))
            {
                return false;
            }
            var dirName = Path.GetDirectoryName(CurrentPath);
            if (string.IsNullOrEmpty(dirName))
            { 
                ShowMyComputer();
                return false;
            }
            ShowPathContents(dirName);
            RewindManager.Go(CurrentPath);
            return true;
        }

        /// <summary>
        /// Create Virtual GoUp folder
        /// This get back for a specified path
        /// </summary>
        /// <param name="path">Path to go, must be a folder</param>
        private void CreateGoUpFolder(string path)
        {
            var dirName = Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(dirName)) dirName = string.Empty;
            var item = new ListViewItem("...")
            {
                Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold),
                ImageKey = @":Up-icon:",
                Tag = dirName
            };
            item.SubItems.Add(string.Empty);
            item.SubItems.Add(string.Empty);
            lvFileExplorer.Items.Add(item);
        }

        /// <summary>
        /// Handle a double click action on a item (Folder and Files)
        /// </summary>
        /// <param name="item">Item that got clicked</param>
        void HandleNavigate(ListViewItem item)
        {
            // Tag hold file path to navigate, if is null mean we forget to set the path anywhere
            if (item.Tag == null) return;
            // If item path is empty that's means we have to show MyComputer
            if (item.Tag.ToString() == string.Empty)
            {
                ShowMyComputer();
                return;
            }
            // If is a directory show their contents
            if (Directory.Exists(item.Tag.ToString()))
            {
                ShowPathContents(item.Tag.ToString());
                return;
            }
            // If is a file open that file just like Windows Explorer do
            if (File.Exists(item.Tag.ToString()))
            {
                using (var proc = new Process())
                {
                    proc.StartInfo.FileName = item.Tag.ToString();
                    proc.Start();
                    proc.Close();
                }
                return;
            }
        }

        /// <summary>
        /// This loop through files and directory and show them on our explorer
        /// </summary>
        /// <param name="path">Path to show</param>
        public void ShowPathContents(string path)
        {
            if (path == null)
                return;
            // Path is empty so Show MyComputer
            if (path == string.Empty)
            {
                ShowMyComputer();
                return;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                btnGoUp.Enabled = true;
                RewindManager.Add(path);
                btnGoBack.Enabled = RewindManager.CanPrevious;
                btnGoForward.Enabled = RewindManager.CanForward;
                lbSelected.Text = string.Empty;
                CurrentPath = path;
                lvFileExplorer.BeginUpdate();
                lvFileExplorer.Items.Clear();
                //CreateGoUpFolder(path);
                TotalFilesSize = 0;
                TotalFolders = 0;
                TotalFiles = 0;
                // Loop through folders inside current folder
                foreach (var folder in Directory.EnumerateDirectories(path))
                {
                    // Get folder name from path
                    var dirInfo = new DirectoryInfo(folder);
                    // Remove system directories
                    if ((dirInfo.Attributes & FileAttributes.System) == FileAttributes.System)
                        continue;
                    var item = new ListViewItem(Path.GetFileName(folder)) { Tag = folder };
                    var iconProp = IconManager[IconManager.FolderClosed];
                    item.ImageIndex = iconProp[IconSize.Small].ItemIndex;
                    item.SubItems.Add(dirInfo.LastWriteTime.ToString(CultureInfo.CurrentCulture));
                    item.SubItems.Add(iconProp[IconSize.Small].TypeName);
                    item.SubItems.Add(string.Empty);
                    lvFileExplorer.Items.Add(item);
                    TotalFolders++;
                }
                // Loop through Files inside current folder
                foreach (var file in Directory.EnumerateFiles(path))
                {
                    // Get some addition file information like size, name, extension, etc...
                    var fi = new FileInfo(file);
                    // Remove system directories
                    if ((fi.Attributes & FileAttributes.System) == FileAttributes.System)
                        continue;
                    var iconProp = IconManager.AddEx(fi.Extension, IconManager.IconsSizeSupported);
                    var item = new ListViewItem(fi.Name)
                    {
                        Tag = fi.FullName,
                        ImageIndex = iconProp[IconSize.Small].ItemIndex
                    };
                    item.SubItems.Add(fi.LastWriteTime.ToString(CultureInfo.CurrentCulture));
                    item.SubItems.Add(iconProp.IconsInfo[IconSize.Small].TypeName);
                    item.SubItems.Add(string.Format(" {0:##.##} {1}", Utilities.FormatByteSize(fi.Length), Utilities.GetSizeNameFromBytes(fi.Length, false)));
                    lvFileExplorer.Items.Add(item);
                    TotalFilesSize += fi.Length;
                    TotalFiles++;
                }
                // Lets make some status and retrieve total folders, files and their total size
                string textToSet = string.Empty;
                if (TotalFolders > 0)
                    textToSet += string.Format("{0} {1}", TotalFolders, Utilities.ConvertPlural(TotalFolders, "Folder"));
                if (TotalFiles > 0)
                {
                    if (textToSet != "Total:")
                        textToSet += " &";
                    textToSet += string.Format(" {0:##.##} {1} in {2} {3}", Utilities.FormatByteSize(TotalFilesSize), Utilities.GetSizeNameFromBytes(TotalFilesSize, false), TotalFiles, Utilities.ConvertPlural(TotalFiles, "File"));
                }
                if (textToSet == "Total:")
                    textToSet = "Empty";
                tbAddress.Text = CurrentPath;
                lbTotal.Text = textToSet;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error on trying access: {0}\n\n{1}", path, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lvFileExplorer.EndUpdate();
                Cursor = Cursors.Default;
                RebuildNavigationHistory();
                //Text = string.Format("{0} - {1}", path, Program.AppTitle);
            }
        }

        /// <summary>
        /// Refresh file explorer and recreate all items
        /// </summary>
        public void RefreshFileExplorer()
        {
            ShowPathContents(CurrentPath);
        }

        /// <summary>
        /// Find the first occurrence of a item in the list view
        /// </summary>
        /// <param name="text">text to find</param>
        /// <param name="startIndex">Set the start index. Use -1 to use the current selected item index as start and -2 for same as -1 but skip current selected item.</param>
        /// <param name="select">True to select the item on listview, otherwise false.</param>
        /// <param name="searchBackwards">True for search the item from bottom to start, otherwise false top to bottom.</param>
        /// <returns>Item index from listview</returns>
        public int FindItem(string text, int startIndex = 0, bool select = false, bool searchBackwards = false)
        {
            var maxindex = lvFileExplorer.Items.Count - 1;
            var oldStartIndex = startIndex;
            // Assert start index
            if (startIndex < 0)
            {
                startIndex = lvFileExplorer.SelectedIndices.Count > 0 ? lvFileExplorer.SelectedIndices[0] : (searchBackwards ? maxindex : 0);
            }
            // Skip current index
            if (oldStartIndex == -2)
            {
                startIndex += (searchBackwards ? -1 : 1);
            }


            if (searchBackwards)
            {
                for (var i = startIndex; i >= 0; i--)
                {
                    if (lvFileExplorer.Items[i].Text.StartsWith(text))
                    {
                        if (select)
                        {
                            lvFileExplorer.SelectedItems.Clear();
                            lvFileExplorer.Items[i].Selected = true;
                        }
                        return i;
                    }
                }
                // 0 items found, lets start another search from the end
                if (startIndex != maxindex)
                {
                    return FindItem(text, maxindex, select, true);
                }
            }
            else
            {
                for (var i = startIndex; i <= maxindex; i++)
                {
                    if (lvFileExplorer.Items[i].Text.StartsWith(text))
                    {
                        if (select)
                        {
                            lvFileExplorer.SelectedItems.Clear();
                            lvFileExplorer.Items[i].Selected = true;
                        }
                        return i;
                    }
                }
                // 0 items found, lets start another search from the begin
                if (startIndex != 0)
                {
                    return FindItem(text, 0, select, false);
                }
            }
            return -1;
        }

        public void RebuildNavigationHistory()
        {
            btnNavigationHistory.DropDownItems.Clear();
            int i = 0;
            foreach (var item in RewindManager)
            {
                ToolStripMenuItem menuitem = new ToolStripMenuItem {Tag = item};
                if (string.IsNullOrEmpty(item))
                {
                    menuitem.Text = "My Computer";
                }
                else
                {
                    menuitem.Text = Path.GetFileName(item);
                    if (string.IsNullOrEmpty(menuitem.Text))
                        menuitem.Text = item;
                }

                if (i == RewindManager.CurrentIndex)
                {
                    menuitem.Checked = true;
                }

                menuitem.Click += (sender, args) =>
                {
                    RewindManager.Go(item);
                    ShowPathContents(item);
                };
                btnNavigationHistory.DropDownItems.Add(menuitem);
                i++;
            }

            btnNavigationHistory.Enabled = btnNavigationHistory.DropDownItems.Count > 0;
        }
        #endregion

        #region Events
        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender == btnGoBack)
            {
                GoPrevious();
                return;
            }
            if (sender == btnGoForward)
            {
                GoForward();
                return;
            }
            if (sender == btnGoUp)
            {
                GoUp();
                return;
            }
            if (sender == btnRefresh)
            {
                RefreshFileExplorer();
                return;
            }
        }

        // When a item got double clicked
        void lvFileExplorer_ItemActivate(object sender, EventArgs e)
        {
            if (!HandleFileExplorer) return;
            if (lvFileExplorer.SelectedItems.Count <= 0) return;
            HandleNavigate(lvFileExplorer.SelectedItems[0]);
        }

        private void lvFileExplorer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvFileExplorer.SelectedItems.Count == 0)
            {
                lbSelected.Text = string.Empty;
                return;
            }

            lbSelected.Text = string.Format("{0} {1} selected", lvFileExplorer.SelectedItems.Count, Utilities.ConvertPlural(lvFileExplorer.SelectedItems.Count, "item"));
        }

        // When user change View
        private void ddViewStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If view is bigger than 4 means user wants ExtraLarge or Jumbo
            // To show that sizes View must be set to: View.LargeIcon
            // Also we have to change Large ImageList to the desired one
            if (ddViewStyle.SelectedIndex > 4)
            {
                // we change ImageList because ListView only have ImageList and LargeImageList
                switch (ddViewStyle.SelectedIndex)
                {
                    case 5:
                        lvFileExplorer.LargeImageList = IconManager.ImageList[IconSize.ExtraLarge];
                        break;
                    case 6:
                        lvFileExplorer.LargeImageList = IconManager.ImageList[IconSize.Jumbo];
                        break;
                }
                lvFileExplorer.View = View.LargeIcon;
                return;
            }
            // View is under normal (small or large)
            // Get back to normal
            lvFileExplorer.LargeImageList = IconManager.ImageList[IconSize.Large];
            lvFileExplorer.View = (View)ddViewStyle.SelectedIndex;
        }

        private void lvFileExplorer_KeyDown(object sender, KeyEventArgs e)
        {
            if (!HandleShortcuts)
                return;

            // Invert selection
            if (e.KeyCode == Keys.Multiply)
            {
                InvertSelection();
                e.Handled = true;
                return;
            }
            // Go Up
            if (e.KeyCode == Keys.Back)
            {
                GoUp();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.F2)
            {
                if (lvFileExplorer.SelectedItems.Count == 0)
                    return;

                lvFileExplorer.SelectedItems[0].BeginEdit();

                return;
            }
            if (e.KeyCode == Keys.F5)
            {
                RefreshFileExplorer();
                return;
            }
            /*if(e.KeyCode.ToString().Length == 1)
            {
                FindItem(e.KeyCode.ToString(), -2, true, e.Modifiers== Keys.Shift);
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }*/
        }

        private void lvFileExplorer_MouseUp(object sender, MouseEventArgs e)
        {
            if (!HandleShortcuts)
                return;

            /*if (e.Button == MouseButtons.Right)
            {
                if (lvFileExplorer.SelectedItems.Count == 0)
                    return;

                ShellContextMenu ctxMnu = new ShellContextMenu();
                FileInfo[] filesInfo = new FileInfo[lvFileExplorer.SelectedItems.Count];
                for (int i = 0; i < lvFileExplorer.SelectedItems.Count; i++)
                {
                    ListViewItem selectedItem = lvFileExplorer.SelectedItems[i];
                    filesInfo[i] = new FileInfo(selectedItem.Tag.ToString());
                }
                ctxMnu.ShowContextMenu(filesInfo, PointToScreen(new Point(e.X, e.Y)));
            }*/
            if (e.Button == MouseButtons.XButton1)
            {
                GoPrevious();
                return;
            }
            if (e.Button == MouseButtons.XButton2)
            {
                GoForward();
                return;
            }
        }

        private void lvFileExplorer_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (!HandleFileExplorer || string.IsNullOrEmpty(e.Label))
            {
                e.CancelEdit = true;
                return;
            }


            var item = lvFileExplorer.Items[e.Item];

            var label = e.Label.Trim();

            if (label.Length == 0 || label.Equals(item.Text))
            {
                e.CancelEdit = true;
                return;
            }

            var path = item.Tag.ToString();
            try
            {
                if (Directory.Exists(path))
                {
                    DirectoryInfo dir = new DirectoryInfo(path);
                    if (dir.Parent == null)
                    {
                        e.CancelEdit = true;
                        return;
                    }
                    dir.MoveTo(Path.Combine(dir.Parent.FullName, label));
                }
                else
                {
                    FileInfo file = new FileInfo(path);
                    if (file.DirectoryName == null)
                    {
                        e.CancelEdit = true;
                        return;
                    }
                    file.MoveTo(Path.Combine(file.DirectoryName, label));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Can't rename folder\n{0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.CancelEdit = true;
            }
            
        }
        #endregion
    }
}
