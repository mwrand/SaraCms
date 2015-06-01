// ***********************************************************************
// Assembly         : STR.ProductReports.Lib
// Author           : Michael Randall
// Created          : 06-01-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 06-01-2015
// ***********************************************************************
// <copyright file="ObjectHelper.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Lib.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    public static class ObjectHelper
    {
        /// <summary>
        /// Determines whether [is i enumerable] [the specified input].
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if [is i enumerable] [the specified input]; otherwise, <c>false</c>.</returns>
        public static bool IsIEnumerable<T>(T input)
        {
            var type = typeof(T);

            var isEnumerable = type.GetInterfaces()       // Get all interfaces.
                .Where(i => i.IsGenericType)               // Filter to only generic.
                .Select(i => i.GetGenericTypeDefinition()).Any(i => i == typeof(IEnumerable<>));

            return isEnumerable;
        }

        /// <summary>
        /// Determines whether [is global user] [the specified country identifier].
        /// USA (Id:9) Canada: (Id:11)  Any property not in Canada or USA is a global property
        /// </summary>
        /// <param name="countryId">The country identifier.</param>
        /// <returns>System.Boolean.</returns>
        public static bool IsGlobalUser(int countryId)
        {
            return (countryId != 9 && countryId != 11);
        }
    }
}