// StringExtensions.cs
// Copyright (c) 2023 Covalition. All rights reserved.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Igorary.Utils.Extensions
{
    public enum ConvertTo
    {
        Upper, Lower
    }

    public static class StringExtensions
    {
        /// <summary>
        /// Convert wildcard to regex
        /// </summary>
        /// <param name="wildcard"></param>
        /// <returns></returns>
        public static string ToRegex(this string wildcard, bool treatFileMaskAsWildcard)
        {
            string result = "^";
            if (treatFileMaskAsWildcard) // na początku wstaw odpowiednik *
                result += ".*";
            foreach (char c in wildcard)
            {
                if (c == '*')
                    result += ".*";
                else if (c == '?')
                    result += ".";
                else if (c == ';')
                {
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
        public static bool IsEmpty(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        public static string ReplaceLast(this string s, string oldValue, string newValue)
        {
            if (oldValue?.Length > 0)
            {
                int i = s.LastIndexOf(oldValue);
                if (i >= 0)
                    return s.Remove(i, oldValue.Length).Insert(i, newValue);
            }
            if (s == oldValue) // s.Length == oldValue.Length == 0
                return newValue;
            return s;
        }

        public static string FirstLetterTo(this string s, ConvertTo convertTo)
        {
            if (s == null)
                return null;
            if (s.Length > 1)
                return (convertTo == ConvertTo.Upper ? char.ToUpper(s[0]) : char.ToLower(s[0])) + s.Substring(1);
            return convertTo == ConvertTo.Upper ? s.ToUpper() : s.ToLower();
        }

        public static string[] SplitCamelCase(this string s)
        {
            return Regex.Split(s, @"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);
        }

        public static string ToTitle(this string s)
        {
            return string.Join(" ", s.SplitCamelCase().Select(w => w.FirstLetterTo(ConvertTo.Upper)));
        }

        public static string ToIdentifierWithHyphens(this string s)
        {
            return string.Join("-", s.SplitCamelCase().Select(w => w.FirstLetterTo(ConvertTo.Lower)));
        }

        public static string Truncate(this string s, int maxLength, string ending = null)
        {
            if (s == null || s.Length <= maxLength)
                return s;

            string truncatedString = s.Substring(0, maxLength);

            return ending == null ? truncatedString : truncatedString + ending;
        }

        public static T DeserializeXml<T>(this string toDeserialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader textReader = new StringReader(toDeserialize))
            {
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }

        public static string ToNullIfEmpty(this string s)
        {
            return s.IsEmpty() ? null : s;
        }

        public static IEnumerable<string> SplitBy(this string source, int maxChunkSize)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (maxChunkSize < 1)
                throw new ArgumentException("Value is less than 1.", nameof(maxChunkSize));

            for (int i = 0; i < source.Length; i += maxChunkSize)
                yield return source.Substring(i, Math.Min(maxChunkSize, source.Length - i));
        }
    }
}
