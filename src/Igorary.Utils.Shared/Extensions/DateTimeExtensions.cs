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
    }
}
