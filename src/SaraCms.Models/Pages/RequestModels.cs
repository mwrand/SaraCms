﻿// ***********************************************************************
// Assembly         : SaraCms.Models
// Author           : Michael Randall
// Created          : 05-29-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 05-29-2015
// ***********************************************************************
// <copyright file="RequestModels.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Models.Pages
{
    public class DeletePageRequestModel
    {
        public int PageId { get; set; }
    }

    public class GetPageRequestModel
    {
        public int PageId { get; set; }
    }
}
