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
        private readonly IRepository<Page> _repository;

        public PageService(IRepository<Page> repository)
        {
            _repository = repository;
        }
        
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
        
        public Page Get(int id)
        {
            var page = _repository.Get(id);
            return page;
        }
        
        public List<Page> GetAll()
        {
            return _repository.GetAll();
        }
        
        public void Save(Page page)
        {
            _repository.Save(page);
        }
    }
}
