using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Igorary.Utils.Extensions
{
    public static class EnumExtensions
    {
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
