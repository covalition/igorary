using System;
using System.Collections.Generic;
using System.Text;

namespace Igorary.Utils.Extensions
{
    public static class LongExtensions
    {
        public static string ToKB(this long bytes) {
            string[] suffix = new string[] { "B", "kB", "MB", "GB", "TB" };
            float byteNumber = bytes;
            for (int i = 0; i < suffix.Length; i++) {
                if (byteNumber < 1000)
                    if (i == 0)
                        return string.Format("{0} {1}", byteNumber, suffix[i]);
                    else
                        return string.Format("{0:0.#0} {1}", byteNumber, suffix[i]);
                else
                    byteNumber /= 1024;
            }
            return string.Format("{0:N} {1}", byteNumber, suffix[suffix.Length - 1]);
        }

        public static string ToGB(this long bytes) {
            float byteNumber = bytes;
            byteNumber /= (1024 * 1024 * 1024);
            return string.Format("{0:0.00} GB", byteNumber);
        }

        public static string ToKBAndB(this long bytes) {
            string[] suffix = new string[] { "B", "kB", "MB", "GB", "TB" };
            float byteNumber = bytes;
            for (int i = 0; i < suffix.Length; i++) {
                if (byteNumber < 1000)
                    if (i == 0)
                        return string.Format("{0} {1}", byteNumber, suffix[i]);
                    else
                        return string.Format("{0:0.#0} {1} (bytes: {2:#,##0})", byteNumber, suffix[i], bytes);
                else
                    byteNumber /= 1024;
            }
            return string.Format("{0:N} {1} (bytes: {2:#,##0})", byteNumber, suffix[suffix.Length - 1], bytes);
        }
    }
}
