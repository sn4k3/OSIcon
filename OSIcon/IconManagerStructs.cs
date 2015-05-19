/*
 * OSIcon
 * Author: Tiago Conceição
 * 
 * https://github.com/sn4k3/OSIcon
 * http://www.codeproject.com/Articles/50064/OSIcon
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace OSIcon
{
    public partial class IconManager
    {
        public class IconProperties : IDisposable, IEnumerable<IconInfo>
        {
            #region Properties
            /// <summary>
            /// Store all icons, indexes and information,
            /// Shell32.SHFILEINFO
            /// </summary>
            public Dictionary<IconSize, IconInfo> IconsInfo { get; private set; }

            /// <summary>
            /// Store any optional data you want
            /// </summary>
            public object Tag { get; set; }

            #endregion

            #region Constructors
            /// <summary>
            /// Initialize Class
            /// </summary>
            public IconProperties()
            {
                IconsInfo = new Dictionary<IconSize, IconInfo>();
                Tag = null;
            }
            #endregion

            #region IsValid Methods
            /// <summary>
            /// Check if class has a icon size
            /// </summary>
            public bool HasKey(IconSize size)
            {
                return IconsInfo.ContainsKey(size);
            }
            /// <summary>
            /// Check if class contain any icon size
            /// </summary>
            public bool HasAnyKey()
            {
                return IconsInfo.ContainsKey(IconSize.Small) || IconsInfo.ContainsKey(IconSize.Large) || IconsInfo.ContainsKey(IconSize.ExtraLarge) || IconsInfo.ContainsKey(IconSize.Jumbo);
            }
            /// <summary>
            /// Check if class contain a icon
            /// And if that icon is not null
            /// </summary>
            /// <param name="size">Icon Size to check</param>
            public bool IsValidEx(IconSize size)
            {
                return HasKey(size) && IconsInfo[size].IsValid();
            }

            public IconProperties FirstValid()
            {
                return this;
            }
            #endregion

            #region Remove Methods
            /// <summary>
            /// Remove all icons from a specified icon size, 
            /// Supports multi sizes flags
            /// </summary>
            /// <param name="iconSize">Icon Size to remove, support multi size flags</param>
            /// <returns>A dictionary with removed icons (size and their index on ListImage)</returns>
            public Dictionary<IconSize, int> Remove(IconSize iconSize)
            {
                var removedIcons = new Dictionary<IconSize, int>();

                foreach (IconSize size in Enum.GetValues(typeof(IconSize)))
                {
                    if ((iconSize & size) != size) continue;
                    if (!IconsInfo.ContainsKey(size)) continue;

                    if (IconsInfo[size].ItemIndex >= 0)
                        removedIcons.Add(size, IconsInfo[size].ItemIndex);
                    IconsInfo.Remove(size);
                }
                return removedIcons;
            }
            #endregion

            #region Indexers
            public IconInfo this[IconSize size]
            {
                get
                {
                    return IconsInfo[size];
                }
            }
            #endregion

            #region Dispose
            /// <summary>
            /// Free all resources used by that class.
            /// </summary>
            public void Dispose()
            {
                // Dispose Icon
                foreach (var icon in IconsInfo)
                {
                    icon.Value.Icon.Dispose();
                }
                IconsInfo.Clear();
                IconsInfo = null;
            }
            #endregion

            #region Enumerable
            public IEnumerator<IconInfo> GetEnumerator()
            {
                return IconsInfo.Values.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            #endregion
        }
    }
}