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
    public partial class Main : Form
    {
        #region Constructor
        public Main()
        {
            InitializeComponent();
            // Disable Tests tab for public release
            tbTests.Enabled = false;
            tabC.Controls.Remove(tbTests);
        }
        #endregion

        #region Overrides
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Disable "Windows Thumbnails" tab because only Vista or above support this
            if (!Utilities.IsVistaOrAbove())
                tbWindowsThumbnails.Enabled = false;
        }
        #endregion

        /*
         * New Features test
         * Please not use
         * 
         */
        private void button1_Click(object sender, EventArgs e)
        {
            return;
            /*IShellFolder sdf = null;
            IEnumIDList idlist = null;
            IntPtr hh = IntPtr.Zero;
            //Kernel32.ZeroMemory(sdf as IntPtr, (IntPtr)Marshal.SizeOf(sdf));
            Shell32.SHGetDesktopFolder(ref sdf);
            sdf.EnumObjects(IntPtr.Zero, ESHCONTF.SHCONTF_FOLDERS | ESHCONTF.SHCONTF_NONFOLDERS, out hh);
            idlist = (IEnumIDList)Marshal.GetTypedObjectForIUnknown(hh, typeof(IEnumIDList));
            IntPtr gelt;
            int celtFetched;

            // enumerate founded objects
            listView1.View = View.Details;
            const Shell32.SHGetFileInfoConstants flags = Shell32.SHGetFileInfoConstants.SHGFI_DISPLAYNAME | Shell32.SHGetFileInfoConstants.SHGFI_PIDL |
                                                 Shell32.SHGetFileInfoConstants.SHGFI_TYPENAME | Shell32.SHGetFileInfoConstants.SHGFI_ICON |
                                                 Shell32.SHGetFileInfoConstants.SHGFI_SHELLICONSIZE | Shell32.SHGetFileInfoConstants.SHGFI_SYSICONINDEX;
            while (idlist.Next(1, out gelt, out celtFetched) == 0 && celtFetched == 1)
            {
                // get display name of object
                Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();
                Shell32.SHGetFileInfo(gelt, 0, ref shfi, Marshal.SizeOf(typeof(Shell32.SHFILEINFO)), flags);
                // add object to list
                listView1.Items.Add(shfi.szDisplayName);
                Icon icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                User32.DestroyIcon(shfi.hIcon);
                icon.ToBitmap().Save("C:\\"+shfi.szDisplayName+".png");
            }
            return;
            // get the handle of the desktop listview
            IntPtr vHandle = User32.FindWindow("Progman", "Program Manager");
            vHandle = User32.FindWindowEx(vHandle, IntPtr.Zero, "SHELLDLL_DefView", null);
            vHandle = User32.FindWindowEx(vHandle, IntPtr.Zero, "SysListView32", "FolderView");
 
            //Get total count of the icons on the desktop
            int vItemCount = User32.SendMessage(vHandle, User32.LVM_GETITEMCOUNT, 0, 0);
            //this.label1.Text = vItemCount.ToString();
           
            uint vProcessId;
            User32.GetWindowThreadProcessId(vHandle, out vProcessId);

            IntPtr vProcess = Kernel32.OpenProcess(Kernel32.PROCESS_VM_OPERATION | Kernel32.PROCESS_VM_READ |
                Kernel32.PROCESS_VM_WRITE, false, vProcessId);
            IntPtr vPointer = Kernel32.VirtualAllocEx(vProcess, IntPtr.Zero, 4096,
                Kernel32.MEM_RESERVE | Kernel32.MEM_COMMIT, User32.PAGE_READWRITE);
            try
            {
                for (int j = 0; j < vItemCount; j++)
                {
                    byte[] vBuffer = new byte[256];
                    User32.LVITEM[] vItem = new User32.LVITEM[1];
                    vItem[0].mask = User32.LVIF_TEXT;
                    vItem[0].iItem = j;
                    vItem[0].iSubItem = 0;
                    vItem[0].cchTextMax = vBuffer.Length;
                    vItem[0].pszText = (IntPtr)((int)vPointer + Marshal.SizeOf(typeof(User32.LVITEM)));
                    uint vNumberOfBytesRead = 0;
 
                    Kernel32.WriteProcessMemory(vProcess, vPointer,
                        Marshal.UnsafeAddrOfPinnedArrayElement(vItem, 0),
                        Marshal.SizeOf(typeof(User32.LVITEM)), ref vNumberOfBytesRead);
                    User32.SendMessage(vHandle, User32.LVM_GETITEMW, j, vPointer.ToInt32());
                    Kernel32.ReadProcessMemory(vProcess,
                        (IntPtr)((int)vPointer + Marshal.SizeOf(typeof(User32.LVITEM))),
                        Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0),
                        vBuffer.Length, ref vNumberOfBytesRead);
                    string vText = Encoding.Unicode.GetString(vBuffer, 0,
                        (int)vNumberOfBytesRead);
                    string IconName = vText;
                    //Get icon location
                    User32.SendMessage(vHandle, User32.LVM_GETITEMPOSITION, j, vPointer.ToInt32());
                    Point[] vPoint = new Point[1];
                    Kernel32.ReadProcessMemory(vProcess, vPointer,
                        Marshal.UnsafeAddrOfPinnedArrayElement(vPoint, 0),
                        Marshal.SizeOf(typeof(Point)), ref vNumberOfBytesRead);
                    string IconLocation = vPoint[0].ToString();

                    //IntPtr iList = (IntPtr)User32.SendMessage(vHandle, User32.LVM_GETIMAGELIST, 1, 0);
                    //IntPtr icon = Comctl32.ImageList_GetIcon(iList, j, 1);
                    //Insert an item into the ListView
                    listView1.Items.Add(new ListViewItem(new 
                      string[]{IconName,IconLocation}));

                }
            }
            finally
            {
                Kernel32.VirtualFreeEx(vProcess, vPointer, 0, Kernel32.MEM_RELEASE);
                Kernel32.CloseHandle(vProcess);
            }
 
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);*/
        }

        private void tabC_SelectedIndexChanged(object sender, EventArgs e)
        {
            windowsThumbnails.WindowsThumbnail.Unregister();
        }
    }
}
