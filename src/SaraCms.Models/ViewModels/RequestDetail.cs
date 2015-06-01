// ***********************************************************************
// Assembly         : STR.ProductReports.Model
// Author           : Michael Randall
// Created          : 06-01-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 06-01-2015
// ***********************************************************************
// <copyright file="RequestDetail.cs" company="STR">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Model.ViewModels
{
    using System;
    /// </summary>
    public class RequestDetail
    {
        public string IpAddress { get; set; }
        public DateTime Occurred { get; set; }
        public string RequestMethod { get; set; }
        public Uri RequestUrl { get; set; }
        public string Version { get; set; }
    }
}
