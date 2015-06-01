// ***********************************************************************
// Assembly         : SaraCms.Lib
// Author           : Michael Randall
// Created          : 06-01-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 06-01-2015
// ***********************************************************************
// <copyright file="NumberHelper.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Lib.Helpers
{
    public class NumberHelper
    {
        /// <summary>
        /// Gets the random identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        public static int GetRandomNumber()
        {
            var random = new RandomNumber();
            return random.Next(4);
        }

        /// <summary>
        /// Gets the random identifier.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>System.String.</returns>
        public static decimal GetRandomDecimal(int min, int max)
        {
            var random = new RandomNumber();
            return (decimal)random.Next(min, max);
        }

        /// <summary>
        /// Gets the random identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        public static decimal GetRandomDecimalTenthPlace()
        {
            var random = new RandomNumber();
            return ((decimal)random.Next(0, 9) / 10);
        }

        /// <summary>
        /// Gets the random identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        public static decimal GetRandomDecimalHundrethPlace()
        {
            var random = new RandomNumber();
            return ((decimal)random.Next(0, 99) / 100);
        }

        /// <summary>
        /// Determines whether the specified value is even.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the specified value is even; otherwise, <c>false</c>.</returns>
        public static bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        /// <summary>
        /// Determines whether the specified value is odd.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the specified value is odd; otherwise, <c>false</c>.</returns>
        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
    }
}
