/*
 * OSIcon
 * Author: Tiago Conceição
 * 
 * https://github.com/sn4k3/OSIcon
 * http://www.codeproject.com/Articles/50064/OSIcon
 */
using System;
using System.Runtime.InteropServices;

namespace OSIcon.WinAPI
{
    public static class DwmApi
    {
        #region DllImports
        /// <summary>
        /// Used to register interest in receiving a thumbnail from hwndSource (the target window's handle).
        /// The hwndDestination parameter is used to specify the handle of the window where the thumbnail has to be painted to
        /// (in the region specified by DwmUpdateThumbnailProperties, see further).
        /// Last but not least, there's a (output) parameter that gives us a handle to the thumbnail object, used for further API calls.
        /// HRESULT DwmRegisterThumbnail(HWND hwndDestination, HWND *hwndSource, PHTHUMBNAIL phThumbnailId );
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="src"></param>
        /// <param name="thumb"></param>
        [DllImport("dwmapi.dll")]
        public static extern int DwmRegisterThumbnail(IntPtr dest, IntPtr src, out IntPtr thumb);

        /// <summary>
        /// Used to unregister interest in receiving the thumbnail that was obtained earlier through DwmRegisterThumbnail.
        /// HRESULT DwmUnregisterThumbnail(HTHUMBNAIL hThumbnailId);
        /// </summary>
        /// <param name="thumb"></param>
        /// <returns></returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmUnregisterThumbnail(IntPtr thumb);

        /// <summary>
        /// Want to know the size of the target window associated with a given thumbnail
        /// (in order to decide on scaling of the thumbnail in the call to DwmUpdateThumbnailProperties)? 
        /// Use this function:
        /// HRESULT DwmQueryThumbnailSourceSize(HTHUMBNAIL hThumbnail,PSIZE pSize);
        /// </summary>
        /// <param name="thumb"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmQueryThumbnailSourceSize(IntPtr thumb, out PSIZE size);

        /// <summary>
        /// The last and maybe the most important function is this one.
        /// It's used to configure the thumbnail properties.
        /// By doing so, the DWM knows what kind of thumbnail you want to receive (opaque, format, source window region, etc).
        /// HRESULT DwmUpdateThumbnailProperties(HTHUMBNAIL hThumbnailId,const DWM_THUMBNAIL_PROPERTIES *ptnProperties);
        /// </summary>
        /// <param name="hThumb"></param>
        /// <param name="props"></param>
        /// <returns></returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmUpdateThumbnailProperties(IntPtr hThumb, ref DWM_THUMBNAIL_PROPERTIES props);
        #endregion

        #region Structs
        /// <summary>
        /// The PSIZE object is a struct containing the width (x) and height (y)
        /// of the window associated with the thumbnail (thumb) and serves as the function's output value:
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct PSIZE
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DWM_THUMBNAIL_PROPERTIES
        {
            public int dwFlags;
            public Shell32.RECT rcDestination;
            public Shell32.RECT rcSource;
            public byte opacity;
            public bool fVisible;
            public bool fSourceClientAreaOnly;
        }
        #endregion

        #region Enums
        [Flags]
        public enum DWM
        {
            TNP_VISIBLE = 0x8,
            TNP_OPACITY = 0x4,
            TNP_RECTDESTINATION = 0x1
        }
        #endregion
    }
}