// ***********************************************************************
// Assembly         : SaraCms.Models
// Author           : Michael Randall
// Created          : 05-28-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 05-28-2015
// ***********************************************************************
// <copyright file="Account.cs" company="Microsoft">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Models
{
    using System;
    /// <summary>
    /// Class Account.
    /// </summary>
    public class Account
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UserName { get; set; }

    }
}
