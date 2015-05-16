using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Drawing;
using OSIcon.WinAPI;

namespace OSIcon
{
    /// <summary>
    /// Provides static methods to read system icons for both folders and files.
    /// </summary>
    /// <example>
    /// <code>IconReader.GetFileIcon("c:\\general.xls");</code>
    /// </example>
    public static class IconReader
    {
        #region ExtractIcon
        /// <summary>
        /// Extract the icon from file giving an index.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="index">Icon index to extract.</param>
        /// <returns>A <see cref="Icon"/> if file and index exists, otherwise returns null.</returns>
        public static Icon ExtractIconFromFile(string path, int index)
        {
            //Win32 
            //Extract the icon handle 
            var hIcon = Shell32.ExtractIcon(Process.GetCurrentProcess().Handle, Environment.ExpandEnvironmentVariables(path), index);
            //Get icon form .dll or .exe 
            return hIcon == IntPtr.Zero ? null : GetManagedIcon(hIcon);
        }

        /// <summary>
        /// Extract the icon from file.
        /// </summary>
        /// <param name="path">File path, 
        /// such as ex: "C:\\Program Files\\NetMeeting\\conf.exe,1".</param>
        /// <returns>A <see cref="Icon"/> if file and index exists, otherwise returns null. 
        /// This method always returns the large size of the icon (may be 32x32 px).</returns>
        public static Icon ExtractIconFromFile(string path)
        {
            var embeddedIcon = EmbeddedIconInfo.ParseString(Environment.ExpandEnvironmentVariables(path));
            //Gets the handle of the icon.
            return ExtractIconFromFile(embeddedIcon.FileName, embeddedIcon.Index);
        }

        /// <summary>
        /// Extract the icon from file, and return icon information
        /// </summary>
        /// <param name="path">File path, 
        /// such as ex: "C:\\Program Files\\NetMeeting\\conf.exe,1".</param>
        /// <param name="size">The desired icon size</param>
        /// <returns>This method always returns an icon with the specified size and their information.</returns>
        public static IconInfo ExtractIconFromFileEx(string path, IconSize size)
        {
            var embeddedIcon = EmbeddedIconInfo.ParseString(Environment.ExpandEnvironmentVariables(path));
            return GetFileIcon(embeddedIcon.FileName, size);
        }

        /// <summary>
        /// Extract the icon from file.
        /// </summary>
        /// <param name="path">File path, 
        /// such as ex: "C:\\Program Files\\NetMeeting\\conf.exe,1".</param>
        /// <param name="isLarge">
        /// Determines the returned icon is a large (may be 32x32 px) 
        /// or small icon (16x16 px).</param>
        public static Icon ExtractIconFromFile(string path, bool isLarge)
        {
            var hDummy = new[] { IntPtr.Zero };
            var hIconEx = new[] { IntPtr.Zero };

            try
            {
                var embeddedIcon = EmbeddedIconInfo.ParseString(Environment.ExpandEnvironmentVariables(path));
                uint readIconCount = isLarge ? Shell32.ExtractIconEx(embeddedIcon.FileName, 0, hIconEx, hDummy, 1) : Shell32.ExtractIconEx(embeddedIcon.FileName, 0, hDummy, hIconEx, 1);
                if (readIconCount > 0 && hIconEx[0] != IntPtr.Zero)
                {
                    // Get first icon.
                    return GetManagedIcon(hIconEx[0]);
                }
                else // No icon read
                {
                    return null;
                }
            }
            catch (Exception exc)
            {
                // Extract icon error.
                throw new ApplicationException("Could not extract icon", exc);
            }
            finally
            {
                // Release resources.
                foreach (IntPtr ptr in hIconEx)
                    if (ptr != IntPtr.Zero)
                        User32.DestroyIcon(ptr);
                foreach (IntPtr ptr in hDummy)
                    if (ptr != IntPtr.Zero)
                        User32.DestroyIcon(ptr);
            }
        }
        /// <summary>
        /// Extract all icons from a file
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="isLarge">Large (32x32) or Small (16x16) icon</param>
        /// <returns>Icon[] array</returns>
        public static Icon[] ExtractIconsFromFile(string path, bool isLarge)
        {
            path = Environment.ExpandEnvironmentVariables(path);
            int iconsCount = (int)GetTotalIcons(path);
            //checks how many icons.

            IntPtr[] iconPtr = new IntPtr[iconsCount];

            //extracts the icons by the size that was selected.

            uint readIconCount = isLarge ? Shell32.ExtractIconEx(path, 0, iconPtr, null, iconsCount) : Shell32.ExtractIconEx(path, 0, null, iconPtr, iconsCount);

            Icon[] iconList = new Icon[iconsCount];

            //gets the icons in a list.

            for (int i = 0; i < iconsCount; i++)
                if (iconPtr[i] != IntPtr.Zero)
                    iconList[i] = GetManagedIcon(iconPtr[i]);
            return iconList;
        }

        /// <summary>
        /// Extract a icon from a assembly
        /// </summary>
        /// <param name="assembly">The assembly to use. When null is used <see cref="Assembly.GetCallingAssembly()"/> will be used.</param>
        /// <param name="resourceName">Icon resource name in assembly.</param>
        /// <returns>Icon for the resourceName, null if not exists</returns>
        public static Icon ExtractIconFromResource(string resourceName, Assembly assembly = null)
        {
            if (assembly == null) assembly = Assembly.GetCallingAssembly();
            return new Icon(assembly.GetManifestResourceStream(resourceName));
        }

        #endregion

        #region Get all files extensions from regedit
        /// <summary>
        /// Gets registered file types and their associated icon in the system.
        /// </summary>
        /// <returns>Returns a Dictionary which contains the file extension as key, and the icon file and param as value.</returns>
        public static Dictionary<string, string> GetFileTypeAndIcon()
        {
            try
            {
                // Create a registry key object to represent the HKEY_CLASSES_ROOT registry section
                var rkRoot = Registry.ClassesRoot;
                
                //Gets all sub keys' names.
                var keyNames = rkRoot.GetSubKeyNames();
                var iconsInfo = new Dictionary<string, string>();

                //Find the file icon.
                foreach (var keyName in keyNames)
                {
                    if (string.IsNullOrEmpty(keyName))
                        continue;

                    //If this key is not a file extension(eg, .zip), skip it.
                    if (!keyName.StartsWith("."))
                        continue;

                    var rkFileType = rkRoot.OpenSubKey(keyName);
                    if (rkFileType == null)
                        continue;

                    //Gets the default value of this key that contains the information of file type.
                    var defaultValue = rkFileType.GetValue("");
                    if (defaultValue == null)
                        continue;

                    //Go to the key that specifies the default icon associates with this file type.
                    var defaultIcon = string.Format("{0}\\DefaultIcon", defaultValue);
                    var rkFileIcon = rkRoot.OpenSubKey(defaultIcon);
                    if (rkFileIcon != null)
                    {
                        //Get the file contains the icon and the index of the icon in that file.
                        var value = rkFileIcon.GetValue("");
                        if (value != null)
                        {
                            //Clear all unnecessary " sign in the string to avoid error.
                            var fileParam = value.ToString().Replace("\"", "");
                            iconsInfo.Add(keyName, fileParam);
                        }
                        rkFileIcon.Close();
                    }
                    rkFileType.Close();
                }
                rkRoot.Close();
                return iconsInfo;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        #endregion

        #region Get Methods
        /// <summary>
        /// Get the total icons in a file
        /// </summary>
        /// <param name="path">Path to a file</param>
        /// <example>
        /// <code>IconReader.GetTotalIcons("C:\\Windows\\system32\\shell32.dll");</code>
        /// </example>
        /// <returns>Total icon on selected file</returns>
        public static uint GetTotalIcons(string path)
        {
            return Shell32.ExtractIconEx(Environment.ExpandEnvironmentVariables(path), -1, null, null, 0);
        }

        /// <summary>
        /// Get a managed icon from a unmanaged one,
        /// Copy (clone) the returned icon to a new object, thus allowing us to clean-up properly
        /// </summary>
        /// <param name="unmanagedIcon">Unmanaged icon</param>
        /// <returns>Managed icon instance</returns>
        public static Icon GetManagedIcon(ref Icon unmanagedIcon)
        {
            Icon managedIcon = (Icon)unmanagedIcon.Clone();
            User32.DestroyIcon(unmanagedIcon.Handle);
            return managedIcon;
        }

        /// <summary>
        /// Get managed icon from a IntPtr pointer,
        /// Copy (clone) the returned icon to a new object, thus allowing us to clean-up properly
        /// </summary>
        /// <param name="pointer">Icon Handler</param>
        /// <returns>Managed icon instance</returns>
        public static Icon GetManagedIcon(IntPtr pointer)
        {
            Icon managedIcon = (Icon)Icon.FromHandle(pointer).Clone();
            User32.DestroyIcon(pointer);
            return managedIcon;
        }

        /// <summary>
        /// Gets the icon size in pixels
        /// </summary>
        /// <param name="iconSize"></param>
        /// <returns>The icon size in pixels.</returns>
        public static uint GetIconPixels(IconSize iconSize)
        {
            switch (iconSize)
            {
                case IconSize.Large:
                    return 32;
                case IconSize.Small:
                    return 16;
                case IconSize.ExtraLarge:
                    return 48;
                case IconSize.Jumbo:
                    return 256;
            }
            return 32;
        }

        /// <summary>
        /// Gets the icon size in pixels
        /// </summary>
        /// <param name="iconSize"></param>
        /// <returns>The icon size in pixels.</returns>
        public static Size GetIconSize(IconSize iconSize)
        {
            int size = (int) GetIconPixels(iconSize);
            return new Size(size, size);
        }
        #endregion

        #region GetFileIcon
        /// <summary>
        /// Returns an icon for a given file - indicated by the name parameter.
        /// </summary>
        /// <param name="name">Extension or pathname for file.</param>
        /// <param name="size">Large or small</param>
        /// <param name="linkOverlay">Whether to include the link icon</param>
        /// <returns><see cref="IconInfo"/></returns>
        public static IconInfo GetFileIcon(string name, IconSize size, bool linkOverlay = false)
        {
            name = Environment.ExpandEnvironmentVariables(name);
            var shfi = new Shell32.SHFILEINFO();
            var flags = Shell32.SHGetFileInfoConstants.SHGFI_TYPENAME | Shell32.SHGetFileInfoConstants.SHGFI_DISPLAYNAME |
                        Shell32.SHGetFileInfoConstants.SHGFI_ICON | Shell32.SHGetFileInfoConstants.SHGFI_SHELLICONSIZE |
                        Shell32.SHGetFileInfoConstants.SHGFI_SYSICONINDEX |
                        Shell32.SHGetFileInfoConstants.SHGFI_USEFILEATTRIBUTES;

            if (linkOverlay) flags |= Shell32.SHGetFileInfoConstants.SHGFI_LINKOVERLAY;
            /* Check the size specified for return. */
            if (IconSize.Small == size)
                flags |= Shell32.SHGetFileInfoConstants.SHGFI_SMALLICON;
            else
                flags |= Shell32.SHGetFileInfoConstants.SHGFI_LARGEICON;

            IntPtr hIml = Shell32.SHGetFileInfo(name,
                Shell32.FILE_ATTRIBUTE.NORMAL,
                ref shfi,
                (uint)Marshal.SizeOf(shfi),
                flags);

            if (shfi.hIcon == IntPtr.Zero) return null;
            if (!Utilities.IsXpOrAbove()) return new IconInfo(shfi);
            // Get the System IImageList object from the Shell:
            Guid iidImageList = new Guid("46EB5926-582E-4017-9FDF-E8998DAA0950");
            Shell32.IImageList iImageList = null;
            var ret = Shell32.SHGetImageList(
                (int)size,
                ref iidImageList,
                ref iImageList
                );
            // the image list handle is the IUnknown pointer, but
            // using Marshal.GetIUnknownForObject doesn't return
            // the right value.  It really doesn't hurt to make
            // a second call to get the handle:
            Shell32.SHGetImageListHandle((int)size, ref iidImageList, ref hIml);
                
            IntPtr hIcon = IntPtr.Zero;
            if (iImageList == null)
            {
                hIcon = Comctl32.ImageList_GetIcon(
                    hIml,
                    shfi.iIcon,
                    (int)Comctl32.ImageListDrawItemConstants.ILD_TRANSPARENT);
            }
            else
            {
                iImageList.GetIcon(
                    shfi.iIcon,
                    (int)Comctl32.ImageListDrawItemConstants.ILD_TRANSPARENT,
                    ref hIcon);
            }
            return hIcon == IntPtr.Zero ? new IconInfo(shfi) : new IconInfo(hIcon, shfi);
        }
        #endregion

        #region GetFolderIcon
        /// <summary>
        /// Used to access system folder icons.
        /// </summary>
        /// <param name="size">Specify large or small icons.</param>
        /// <param name="folderState">Specify open or closed FolderState.</param>
        /// <returns><see cref="IconInfo"/></returns>
        public static IconInfo GetFolderIcon(IconSize size, FolderState folderState)
        {
            // Need to add size check, although errors generated at present!
            var flags = Shell32.SHGetFileInfoConstants.SHGFI_TYPENAME | Shell32.SHGetFileInfoConstants.SHGFI_DISPLAYNAME | Shell32.SHGetFileInfoConstants.SHGFI_ICON | Shell32.SHGetFileInfoConstants.SHGFI_USEFILEATTRIBUTES;

            if (FolderState.Open == folderState)
                flags |= Shell32.SHGetFileInfoConstants.SHGFI_OPENICON;

            if (IconSize.Small == size)
                flags |= Shell32.SHGetFileInfoConstants.SHGFI_SMALLICON;
            else
                flags |= Shell32.SHGetFileInfoConstants.SHGFI_LARGEICON;

            IntPtr hIml;
            // Get the folder icon
            var shfi = new Shell32.SHFILEINFO();
            if (Utilities.IsSevenOrAbove()) // Windows 7 FIX
            {
                hIml = Shell32.SHGetFileInfo(Environment.GetFolderPath(Environment.SpecialFolder.System),
                Shell32.FILE_ATTRIBUTE.DIRECTORY,
                ref shfi,
                (uint)Marshal.SizeOf(shfi),
                flags);
            }
            else
            {
                hIml = Shell32.SHGetFileInfo(null,
                Shell32.FILE_ATTRIBUTE.DIRECTORY,
                ref shfi,
                (uint)Marshal.SizeOf(shfi),
                flags);
            }
            if (shfi.hIcon == IntPtr.Zero) return null;
            if (!Utilities.IsXpOrAbove()) return new IconInfo(GetManagedIcon(shfi.hIcon), shfi);
            // Get the System IImageList object from the Shell:
            Guid iidImageList = new Guid("46EB5926-582E-4017-9FDF-E8998DAA0950");
            Shell32.IImageList iImageList = null;
            int ret = Shell32.SHGetImageList(
                (int)size,
                ref iidImageList,
                ref iImageList
                );
                
            // the image list handle is the IUnknown pointer, but
            // using Marshal.GetIUnknownForObject doesn't return
            // the right value.  It really doesn't hurt to make
            // a second call to get the handle:
            Shell32.SHGetImageListHandle((int)size, ref iidImageList, ref hIml);
            IntPtr hIcon = IntPtr.Zero;
            if (iImageList == null)
            {
                hIcon = Comctl32.ImageList_GetIcon(
                   hIml,
                   shfi.iIcon,
                   (int)Comctl32.ImageListDrawItemConstants.ILD_TRANSPARENT);
            }
            else
            {
                iImageList.GetIcon(
                   shfi.iIcon,
                   (int)Comctl32.ImageListDrawItemConstants.ILD_TRANSPARENT,
                   ref hIcon);
            }
            return hIcon == IntPtr.Zero ? new IconInfo(GetManagedIcon(shfi.hIcon), shfi) : new IconInfo(GetManagedIcon(hIcon), shfi);
        }
        #endregion
    }
}