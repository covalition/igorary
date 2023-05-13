// EnumExtensions.cs
// Copyright (c) 2023 Covalition. All rights reserved.

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Igorary.Utils.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        ///  Returns the value of the <see cref="DisplayAttribute.Name"/> attribute of the enum value or the enum value itself if the attribute is not present.
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum enumValue)
        {
            string res = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()?
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();

            return res ?? enumValue.ToString();
        }

        public static bool In<T>(this T enumValue, params T[] enumSet) where T : Enum
        {
            return enumSet.Contains(enumValue);
        }
    }
}
