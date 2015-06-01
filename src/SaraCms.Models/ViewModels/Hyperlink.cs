// ***********************************************************************
// Assembly         : SaraCms.Models
// Author           : Michael Randall
// Created          : 06-01-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 06-01-2015
// ***********************************************************************
// <copyright file="Hyperlink.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Models.ViewModels
{
    public class Hyperlink
    {
        public string Next { get; set; }
        public string NextMethod { get; set; }
        public string Self { get; set; }
        public string SelfMethod { get; set; }
    }
}
