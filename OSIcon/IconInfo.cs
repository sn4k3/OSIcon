using System;
using System.Drawing;
using OSIcon.WinAPI;

namespace OSIcon
{
    public sealed class IconInfo
    {
        #region Properties
        /// <summary>
        /// Gets the managed icon
        /// </summary>
        public Icon Icon { get; private set; }

        /// <summary>
        /// Gets and converts the <see cref="Icon"/> into a <see cref="Bitmap"/>
        /// </summary>
        public Bitmap Bitmap
        {
            get
            {
                return Icon == null ? null : Icon.ToBitmap();
            }
        }

        /// <summary>
        /// Gets the unmanaged icon handler
        /// </summary>
        public IntPtr HandlerPtr { get; private set; }

        /// <summary>
        /// Gets the icon index
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Gets or sets the index for an associated component at your choice
        /// </summary>
        public int ItemIndex { get; set; }

        /// <summary>
        /// Gets the icon attributes
        /// </summary>
        public Shell32.SHGetFileInfoConstants Attributes { get; private set; }

        /// <summary>
        /// Gets the display name
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// Gets the type name
        /// </summary>
        public string TypeName { get; private set; }

        /// <summary>
        /// Gets if this icon have valid and registed information
        /// </summary>
        public bool HasInfo { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="icon">The managed icon.</param>
        public IconInfo(Icon icon)
        {
            Icon = icon;
            ItemIndex = -1;
            HasInfo = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="icon">The managed icon.</param>
        /// <param name="shfi">The file info structure.</param>
        public IconInfo(Icon icon, Shell32.SHFILEINFO shfi) : this(icon)
        {
            HandlerPtr = shfi.hIcon;
            Index = shfi.iIcon;
            Attributes = shfi.dwAttributes;
            DisplayName = shfi.szDisplayName;
            TypeName = shfi.szTypeName;

            HasInfo = true;
         }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shfi">The file info structure.</param>
        public IconInfo(Shell32.SHFILEINFO shfi) : this(null, shfi)
        {
            if (HandlerPtr != IntPtr.Zero)
            {
                Icon = IconReader.GetManagedIcon(HandlerPtr);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handlerPtr">The icon pointer.</param>
        /// <param name="shfi">The file info structure.</param>
        public IconInfo(IntPtr handlerPtr, Shell32.SHFILEINFO shfi)
            : this(null, shfi)
        {
            HandlerPtr = handlerPtr;
            if (HandlerPtr != IntPtr.Zero)
            {
                Icon = IconReader.GetManagedIcon(HandlerPtr);
            }
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Gets if the icon is valid, ex: not null.
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return !ReferenceEquals(Icon, null);
        }
        #endregion
    }
}
