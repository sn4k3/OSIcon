using System;
using System.Runtime.InteropServices;
using System.Text;

namespace OSIcon.WinAPI
{
    /// <summary>
	/// Wraps necessary functions imported from User32.dll. Code courtesy of MSDN Cold Rooster Consulting example.
	/// </summary>
	public static class User32
    {
        #region Delegates
        public delegate bool EnumWindowsCallback(IntPtr hwnd, int lParam);
        #endregion

        #region Enumerations
        public enum LookupIconIdFromDirectoryExFlags
        {
            LR_DEFAULTCOLOR = 0,
            LR_MONOCHROME = 1
        }
        public enum LoadImageTypes
        {
            IMAGE_BITMAP = 0,
            IMAGE_ICON = 1,
            IMAGE_CURSOR = 2
        }
        #endregion

        #region Imports
        /// <summary>
		/// Provides access to function required to delete handle. This method is used internally
		/// and is not required to be called separately.
		/// </summary>
		/// <param name="hIcon">Pointer to icon handle.</param>
		/// <returns>N/A</returns>
		[DllImport("User32.dll")]
		public static extern int DestroyIcon( IntPtr hIcon );

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpszClass, string lpszWindow);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent,
            IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd,
            out uint dwProcessId);

        [DllImport("user32.dll")]
        public static extern void GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern ulong GetWindowLongA(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern int EnumWindows(EnumWindowsCallback lpEnumFunc, int lParam);

        [DllImport("user32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern int LookupIconIdFromDirectory(IntPtr presbits, bool fIcon);

        [DllImport("user32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern int LookupIconIdFromDirectoryEx(IntPtr presbits, bool fIcon, int cxDesired, int cyDesired, LookupIconIdFromDirectoryExFlags Flags);

        [DllImport("user32.dll", EntryPoint = "LoadImageW", SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr LoadImage(IntPtr hInstance, IntPtr lpszName, LoadImageTypes imageType, int cxDesired, int cyDesired, uint fuLoad);
        #endregion

        public static readonly int GWL_STYLE = -16;

        public static readonly ulong WS_VISIBLE = 0x10000000L;
        public static readonly ulong WS_BORDER = 0x00800000L;
        public static readonly ulong TARGETWINDOW = WS_BORDER | WS_VISIBLE;


        public const uint LVM_FIRST = 0x1000;
        public const uint LVM_GETITEMCOUNT = LVM_FIRST + 4;
        public const uint LVM_GETITEMW = LVM_FIRST + 75;
        public const uint LVM_GETITEMPOSITION = LVM_FIRST + 16;
        public const uint PAGE_READWRITE = 4;
        public const int LVIF_TEXT = 0x0001;
        
        public struct LVITEM
        {
            public int mask;
            public int iItem;
            public int iSubItem;
            public int state;
            public int stateMask;
            public IntPtr pszText; // string
            public int cchTextMax;
            public int iImage;
            public IntPtr lParam;
            public int iIndent;
            public int iGroupId;
            public int cColumns;
            public IntPtr puColumns;
        }
    }
}