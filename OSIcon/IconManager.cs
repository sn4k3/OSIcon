using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OSIcon
{
    /// <summary>
    /// Provide an CACHE system for add and retrieve icons,
    /// And create a ImageList with all retrived icons.
    /// </summary>
    public partial class IconManager : IDisposable
    {
        #region Constants
        /// <summary>
        /// Use when you want access to OpenFolder Icon
        /// </summary>
        public const string FolderOpen = ":FOLDEROPEN:";
        /// <summary>
        /// Use when you want access to ClosedFolder Icon
        /// </summary>
        public const string FolderClosed = ":FOLDERCLOSED:";
        /// <summary>
        /// Equivalent to: IconSize.Small | IconSize.Large
        /// </summary>
        public const IconSize IconSizeBoth = IconSize.Small | IconSize.Large;
        /// <summary>
        /// Equivalent to: IconSize.Small | IconSize.Large | IconSize.ExtraLarge | IconSize.Jumbo
        /// </summary>
        public const IconSize IconSizeAll = IconSize.Small | IconSize.Large | IconSize.ExtraLarge | IconSize.Jumbo;

        /// <summary>
        /// Equivalent to: IconSize.Small | IconSize.Large
        /// IconSize.ExtraLarge AND IconSize.Jumbo will be only added if the current OS support that sizes.
        /// NOTE: Use that instead 'IconSizeAll'
        /// </summary>
        public readonly IconSize IconsSizeSupported = IconSize.Small | IconSize.Large;
        #endregion

        #region Properties
        /// <summary>
        /// ImageList Dictionary with associated icons,
        /// use and assign like: ImageList[IconSize.Large]
        /// </summary>
        /// <example>ImageList[IconSize.Large]</example>
        public Dictionary<IconSize, ImageList> ImageList { get; private set; }

        /// <summary>
        /// Gets the Icon list dictionary, wheres the key is the file or extension
        /// </summary>
        public Dictionary<string, IconProperties> IconList { get; private set; }

        /// <summary>
        /// Gets the supported icon sizes for the current system.
        /// </summary>
        public IconSize SupportedIconSizes { get { return IconsSizeSupported; } }
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize class
        /// </summary>
        /// <param name="createSmallIconList">Create or not the Small ImageList.</param>
        /// <param name="createLargeIconList">Create or not the Large ImageList.</param>
        /// <param name="createExtraLargeIconList">Create or not the ExtraLarge ImageList.</param>
        /// <param name="createJumboIconList">Create or not the Jumbo ImageList.</param>
        /// <param name="optimizeToOs">Since XP or above support ExtraLarge. Since Vista or above support Jumbo icon sizes
        /// Disable unless sizes and ImageList on OS that not support that features.</param>
        public IconManager(bool createSmallIconList = true, bool createLargeIconList = true, bool createExtraLargeIconList = false, bool createJumboIconList = false, bool optimizeToOs = false)
        {
            IconList = new Dictionary<string, IconProperties>(4);
            ImageList = new Dictionary<IconSize, ImageList>();

            // Add extra flags to supported sizes for the current OS
            if (Utilities.IsXpOrAbove())
                IconsSizeSupported |= IconSize.ExtraLarge;
            if (Utilities.IsVistaOrAbove())  
                IconsSizeSupported |= IconSize.Jumbo;

            if(optimizeToOs)
            {
                // Check if a some features work on current OS, if not disable it by force
                if (!Utilities.IsXpOrAbove())       // XP+ Support ExtraLarge
                    createExtraLargeIconList = false;
                if (!Utilities.IsVistaOrAbove())    // Vista+ Support Jumbo
                    createJumboIconList = false;
            }

            // Create a imagelist with all collected icons and information
            ImageList[IconSize.Small]       = createSmallIconList       ? CreateImageList(IconSize.Small)       : null;
            ImageList[IconSize.Large]       = createLargeIconList       ? CreateImageList(IconSize.Large)       : null;
            ImageList[IconSize.ExtraLarge]  = createExtraLargeIconList  ? CreateImageList(IconSize.ExtraLarge)  : null;
            ImageList[IconSize.Jumbo]       = createJumboIconList       ? CreateImageList(IconSize.Jumbo)       : null;
        }
        #endregion

        #region Static Methods

        /// <summary>
        /// Create a <see cref="ImageList"/> based on a <see cref="IconSize"/>
        /// </summary>
        /// <param name="iconSize"></param>
        /// <returns></returns>
        public static ImageList CreateImageList(IconSize iconSize)
        {
            var imagelist = new ImageList
            {
                TransparentColor = Color.Transparent,
                ColorDepth = ColorDepth.Depth32Bit,
                ImageSize = IconReader.GetIconSize(iconSize)
            };
            return imagelist;
        }
        #endregion

        #region Get Methods
        /// <summary>
        /// Retrieve the icon index from the ImageList
        /// </summary>
        /// <param name="extension">The extension, 
        /// such as ex: ".mp3".</param>
        /// <param name="iconSize">The icon size.</param>
        /// <param name="check">True for check if icon exists first, otherwise if false and icon doesn't exists it will trown an exception.</param>
        /// <returns>Returns -1 if extension not exist on list, otherwise returns >= 0</returns>
        public int GetIconIndex(string extension, IconSize iconSize, bool check = true)
        {
            if (check)
                if (!IsValid(extension)) return -1;
            return IconList[extension][iconSize].ItemIndex;
        }

        /// <summary>
        /// Check if an extension exist on IconList and return their value, 
        /// otherwise returns new IconProperties();
        /// </summary>
        /// <returns><see cref="IconProperties"/> of founded path, otherwise return new IconProperties();</returns>
        public IconProperties GetOrCreate(string extension)
        {
            return !IconList.ContainsKey(extension) ? new IconProperties() : IconList[extension];
        }
        #endregion

        #region Is Methods
        /// <summary>
        /// Check if an extension exist on IconList
        /// </summary>
        public bool IsValid(string extension)
        {
            return IconList.ContainsKey(extension);
        }

        /*public bool IsCreated(string extension, IconSize iconSize)
        {
            return false;
        }*/
        #endregion

        #region Add Methods
        /*public IconProperties Add(string extension, IconProperties iconProp, bool check)
        {
            if (check)
                if (IsValid(extension)) return IconList[extension];
            IconProperties _fileinfo = new IconProperties();
            _fileinfo.IconsInfo.Small = fileInfo;
            _fileinfo.IconsIndex.Small = ImageListSmall.Images.Count;
            _fileinfo.Icons.Small = icon;
            IconList.Add(extension, _fileinfo);
            ImageListSmall.Images.Add(extension, icon);
            return _fileinfo;
        }*/
        /// <summary>
        /// Internal add a icon to class
        /// </summary>
        /// <param name="path">Icon Path on filesystem, or extension</param>
        /// <param name="iconSize">Icon Size</param>
        /// <param name="iconProp">Icon Properties to assign to list</param>
        private void Add(string path, IconSize iconSize, IconProperties iconProp)
        {
            var iconInfo = IconReader.GetFileIcon(path, iconSize);
            iconProp.IconsInfo[iconSize] = iconInfo;

            if (ImageList[iconSize] == null) return;
            iconInfo.ItemIndex = ImageList[iconSize].Images.Count;
            ImageList[iconSize].Images.Add(path, iconInfo.Icon);
        }
        /// <summary>
        /// Internal add a icon to class
        /// FOLDERS ONLY!!!!!!
        /// </summary>
        /// <param name="path">Icon Path on filesystem, or extension</param>
        /// <param name="iconSize">Icon Size</param>
        /// <param name="iconProp">Icon Properties to assign to list</param>
        /// <param name="folder">Folder type (open or closed)</param>
        private void Add(string path, IconSize iconSize, IconProperties iconProp, FolderState folder)
        {
            var iconInfo = IconReader.GetFolderIcon(iconSize, folder);
            iconProp.IconsInfo[iconSize] = iconInfo;

            if (ImageList[iconSize] == null) return;
            iconInfo.ItemIndex = ImageList[iconSize].Images.Count;
            ImageList[iconSize].Images.Add(path, iconInfo.Icon);
        }
        /// <summary>
        /// Add an extension to List if not exists and return a <see cref="IconProperties"/>
        /// </summary>
        /// <param name="path">The extension, 
        /// such as ex: ".mp3" or full path "C:\\mymusic.mp3".</param>
        /// <param name="iconSize">The icon size, support multi size flags</param>
        /// <returns>Returns Icon and their information.</returns>
        public IconProperties AddEx(string path, IconSize iconSize)
        {
            var iconProp = GetOrCreate(path);

            foreach (IconSize size in Enum.GetValues(typeof (IconSize)))
            {
                if ((iconSize & size) != size) continue;
                if (!iconProp.IsValidEx(size))
                    Add(path, size, iconProp);
            }


            if (!IsValid(path))
                IconList.Add(path, iconProp);

            return iconProp;
        }
        /// <summary>
        /// Utility function to Add Computer drivers icons and information to list
        /// </summary>
        /// <param name="iconSize">The icon size, support multi size flags</param>
        public void AddComputerDrives(IconSize iconSize)
        {
            foreach (var drive in Directory.GetLogicalDrives())
            {
                AddEx(drive, iconSize);
            }
        }

        /// <summary>
        /// Utility function to Add Computer drivers icons and information to list. This will add all supported size icons.
        /// </summary>
        public void AddComputerDrives()
        {
            AddComputerDrives(IconsSizeSupported);
        }

        /// <summary>
        /// Utility function to Add Folders icons and information to list
        /// </summary>
        /// <param name="iconSize">The icon size, support multi size flags</param>
        public void AddFolder(IconSize iconSize)
        {
            var iconPropOpen = new IconProperties();
            var iconPropClosed = new IconProperties();
            foreach (IconSize size in Enum.GetValues(typeof (IconSize)))
            {
                if ((iconSize & size) != size) continue;
                Add(FolderOpen, size, iconPropOpen, FolderState.Open);
                Add(FolderClosed, size, iconPropClosed, FolderState.Closed);
            }
            
            IconList.Add(FolderOpen, iconPropOpen);
            IconList.Add(FolderClosed, iconPropClosed);
        }

        /// <summary>
        /// Utility function to Add Folders icons and information to list. This will add all supported size icons.
        /// </summary>
        public void AddFolder()
        {
            AddFolder(IconsSizeSupported);
        }

        #endregion

        #region Remove Methods
        /// <summary>
        /// Remove whole icons information for a specified path or extension
        /// </summary>
        /// <param name="path">Icon path or extension</param>
        /// <param name="removeIconFromList">Did you want remove icon from ImageList? true or false</param>
        /// <example>Remove(".mp3", false);</example>
        public bool Remove(string path, bool removeIconFromList)
        {
            if(!IsValid(path)) return false;
            if (removeIconFromList)
                foreach (var list in IconList[path].IconsInfo)
                    ImageList[list.Key].Images.RemoveAt(list.Value.ItemIndex);
            IconList[path].Dispose();
            IconList.Remove(path);
            return true;
        }
        /// <summary>
        /// Remove icons information for a specified icon size
        /// </summary>
        /// <param name="path">Icon path or extension</param>
        /// <param name="iconSize">The icon size, support multi size flags</param>
        /// <param name="removeIconFromList">Did you want remove icon from ImageList? true or false</param>
        /// <example>Remove(".txt", IconSize.Jumbo | IconSize.ExtraLarge, true);</example>
        public bool Remove(string path, IconSize iconSize, bool removeIconFromList)
        {
            if (!IsValid(path)) return false;
            var removedIcons = IconList[path].Remove(iconSize);
            if (removeIconFromList)
                foreach (var item in removedIcons)
                    ImageList[item.Key].Images.RemoveAt(item.Value);
            if (IconList[path].HasAnyKey()) return true;
            IconList[path].Dispose();
            IconList.Remove(path);
            return true;
        }
        #endregion

        #region Indexers
        public ImageList this[IconSize size]
        {
            get
            {
                return ImageList[size];
            }
        }

        public IconProperties this[string extension]
        {
            get
            {
                return IsValid(extension) ? IconList[extension] : null;
            }
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Free all resources used by that class.
        /// </summary>
        public void Dispose()
        {
            foreach (var list in ImageList)
            {
                if (list.Value == null) continue;
                list.Value.Dispose();
            }
            IconList.Clear();
        }
        #endregion
    }
}