using System;

namespace Covalition.Igorary.Utils.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime? Max(this DateTime? source, DateTime? dateTime) {
            return Nullable.Compare(source, dateTime) > 0 ? source : dateTime;
        }

        public static DateTime? Min(this DateTime? source, DateTime? dateTime) {
            if (source == null || source == default(DateTime))
                return dateTime;
            if (dateTime == null || dateTime == default(DateTime))
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
            return dateTime?.ToShortDateString() ?? string.Empty;
        }

        public static DateTime RoundSeconds(this DateTime dt) {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Kind);
        }
    }
}
