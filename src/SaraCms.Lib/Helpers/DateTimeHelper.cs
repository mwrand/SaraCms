// ***********************************************************************
// Assembly         : SaraCms.Lib
// Author           : Michael Randall
// Created          : 06-01-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 05-22-2015
// ***********************************************************************
// <copyright file="DateTimeHelper.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Lib.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Globalization;
    
    public static class DateTimeHelper
    {
        /// <summary>
        /// Converts to date.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>DateTime.</returns>
        public static DateTime ConvertToDate(string input)
        {
            if (input != null && input.Length == 8 && (!input.Contains('-')))
            {
                input = string.Join("-", input.Substring(0, 4), input.Substring(4, 2), input.Substring(6, 2));
            }
            DateTime date;
            var success = DateTime.TryParse(input, out date);
            return success ? date : DateTime.MinValue;
        }

        /// <summary>
        /// Days the between.
        /// </summary>
        /// <param name="d0">The d0.</param>
        /// <param name="d1">The d1.</param>
        /// <returns>IEnumerable&lt;DateTime&gt;.</returns>
        public static IEnumerable<DateTime> DaysBetween(DateTime d0, DateTime d1)
        {
            return Enumerable.Range(0, 1 + d1.Subtract(d0).Days)
                             .Select(offset => d0.AddDays(offset));
        }

        /// <summary>
        /// Firsts the date of month.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>DateTime.</returns>
        public static DateTime FirstDateOfMonth(DateTime input)
        {
            return new DateTime(input.Year, input.Month, 1);
        }

        /// <summary>
        /// First the date of year.
        /// </summary>
        /// <param name="input">The today.</param>
        /// <returns>DateTime.</returns>
        public static DateTime FirstDateOfYear(DateTime input)
        {
            return new DateTime(input.Year, 1, 1);
        }

        /// <summary>
        /// Firsts the day of week.
        /// </summary>
        /// <param name="input">The today.</param>
        /// <returns>DateTime.</returns>
        public static DateTime FirstDateOfWeek(DateTime input)
        {
            var delta = DayOfWeek.Sunday - input.DayOfWeek;
            return input.AddDays(delta);
        }

        /// <summary>
        /// Firsts the date of week.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="weekOfYear">The week of year.</param>
        /// <param name="ci">The ci.</param>
        /// <returns>DateTime.</returns>
        public static DateTime FirstDateOfWeek(int year, int weekOfYear, CultureInfo ci)
        {
            var jan1 = new DateTime(year, 1, 1);
            var daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            var firstWeekDay = jan1.AddDays(daysOffset);
            var firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);

            if (firstWeek <= 1 || firstWeek > 50)  weekOfYear -= 1;

            return firstWeekDay.AddDays(weekOfYear * 7);
        }

        /// <summary>
        /// Firsts the tick of day.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>DateTime.</returns>
        public static DateTime FirstTickOfDay(DateTime input)
        {
            return new DateTime(input.Year, input.Month, input.Day);
        }

        /// <summary>
        /// Iso8601s the week of year.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>System.Int32.</returns>
        public static int Iso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        /// <summary>
        /// Lasts the date of month.
        /// </summary>
        /// <param name="input">The today.</param>
        /// <returns>DateTime.</returns>
        public static DateTime LastDateOfMonth(DateTime input)
        {
            return new DateTime(input.Year, input.Month, DateTime.DaysInMonth(input.Year, input.Month));
        }

        /// <summary>
        /// Lasts the tick of day.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>DateTime.</returns>
        public static DateTime LastTickOfDay(DateTime input)
        {
            var date = new DateTime(input.Year, input.Month, input.Day);
            return date.AddDays(1).AddTicks(-1);
        }

        /// <summary>
        /// Lasts the year same day of week.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>DateTime.</returns>
        public static DateTime LastYearSameDayOfWeek(DateTime input)
        {
            return input.AddDays(-364);
        }

        /// <summary>
        /// Monthses the between.
        /// </summary>
        /// <param name="d0">The d0.</param>
        /// <param name="d1">The d1.</param>
        /// <returns>IEnumerable&lt;DateTime&gt;.</returns>
        public static IEnumerable<DateTime> MonthsBetween(DateTime d0, DateTime d1)
        {
            return Enumerable.Range(0, (d1.Year - d0.Year) * 12 + (d1.Month - d0.Month + 1))
                             .Select(m => new DateTime(d0.Year, d0.Month, 1).AddMonths(m));
        }
    }
}
