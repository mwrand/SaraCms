// ***********************************************************************
// Assembly         : SaraCms.Models
// Author           : Michael Randall
// Created          : 06-01-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 06-01-2015
// ***********************************************************************
// <copyright file="Enumerations.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Enumerations
    {
        public enum ValidationCodes
        {
            Null = 0,
            Success = 1,
            SystemError = 10,
            InvalidLogin = 101,
            InvalidToken = 201,
            TokenTimeout = 202,
            InvalidIpAddress = 203,
            NewPropertyListException = 204,
            InvalidDateRangeType = 205,
            FileCouldNotBeCreated = 206
        }
    }
}
