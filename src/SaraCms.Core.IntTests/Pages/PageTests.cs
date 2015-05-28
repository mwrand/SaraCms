// ***********************************************************************
// Assembly         : SaraCms.Core.IntTests
// Author           : Michael Randall
// Created          : 05-28-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 05-28-2015
// ***********************************************************************
// <copyright file="PageTests.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Core.IntTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    using Data.File;
    using Models;
    using Newtonsoft.Json;

    public class PageTests
    {
        private string _FilePath = @"C:\dev\SaraCms\SaraCms\src\SaraCms.Core.IntTests\_data\Pages.json";

        [Fact]
        public void DeletePage_VerifyCount()
        {
            var service = GetPageService();
            var beforeDeleteList = service.GetAll();

            service.Delete(1);
            var afterDeleteList = service.GetAll();

            Assert.Equal<int>(afterDeleteList.Count, beforeDeleteList.Count -1);

            ResetJsonFile(beforeDeleteList);
        }

        [Fact]
        public void Get_Page_Assert_With_Id1()
        {
            var id = 1;
            var service = GetPageService();
            var page = service.Get(id);

            Assert.Equal<int>(id, page.Id);
        }

        [Fact]
        public void Get_Page_Assert_With_Id2()
        {
            var id = 2;
            var service = GetPageService();
            var page = service.Get(id);

            Assert.Equal<int>(2, page.Id);
        }

        [Fact]
        public void GetAll_Pages()
        {
            var service = GetPageService();
            var pageList = service.GetAll();

            Assert.Equal<int>(3, pageList.Count);
        }

        [Fact]
        public void SavePage_Insert_Verify()
        {
            var service = GetPageService();
            var beforeInsertList = service.GetAll();

            var page = new Page { Name = "Test Page", Content = "<div>Test Content</div>" };

            service.Save(page);
            var afterSaveList = service.GetAll();

            Assert.Equal<int>(afterSaveList.Count, beforeInsertList.Count + 1);

            ResetJsonFile(beforeInsertList);
        }

        [Fact]
        public void SavePage_Update_Verify()
        {
            var service = GetPageService();
            var beforeUpdateList = service.GetAll();

            var page = new Page { Id = 1, Name = "Update Test Page", Content = "<div>Update Test Content</div>" };

            service.Save(page);
            var afterSaveList = service.GetAll();

            Assert.Equal<int>(afterSaveList.Count, beforeUpdateList.Count);
            
            var afterUpdateRecord = beforeUpdateList.Single(p => p.Id == 1);

            Assert.Equal<string>(page.Name, afterUpdateRecord.Name);
            Assert.Equal<string>(page.Content, afterUpdateRecord.Content);

            ResetJsonFile(beforeUpdateList);
        }

        private Pages.PageService GetPageService()
        {
            var fileService = new FileService(_FilePath);
            return new Pages.PageService(fileService);
        }

        private void ResetJsonFile(List<Page> list)
        {
            File.WriteAllText(_FilePath, JsonConvert.SerializeObject(list));
        }
    }
}
