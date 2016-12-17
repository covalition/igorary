using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covalition.Igorary.Utils
{
    public static class DateTimeUtils
    {
        /// <param name="from1">Dolna granica badanego zakresu</param>
        /// <param name="to1">Górna granica badanego zakresu</param>
        /// <param name="from2">Dolna granica zakresu odniesienia</param>
        /// <param name="to2">Górna granica zakresu odniesienia</param>
        /// <returns></returns>
        public static bool OverlapRange(DateTime from1, DateTime to1, DateTime? from2, DateTime? to2, bool includeEndRange = false) {
            return (from2 == null || to1 >= from2) && (to2 == null || (includeEndRange ? from1 <= to2 : from1 < to2));
        }

        /// <summary>
        /// Liczba godzin części wspólnej dwóch przedziałów
        /// </summary>
        /// <param name="from1"></param>
        /// <param name="to1"></param>
        /// <param name="from2"></param>
        /// <param name="to2"></param>
        /// <returns></returns>
        public static double GetTotalHours(DateTime from1, DateTime to1, DateTime? from2, DateTime? to2) {
            if (from2 != null && from2 > from1)
                from1 = from2.Value;
            if (to2 != null && to2 < to1)
                to1 = to2.Value;
            return (to1 - from1).TotalHours;
        }

        /// <summary>
        /// Stosunek części wspólnej do pierwszego przedziału
        /// </summary>
        /// <param name="from1"></param>
        /// <param name="to1"></param>
        /// <param name="from2"></param>
        /// <param name="to2"></param>
        /// <returns></returns>
        public static double GetFraction(DateTime from1, DateTime to1, DateTime? from2, DateTime? to2) {
            return GetTotalHours(from1, to1, from2, to2) / (to1 - from1).TotalHours;
        }
    }
}