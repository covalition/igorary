using System;
using System.Collections.Generic;
using System.Text;

namespace Covalition.Igorary.Utils.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Convert wildcard to regex
        /// </summary>
        /// <param name="wildcard"></param>
        /// <returns></returns>
        public static string ToRegex(this string wildcard, bool treatFileMaskAsWildcard) {
            string result = "^";
            if (treatFileMaskAsWildcard) // na początku wstaw odpowiednik *
                result += ".*";
            foreach (char c in wildcard) {
                if (c == '*')
                    result += ".*";
                else if (c == '?')
                    result += ".";
                else if (c == ';') {
                    if (treatFileMaskAsWildcard)
                        result += ".*$|^.*";
                    else
                        result += "$|^";
                }
                else if ("+()^$.{}[]|\\".IndexOf(c) != -1)
                    result += "\\" + c;
                else
                    result += c;
            }
            if (treatFileMaskAsWildcard)
                result += ".*$";
            else
                result += "$";
            return result;
        }

        /// <summary>
        /// Returns true when <paramref name="s"/> is null or white space.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string s) => string.IsNullOrWhiteSpace(s);
    }
}
