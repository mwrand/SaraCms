// ***********************************************************************
// Assembly         : SaraCms.Core
// Author           : Michael Randall
// Created          : 05-28-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 05-28-2015
// ***********************************************************************
// <copyright file="RoleService.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Core.Accounts
{
    using Data;
    using Models;
    using System.Collections.Generic;
   
    public class RoleService
    {
        private readonly IRepository<Role> _dataService;

        public RoleService(IRepository<Role> dataService)
        {
            _dataService = dataService;
        }

        public void Delete(int id)
        {
            _dataService.Delete(id);
        }

        public Role Get(int id)
        {
            return _dataService.Get(id);
        }

        public List<Role> GetAll()
        {
            return _dataService.GetAll();
        }

        public void Save(Role acct)
        {
            _dataService.Save(acct);
        }
    }
}
