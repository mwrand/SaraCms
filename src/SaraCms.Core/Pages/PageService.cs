// ***********************************************************************
// Assembly         : SaraCms.Core
// Author           : Michael Randall
// Created          : 05-27-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 05-27-2015
// ***********************************************************************
// <copyright file="Page.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Core.Pages
{
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PageService
    {
        private readonly IDataService _dataService;

        public PageService(IDataService dataService)
        {
            _dataService = dataService;
        }
        
        public void Delete(int id)
        {
            _dataService.Delete(id);
        }
        
        public Page Get(int id)
        {
            var page = _dataService.Get(id);
            return page;
        }
        
        public List<Page> GetAll()
        {
            return _dataService.GetAll();
        }
        
        public void Save(Page page)
        {
            _dataService.Save(page);
        }
    }
}
