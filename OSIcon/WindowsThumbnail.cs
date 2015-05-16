using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using OSIcon.WinAPI;

namespace OSIcon
{
    public class WindowsThumbnail : IDisposable, IEnumerable<WindowsThumbnail.Window>
    {
        #region Classes

        public class Window
        {
            /// <summary>
            /// Gets the windows main title
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// Gets the window handle
            /// </summary>
            public IntPtr Handle { get; set; }

            public Window(string title, IntPtr handle)
            {
                Title = title;
                Handle = handle;
            }

            public override string ToString()
            {
                return Title;
            }
        }

        #endregion

        #region Properties
        /// <summary>
        /// In order to obtain thumbnails we need to register our interest to receive a thumbnail.
        /// </summary>
        public IntPtr Thumb { get; private set; }

        /// <summary>
        /// List with active windows
        /// </summary>
        public List<Window> Windows { get; private set; }

        /// <summary>
        /// Gets the list of the ignored windows handlers.
        /// </summary>
        public List<IntPtr> IgnoredHandlers { get; private set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="getAll">Get all windows and populate this class.</param>
        public WindowsThumbnail(bool getAll = false)
        {
            Windows = new List<Window>();
            IgnoredHandlers = new List<IntPtr>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Retrieve all active windows
        /// </summary>
        public void Refresh(bool unregister = false)
        {
            Windows.Clear();
            if (unregister)
                Unregister();
            User32.EnumWindows(Callback, 0);
        }

        /// <summary>
        /// Add a <see cref="IntPtr"/> to the ignored list
        /// </summary>
        /// <param name="hwnd"><see cref="IntPtr"/> to ignore.</param>
        public void AddIgnoredHandler(IntPtr hwnd)
        {
            IgnoredHandlers.Add(hwnd);
        }

        /// <summary>
        /// Register a thumbnail to show and render
        /// </summary>
        /// <param name="handle">Handler to register</param>
        /// <param name="window">Window or thumbnail handle to register</param>
        /// <returns>True if register, otherwise false</returns>
        public bool Register(IntPtr handle, Window window)
        {
            return Register(handle, window.Handle);
        }

        /// <summary>
        /// Register a thumbnail to show and render
        /// </summary>
        /// <param name="handle">Handler to register</param>
        /// <param name="windowHandle">Window or thumbnail handle to register</param>
        /// <returns>True if register, otherwise false</returns>
        public bool Register(IntPtr handle, IntPtr windowHandle)
        {
            if (Thumb != IntPtr.Zero)
                DwmApi.DwmUnregisterThumbnail(Thumb);

            IntPtr thumb;
            var i = DwmApi.DwmRegisterThumbnail(handle, windowHandle, out thumb);
            Thumb = thumb;
            return i == 0;
        }

        /// <summary>
        /// Un register last used thumbnail.
        /// </summary>
        public void Unregister()
        {
            if (Thumb != IntPtr.Zero)
                DwmApi.DwmUnregisterThumbnail(Thumb);
        }

        public void RenderThumbnail(Rectangle rect, byte opacity = 100)
        {
            if (Thumb == IntPtr.Zero) return;
            DwmApi.PSIZE size;
            DwmApi.DwmQueryThumbnailSourceSize(Thumb, out size);

            // Flags
            var props = new DwmApi.DWM_THUMBNAIL_PROPERTIES
            {
                dwFlags = (int) (DwmApi.DWM.TNP_VISIBLE | DwmApi.DWM.TNP_RECTDESTINATION | DwmApi.DWM.TNP_OPACITY),
                // Is visible?
                fVisible = true,
                // Set opacity
                opacity = opacity,
                rcDestination = new Shell32.RECT(rect.Left, rect.Top, rect.Right, rect.Bottom)
            };

            // Position to draw image
            if (size.x < rect.Width)
                props.rcDestination.Right = props.rcDestination.Left + size.x;
            if (size.y < rect.Height)
                props.rcDestination.Bottom = props.rcDestination.Top + size.y;

            // Update Thumb
            DwmApi.DwmUpdateThumbnailProperties(Thumb, ref props);
        }
        #endregion

        #region Callback
        /// <summary>
        /// Callback for User32.EnumWindows
        /// </summary>
        private bool Callback(IntPtr hwnd, int lParam)
        {
            if (IgnoredHandlers.Contains(hwnd) ||
                (User32.GetWindowLongA(hwnd, User32.GWL_STYLE) & User32.TARGETWINDOW) != User32.TARGETWINDOW)
                return true; //continue enumeration
            var sb = new StringBuilder(200);
            User32.GetWindowText(hwnd, sb, sb.Capacity);
            if (sb.Length == 0) return true;
            var t = new Window(sb.ToString(), hwnd);
            Windows.Add(t);

            return true; //continue enumeration
        }
        #endregion

        #region Implementations
        public void Dispose()
        {
            Unregister();
        }

        public IEnumerator<Window> GetEnumerator()
        {
            return Windows.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
