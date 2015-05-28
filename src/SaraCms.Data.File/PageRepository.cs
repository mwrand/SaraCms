// ***********************************************************************
// Assembly         : SaraCms.Data.File
// Author           : Michael Randall
// Created          : 05-27-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 05-27-2015
// ***********************************************************************
// <copyright file="PageRepository.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Data.File
{
    using Data;
    using Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class PageRepository : IRepository<Page>
    {
        private readonly string FilePath;
        
        public PageRepository(string filePath)
        {
            FilePath = filePath;
        }

        public void Delete(int id)
        {
            var list = GetFromFile().Where(p => p.Id != id);
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(list));
        }

        public Page Get(int id)
        {
            return GetFromFile().SingleOrDefault(p => p.Id == id);
        }

        public List<Page> GetAll()
        {
            return GetFromFile();
        }

        public void Save(Page obj)
        {
            if (obj == null) return;

            if (obj.Id == 0)
                Insert(obj);
            else
                Update(obj);
        }

        private void Insert(Page obj)
        {
            var pages = GetFromFile();
            var maxId = pages.Max(p => p.Id);
            obj.Id = maxId + 1;
            pages.Add(obj);

            File.WriteAllText(FilePath, JsonConvert.SerializeObject(pages));
        }

        private List<Page> GetFromFile()
        {
            var json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Page>>(json);
        }
        private void Update(Page obj)
        {
            var list = GetFromFile();
            foreach (var item in list)
            {
                if (item.Id == obj.Id)
                {
                    item.Name = obj.Name;
                    item.Content = obj.Content;
                }
            }

            File.WriteAllText(FilePath, JsonConvert.SerializeObject(list));
        }
    }
}
