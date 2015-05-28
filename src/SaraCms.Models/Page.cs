// ***********************************************************************
// Assembly         : SaraCms.Models
// Author           : MichaelR
// Created          : 05-27-2015
//
// Last Modified By : MichaelR
// Last Modified On : 05-27-2015
// ***********************************************************************
// <copyright file="Page.cs" company="Randall Web Design">
//     Copyright © Randall  Web Design 2015
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
    public class Page
    {
        public string Content { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public string Keywords { get; set; }
        public string MetaTitle { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
    }
}
