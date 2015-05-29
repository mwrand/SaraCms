// ***********************************************************************
// Assembly         : SaraCms.Core.IntTests
// Author           : Michael Randall
// Created          : 05-28-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 05-28-2015
// ***********************************************************************
// <copyright file="AccountTests.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Core.IntTests.AccountTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Xunit;
    using Data.File;
    using Models;
    using Newtonsoft.Json;

    public class CrudTests
    {
        private string _FilePath = @"C:\dev\SaraCms\SaraCms\src\SaraCms.Core.IntTests\_data\Accounts.json";

        [Fact]
        public void DeletePage_VerifyCount()
        {
            var service = GetAccountService();
            var beforeDeleteList = service.GetAll();

            service.Delete(1);
            var afterDeleteList = service.GetAll();

            Assert.Equal<int>(afterDeleteList.Count, beforeDeleteList.Count - 1);

            ResetJsonFile(beforeDeleteList);
        }

        [Fact]
        public void Get_Page_Assert_With_Id1()
        {
            var id = 1;
            var service = GetAccountService();
            var page = service.Get(id);

            Assert.Equal<int>(id, page.Id);
        }

        [Fact]
        public void Get_Page_Assert_With_Id2()
        {
            var id = 2;
            var service = GetAccountService();
            var page = service.Get(id);

            Assert.Equal<int>(2, page.Id);
        }

        [Fact]
        public void GetAll_Pages()
        {
            var service = GetAccountService();
            var pageList = service.GetAll();

            Assert.Equal<int>(3, pageList.Count);
        }

        [Fact]
        public void SavePage_Insert_Verify()
        {
            var service = GetAccountService();
            var beforeInsertList = service.GetAll();
            var now = DateTime.UtcNow;

            var acct = new Account
            {
                Email = "newe@emids.com",
                FirstName = "New",
                LastName = "Employee",
                RoleId = 3,
                UpdatedBy = "Test Runner",
                UpdatedDate = DateTime.UtcNow,
                UserName = "newe"
            };

            service.Save(acct);
            var afterSaveList = service.GetAll();

            Assert.Equal<int>(afterSaveList.Count, beforeInsertList.Count + 1);

            var expectedId = afterSaveList.Count + 1;
            var maxId = afterSaveList.Max(p => p.Id);

            Assert.Equal<int>(afterSaveList.Count, maxId);

            var actualItem = afterSaveList.SingleOrDefault(p => p.Id == maxId);
            Assert.Equal<string>(acct.Email, actualItem.Email);
            Assert.Equal<string>(acct.FirstName, actualItem.FirstName);
            Assert.Equal<string>(acct.LastName, actualItem.LastName);
            Assert.Equal<string>(acct.UserName, actualItem.UserName);
            ResetJsonFile(beforeInsertList);
        }

        [Fact]
        public void SavePage_Update_Verify()
        {
            var service = GetAccountService();
            var beforeUpdateList = service.GetAll();

            var acct = new Account
            {
                Id = 1,
                Email = "newe@emids.com",
                FirstName = "New",
                LastName = "Employee",
                RoleId = 4,
                UpdatedBy = "Test Runner",
                UpdatedDate = DateTime.UtcNow,
                UserName = "newe"
            };

            service.Save(acct);
            var afterSaveList = service.GetAll();

            Assert.Equal<int>(afterSaveList.Count, beforeUpdateList.Count);

            var afterUpdateRecord = afterSaveList.Single(p => p.Id == 1);

            Assert.Equal<string>(acct.Email, afterUpdateRecord.Email);
            Assert.Equal<string>(acct.FirstName, afterUpdateRecord.FirstName);
            Assert.Equal<string>(acct.LastName, afterUpdateRecord.LastName);
            Assert.Equal<int>(acct.RoleId, afterUpdateRecord.RoleId);
            Assert.Equal<string>(acct.UserName, afterUpdateRecord.UserName);

            ResetJsonFile(beforeUpdateList);
        }

        private Accounts.AccountService GetAccountService()
        {
            var fileService = new AccountRepository(_FilePath);
            return new Accounts.AccountService(fileService);
        }

        private void ResetJsonFile(List<Account> list)
        {
            File.WriteAllText(_FilePath, JsonConvert.SerializeObject(list));
        }
    }
}
