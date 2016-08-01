using System;
using System.Collections.Generic;
using System.Text;

namespace Igorary.Utils.Extensions
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
    }
}
