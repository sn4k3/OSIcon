/*
 * OSIcon
 * Author: Tiago Conceição
 * 
 * https://github.com/sn4k3/OSIcon
 * http://www.codeproject.com/Articles/50064/OSIcon
 */
using System;

namespace OSIcon
{
    /// <summary>
    /// Options to specify the size of icons to return.
    /// </summary>
    [Flags]
    public enum IconSize : uint
    {

        /// <summary>
        /// Specify large icon - 32 pixels by 32 pixels.
        /// </summary>
        Large = 0x0,
        /// <summary>
        /// Specify small icon - 16 pixels by 16 pixels.
        /// </summary>
        Small = 0x1,
        /// <summary>
        /// Specify extra large icon - 48 pixels by 48 pixels.
        /// Only available under XP and latter; other OS return the Large Icon ImageList.
        /// </summary>
        ExtraLarge = 0x2,

        /// <summary>
        /// These images are the size specified by GetSystemMetrics called with SM_CXSMICON and GetSystemMetrics called with SM_CYSMICON.
        /// </summary>
        //SysSmall = 0x3,

        /// <summary>
        /// Windows Vista and later. The image is normally 256x256 pixels.
        /// </summary>
        Jumbo = 0x4
    }
}
