// DateTimeExtensions.cs
// Copyright (c) 2023 Covalition. All rights reserved.

using System;

namespace Igorary.Utils.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime? Max(this DateTime? source, DateTime? dateTime)
        {
            return Nullable.Compare(source, dateTime) > 0 ? source : dateTime;
        }

        public static DateTime? Min(this DateTime? source, DateTime? dateTime)
        {
            if (source == null || source == default(DateTime))
                return dateTime;
            if (dateTime == null || dateTime == default(DateTime))
                return source;
            return source < dateTime ? source : dateTime;
        }

        public static DateTime LastDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
        }

        public static DateTime FirstDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        public static string ToShortDateString(this DateTime? dateTime)
        {
            return dateTime?.ToShortDateString() ?? string.Empty;
        }

        public static DateTime RoundSeconds(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Kind);
        }

        /// <summary>
        /// Returns the number of days between two dates.
        /// </summary>
        public static int CalculateDays(this DateTime startDate, DateTime endDate)
        {
            return (int)(endDate - startDate).TotalDays;
        }

        /// <summary>
        /// Creates a string representation of the time span in relation to <paramref name="referenceDate"/>. 
        /// </summary>
        /// <param name="date">The date to convert to a relative date.</param>
        /// <param name="referenceDate">The date to compare to. If null, DateTime.Now is used.</param>
        /// <returns>A string representation of the time span in relation to <paramref name="referenceDate"/>.</returns>
        /// <remarks>
        /// The following table shows the output of this method for different time spans:
        /// <list type="table">
        /// <listheader>
        /// <term>Time Span</term>
        /// <description>Output</description>
        /// </listheader>
        /// <item>
        /// <term>Less than 1 minute</term>
        /// <description>seconds ago</description>
        /// </item>
        /// <item>
        /// <term>Less than 2 minutes</term>
        /// <description>a minute ago</description>
        /// </item>
        /// <item>
        /// <term>Less than 45 minutes</term>
        /// <description>minutes ago</description>
        /// </item>
        /// <item>
        /// <term>Less than 90 minutes</term>
        /// <description>an hour ago</description>
        /// </item>
        /// <item>
        /// <term>Less than 24 hours</term>
        /// <description>hours ago</description>
        /// </item>
        /// <item>
        /// <term>Less than 48 hours</term>
        /// <description>yesterday</description>
        /// </item>
        /// <item>
        /// <term>Less than 30 days</term>
        /// <description>days ago</description>
        /// </item>
        /// <item>
        /// <term>Less than 12 months</term>
        /// <description>months ago</description>
        /// </item>
        /// <item>
        /// <term>More than 12 months</term>
        /// <description>years ago</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static string ToRelativeDate(this DateTime date, DateTime? referenceDate = null)
        {
            if (referenceDate == null)
                referenceDate = DateTime.Now;
            
            var ts = new TimeSpan(referenceDate.Value.Ticks - date.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if(delta >= 0)
                return "now or in the future";

            if (delta < 60)
            {
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }
            if (delta < 120)
            {
                return "a minute ago";
            }
            if (delta < 2700) // 45 * 60
            {
                return ts.Minutes + " minutes ago";
            }
            if (delta < 5400) // 90 * 60
            {
                return "an hour ago";
            }
            if (delta < 86400) // 24 * 60 * 60
            {
                return ts.Hours + " hours ago";
            }
            if (delta < 172800) // 48 * 60 * 60
            {
                return "yesterday";
            }
            if (delta < 2592000) // 30 * 24 * 60 * 60
            {
                return ts.Days + " days ago";
            }
            if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "one year ago" : years + " years ago";
        }
    }
}
