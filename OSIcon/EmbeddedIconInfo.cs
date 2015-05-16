using System;

namespace OSIcon
{
    /// <summary>
    /// Class that encapsulates basic information of icon embedded in a file.
    /// </summary>
    public sealed class EmbeddedIconInfo
    {
        /// <summary>
        /// Gets the file path
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Gets the icon index
        /// </summary>
        public int Index { get; private set; }

        public EmbeddedIconInfo(string fileName, int index)
        {
            FileName = fileName;
            Index = index;
        }


        /// <summary>
        /// Parses a file,index string into a <see cref="EmbeddedIconInfo"/> class.
        /// </summary>
        /// <param name="path">The file path and index params, 
        /// such as ex: "C:\\Program Files\\NetMeeting\\conf.exe,1".</param>
        /// <example>ParseString("C:\\Program Files\\NetMeeting\\conf.exe,1");</example>
        /// <returns><see cref="EmbeddedIconInfo"/></returns>
        public static EmbeddedIconInfo ParseString(string path)
        {
            if (string.IsNullOrEmpty(path))
                return null;

            //Use to store the file contains icon.
            string fileName = path;

            //The index of the icon in the file.
            var iconIndex = 0;
            var iconIndexString = string.Empty;

            var commaIndex = path.IndexOf(",", StringComparison.Ordinal);
            //if fileAndParam is some thing likes that: "C:\\Program Files\\NetMeeting\\conf.exe,1".
            if (commaIndex > 0)
            {
                fileName = path.Substring(0, commaIndex);
                iconIndexString = path.Substring(commaIndex + 1);
            }


            if (!string.IsNullOrEmpty(iconIndexString))
            {
                //Get the index of icon.
                iconIndex = int.Parse(iconIndexString);
                if (iconIndex < 0)
                    iconIndex = 0;  //To avoid the invalid index.
            }

            return new EmbeddedIconInfo(fileName, iconIndex);
        }
    }
}
