// ***********************************************************************
// Assembly         : STR.ProductReports.Lib
// Author           : Michael Randall
// Created          : 03-20-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 05-07-2015
// ***********************************************************************
// <copyright file="StringHelpers.cs" company="STR">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Lib.Helpers
{
    using SaraCms.Lib;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public static class StringHelper
    {
        /// <summary>
        /// Capitalizes the first character.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string CapitalizeFirstCharacter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            var a = input.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        /// <summary>
        /// Gets the CSV list.
        /// </summary>
        /// <param name="enumNames">The enum names.</param>
        /// <returns>System.String.</returns>
        public static string GetCsvList(string[] enumNames)
        {
            return String.Join(", ", enumNames).ToLower();
        }

        /// <summary>
        /// Gets the property from query parameters.
        /// </summary>
        /// <param name="queryStringParams">The query string parameters.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>System.String.</returns>
        public static string GetPropFromQueryParams(IEnumerable<KeyValuePair<string, string>> queryStringParams, string propertyName)
        {

            if (queryStringParams != null)
            {
                var tokenParam = queryStringParams.FirstOrDefault(p => p.Key.Equals(propertyName, StringComparison.OrdinalIgnoreCase));
                if (tokenParam.Value != null)
                    return tokenParam.Value;
            }
            return null;
        }

        /// <summary>
        /// Gets the random identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string GetRandomId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new RandomNumber();

            return new string(
                    Enumerable.Repeat(chars, 8)
                        .Select(s => s[random.Next(s.Length)])
                        .ToArray());
        }

        /// <summary>
        /// Gets the version from query string.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>System.String.</returns>
        public static string GetVersionFromQueryString(Uri uri)
        {
            var query = HttpUtility.ParseQueryString(uri.Query);

            return query["v"] == null ?
                string.Empty : query["v"].Replace(".", "_");
        }

        /// <summary>
        /// Splits the on capital.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string SplitOnCapital(string input)
        {
            var newString = string.Empty;
            var isFirstLetter = true;
            foreach (var t in input)
            {
                if (char.IsUpper(t) && !isFirstLetter)
                    newString += " ";
                newString += t.ToString();
                isFirstLetter = false;
            }
            return newString;
        }
    }
}
