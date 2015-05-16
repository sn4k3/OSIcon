using System;
using System.Runtime.InteropServices;

namespace OSIcon.WinAPI
{
    public class Shell32
    {
        #region Structs
        public const int MAX_PATH = 260;
        [StructLayout(LayoutKind.Sequential)]
        public struct SHITEMID
        {
            public ushort cb;
            [MarshalAs(UnmanagedType.LPArray)]
            public byte[] abID;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ITEMIDLIST
        {
            public SHITEMID mkid;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BROWSEINFO
        {
            public IntPtr hwndOwner;
            public IntPtr pidlRoot;
            public IntPtr pszDisplayName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszTitle;
            public uint ulFlags;
            public IntPtr lpfn;
            public int lParam;
            public IntPtr iImage;
        }

        // Browsing for directory.
        public const uint BIF_RETURNONLYFSDIRS = 0x0001;
        public const uint BIF_DONTGOBELOWDOMAIN = 0x0002;
        public const uint BIF_STATUSTEXT = 0x0004;
        public const uint BIF_RETURNFSANCESTORS = 0x0008;
        public const uint BIF_EDITBOX = 0x0010;
        public const uint BIF_VALIDATE = 0x0020;
        public const uint BIF_NEWDIALOGSTYLE = 0x0040;
        public const uint BIF_USENEWUI = (BIF_NEWDIALOGSTYLE | BIF_EDITBOX);
        public const uint BIF_BROWSEINCLUDEURLS = 0x0080;
        public const uint BIF_BROWSEFORCOMPUTER = 0x1000;
        public const uint BIF_BROWSEFORPRINTER = 0x2000;
        public const uint BIF_BROWSEINCLUDEFILES = 0x4000;
        public const uint BIF_SHAREABLE = 0x8000;

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public const int NAMESIZE = 80;
            public IntPtr hIcon;
            public int iIcon;
            public SHGetFileInfoConstants dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NAMESIZE)]
            public string szTypeName;
        };
        #endregion

        #region SHGetFileInfoConstants Flags
        [Flags]
        public enum SHGetFileInfoConstants : uint
        {
            SHGFI_ICON = 0x100,                // get icon
            SHGFI_DISPLAYNAME = 0x200,         // get display name
            SHGFI_TYPENAME = 0x400,            // get type name
            SHGFI_ATTRIBUTES = 0x800,          // get attributes
            SHGFI_ICONLOCATION = 0x1000,       // get icon location
            SHGFI_EXETYPE = 0x2000,            // return exe type
            SHGFI_SYSICONINDEX = 0x4000,       // get system icon index
            SHGFI_LINKOVERLAY = 0x8000,        // put a link overlay on icon
            SHGFI_SELECTED = 0x10000,          // show icon in selected state
            SHGFI_ATTR_SPECIFIED = 0x20000,    // get only specified attributes
            SHGFI_LARGEICON = 0x0,             // get large icon
            SHGFI_SMALLICON = 0x1,             // get small icon
            SHGFI_OPENICON = 0x2,              // get open icon
            SHGFI_SHELLICONSIZE = 0x4,         // get shell size icon
            SHGFI_PIDL = 0x8,                  // pszPath is a pidl
            SHGFI_USEFILEATTRIBUTES = 0x10,    // use passed dwFileAttribute
            SHGFI_ADDOVERLAYS = 0x000000020,   // apply the appropriate overlays
            SHGFI_OVERLAYINDEX = 0x000000040   // Get the index of the overlay
        }
        [Flags]
        public enum FILE_ATTRIBUTE
        {
            READONLY = 0x00000001,
            HIDDEN = 0x00000002,
            SYSTEM = 0x00000004,
            DIRECTORY = 0x00000010,
            ARCHIVE = 0x00000020,
            DEVICE = 0x00000040,
            NORMAL = 0x00000080,
            TEMPORARY = 0x00000100,
            SPARSE_FILE = 0x00000200,
            REPARSE_POINT = 0x00000400,
            COMPRESSED = 0x00000800,
            OFFLINE = 0x00001000,
            NOT_CONTENT_INDEXED = 0x00002000,
            ENCRYPTED = 0x00004000
        }
        #endregion

        #region DllImport
        [DllImport("Shell32", CharSet = CharSet.Auto)]
        public static extern uint ExtractIconEx(
            string lpszFile,
            int nIconIndex,
            IntPtr[] phIconLarge,
            IntPtr[] phIconSmall,
            int nIcons);

        [DllImport("shell32.dll", EntryPoint = "ExtractIconA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr ExtractIcon(IntPtr hInst, string lpszExeFileName, int nIconIndex);

        [DllImport("shell32.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr SHGetFileInfo(
            string pszPath,
            FILE_ATTRIBUTE dwFileAttributes,
            ref SHFILEINFO psfi,
            uint cbFileInfo,
            SHGetFileInfoConstants uFlags
            );

        [DllImport("shell32.dll", CharSet = CharSet.Ansi)]
         public static extern IntPtr SHGetFileInfo(
              IntPtr ppidl,
              FILE_ATTRIBUTE dwFileAttributes,
              ref SHFILEINFO psfi,
              int cbFileInfo,
              SHGetFileInfoConstants uFlags);

        /// <summary>
        /// SHGetImageList is not exported correctly in XP.  See KB316931
        /// http://support.microsoft.com/default.aspx?scid=kb;EN-US;Q316931
        /// Apparently (and hopefully) ordinal 727 isn't going to change.
        /// </summary>
        [DllImport("shell32.dll", EntryPoint = "#727")]
        public extern static int SHGetImageList(
            int iImageList,
            ref Guid riid,
            ref IImageList ppv
            );

        [DllImport("shell32.dll", EntryPoint = "#727")]
        public extern static int SHGetImageListHandle(
            int iImageList,
            ref Guid riid,
            ref IntPtr handle
            );

        [DllImport("shell32.dll")]
        public static extern int SHGetDesktopFolder(ref IShellFolder ppshf);
        #endregion

        #region Structures

        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public RECT(int left, int top, int right, int bottom)
           {
              Left = left;
              Top = top;
              Right = right;
              Bottom = bottom;
           }
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            int x;
            int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct IMAGELISTDRAWPARAMS
        {
            public int cbSize;
            public IntPtr himl;
            public int i;
            public IntPtr hdcDst;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public int xBitmap;        // x offest from the upperleft of bitmap
            public int yBitmap;        // y offset from the upperleft of bitmap
            public int rgbBk;
            public int rgbFg;
            public int fStyle;
            public int dwRop;
            public int fState;
            public int Frame;
            public int crEffect;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct IMAGEINFO
        {
            public IntPtr hbmImage;
            public IntPtr hbmMask;
            public int Unused1;
            public int Unused2;
            public RECT rcImage;
        }
        #endregion

        #region Private ImageList COM Interop (XP)
        [ComImportAttribute()]
        [GuidAttribute("46EB5926-582E-4017-9FDF-E8998DAA0950")]
        [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        //helpstring("Image List"),
        public interface IImageList
        {
            [PreserveSig]
            int Add(
                IntPtr hbmImage,
                IntPtr hbmMask,
                ref int pi);

            [PreserveSig]
            int ReplaceIcon(
                int i,
                IntPtr hicon,
                ref int pi);

            [PreserveSig]
            int SetOverlayImage(
                int iImage,
                int iOverlay);

            [PreserveSig]
            int Replace(
                int i,
                IntPtr hbmImage,
                IntPtr hbmMask);

            [PreserveSig]
            int AddMasked(
                IntPtr hbmImage,
                int crMask,
                ref int pi);

            [PreserveSig]
            int Draw(
                ref IMAGELISTDRAWPARAMS pimldp);

            [PreserveSig]
            int Remove(
            int i);

            [PreserveSig]
            int GetIcon(
                int i,
                int flags,
                ref IntPtr picon);

            [PreserveSig]
            int GetImageInfo(
                int i,
                ref IMAGEINFO pImageInfo);

            [PreserveSig]
            int Copy(
                int iDst,
                IImageList punkSrc,
                int iSrc,
                int uFlags);

            [PreserveSig]
            int Merge(
                int i1,
                IImageList punk2,
                int i2,
                int dx,
                int dy,
                ref Guid riid,
                ref IntPtr ppv);

            [PreserveSig]
            int Clone(
                ref Guid riid,
                ref IntPtr ppv);

            [PreserveSig]
            int GetImageRect(
                int i,
                ref RECT prc);

            [PreserveSig]
            int GetIconSize(
                ref int cx,
                ref int cy);

            [PreserveSig]
            int SetIconSize(
                int cx,
                int cy);

            [PreserveSig]
            int GetImageCount(
            ref int pi);

            [PreserveSig]
            int SetImageCount(
                int uNewCount);

            [PreserveSig]
            int SetBkColor(
                int clrBk,
                ref int pclr);

            [PreserveSig]
            int GetBkColor(
                ref int pclr);

            [PreserveSig]
            int BeginDrag(
                int iTrack,
                int dxHotspot,
                int dyHotspot);

            [PreserveSig]
            int EndDrag();

            [PreserveSig]
            int DragEnter(
                IntPtr hwndLock,
                int x,
                int y);

            [PreserveSig]
            int DragLeave(
                IntPtr hwndLock);

            [PreserveSig]
            int DragMove(
                int x,
                int y);

            [PreserveSig]
            int SetDragCursorImage(
                ref IImageList punk,
                int iDrag,
                int dxHotspot,
                int dyHotspot);

            [PreserveSig]
            int DragShowNolock(
                int fShow);

            [PreserveSig]
            int GetDragImage(
                ref POINT ppt,
                ref POINT pptHotspot,
                ref Guid riid,
                ref IntPtr ppv);

            [PreserveSig]
            int GetItemFlags(
                int i,
                ref int dwFlags);

            [PreserveSig]
            int GetOverlayImage(
                int iOverlay,
                ref int piIndex);
        };
        #endregion
    }
}