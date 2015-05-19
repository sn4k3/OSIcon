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
    public static class Comctl32
    {
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
            public int xBitmap;
            public int yBitmap;
            public int rgbBk;
            public int rgbFg;
            public int fStyle;
            public int dwRop;
            public int fState;
            public int Frame;
            public int crEffect;
        }

        [Flags]
        public enum ImageListDrawItemConstants
        {
            /// <summary>
            /// Draw item normally.
            /// </summary>
            ILD_NORMAL = 0x0,
            /// <summary>
            /// Draw item transparently.
            /// </summary>
            ILD_TRANSPARENT = 0x1,
            /// <summary>
            /// Draw item blended with 25% of the specified foreground colour
            /// or the Highlight colour if no foreground colour specified.
            /// </summary>
            ILD_BLEND25 = 0x2,
            /// <summary>
            /// Draw item blended with 50% of the specified foreground colour
            /// or the Highlight colour if no foreground colour specified.
            /// </summary>
            ILD_SELECTED = 0x4,
            /// <summary>
            /// Draw the icon's mask
            /// </summary>
            ILD_MASK = 0x10,
            /// <summary>
            /// Draw the icon image without using the mask
            /// </summary>
            ILD_IMAGE = 0x20,
            /// <summary>
            /// Draw the icon using the ROP specified.
            /// </summary>
            ILD_ROP = 0x40,
            /// <summary>
            /// ?
            /// </summary>
            ILD_OVERLAYMASK = 0xF00,
            /// <summary>
            /// Preserves the alpha channel in dest. XP only.
            /// </summary>
            ILD_PRESERVEALPHA = 0x1000, // 
            /// <summary>
            /// Scale the image to cx, cy instead of clipping it.  XP only.
            /// </summary>
            ILD_SCALE = 0x2000,
            /// <summary>
            /// Scale the image to the current DPI of the display. XP only.
            /// </summary>
            ILD_DPISCALE = 0x4000
        }

        [DllImport("comctl32")]
        public extern static int ImageList_DrawIndirect(
            ref IMAGELISTDRAWPARAMS pimldp);

        [DllImport("comctl32")]
        public extern static int ImageList_GetIconSize(
            IntPtr himl,
            ref int cx,
            ref int cy);

        [DllImport("comctl32")]
        public extern static IntPtr ImageList_GetIcon(
            IntPtr himl,
            int i,
            int flags);
    }
}