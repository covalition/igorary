using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igorary.Utils.Extensions
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
    }
}
