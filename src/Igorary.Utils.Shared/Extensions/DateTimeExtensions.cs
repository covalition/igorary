using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igorary.Utils.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime Max(this DateTime source, DateTime dateTime) {
            return source > dateTime ? source : dateTime;
        }

        public static DateTime Min(this DateTime source, DateTime dateTime) {
            if (source == default(DateTime))
                return dateTime;
            if (dateTime == default(DateTime))
                return source;
            return source < dateTime ? source : dateTime;
        }

        public static DateTime LastDayOfMonth(this DateTime dateTime) {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
        }

        public static DateTime FirstDayOfMonth(this DateTime dateTime) {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        public static string ToShortDateString(this DateTime? dateTime) {
#if NET45
            return dateTime != null ? dateTime.Value.ToShortDateString() : string.Empty;
#else
            return dateTime?.ToString("d") ?? string.Empty;
#endif
        }
    }
}
