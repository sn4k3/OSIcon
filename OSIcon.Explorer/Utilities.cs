using System;

namespace OSIcon.Explorer
{
    public static class Utilities
    {
        
        const int CONVERSION_VALUE = 1024;
        public enum SizeBytes : ulong
        {
            BY = 1, // Byte
            KB = CONVERSION_VALUE * BY, // Kilobyte
            MB = CONVERSION_VALUE * KB, // Megabyte
            GB = CONVERSION_VALUE * MB, // Gigabyte
            TB = CONVERSION_VALUE * GB, // Terabyte
        }

        public static double ConvertSize(long bytes, SizeBytes type)
        {
            //determine what conversion they want
            switch (type)
            {
                case SizeBytes.BY:
                    //convert to bytes (default)
                    return bytes;
                case SizeBytes.KB:
                    //convert to kilobytes
                    return (bytes / CONVERSION_VALUE);
                case SizeBytes.MB:
                    //convert to megabytes
                    return (bytes / Math.Pow(CONVERSION_VALUE, 2));
                case SizeBytes.GB:
                    //convert to gigabytes
                    return (bytes / Math.Pow(CONVERSION_VALUE, 3));
                case SizeBytes.TB:
                    //convert to terabytes
                    return (bytes / Math.Pow(CONVERSION_VALUE, 4));
                default:
                    //default
                    return bytes;
            }
        }

        public static double FormatByteSize(long bytes)
        {
            if (bytes > (long)SizeBytes.TB)
                return ConvertSize(bytes, SizeBytes.TB);
            if (bytes > (int)SizeBytes.GB)
                return ConvertSize(bytes, SizeBytes.GB);
            if (bytes > (int)SizeBytes.MB)
                return ConvertSize(bytes, SizeBytes.MB);
            if (bytes > (int)SizeBytes.KB)
                return ConvertSize(bytes, SizeBytes.KB);
            return bytes;
        }

        public static double ConvertSizeToOther(double value, SizeBytes from, SizeBytes to)
        {
            if (from == to) return value;
            double bytes = value;
            switch (from)
            {
                /* case SizeBytes.BY:
                     bytes = value;
                     break;*/
                case SizeBytes.KB:
                    bytes = value * CONVERSION_VALUE;
                    break;
                case SizeBytes.MB:
                    bytes = value * Math.Pow(CONVERSION_VALUE, 2);
                    break;
                case SizeBytes.GB:
                    bytes = value * Math.Pow(CONVERSION_VALUE, 3);
                    break;
                case SizeBytes.TB:
                    bytes = value * Math.Pow(CONVERSION_VALUE, 4);
                    break;
            }
            return to == SizeBytes.BY ? bytes : ConvertSize((long)bytes, to);
        }

        public static string GetSizeNameFromBytes(long bytes, bool longName)
        {
            if (bytes > (long)SizeBytes.TB)
                return longName ? "Terabyte(s)" : "TB";
            if (bytes > (int)SizeBytes.GB)
                return longName ? "Gigabyte(s)" : "GB";
            if (bytes > (int)SizeBytes.MB)
                return longName ? "Megabyte(s)" : "MB";
            if (bytes > (int)SizeBytes.KB)
                return longName ? "Kilobyte(s)" : "KB";
            return longName ? "Byte(s)" : "B";
        }
    }
}