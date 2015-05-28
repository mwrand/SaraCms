// ***********************************************************************
// Assembly         : SaraCms.Data.File
// Author           : Michael Randall
// Created          : 05-27-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 05-27-2015
// ***********************************************************************
// <copyright file="FileService.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Data.File
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Models;
    using System.IO;
    using Newtonsoft.Json;
    public class FileService : IDataService
    {
        private readonly string FilePath;
        
        public FileService(string filePath)
        {
            FilePath = filePath;
        }

        public void Delete(int id)
        {
            var list = GetPagesFromFile().Where(p => p.Id != id);
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(list));
        }

        public Page Get(int id)
        {
            return GetPagesFromFile().SingleOrDefault(p => p.Id == id);
        }

        public List<Page> GetAll()
        {
            return GetPagesFromFile();
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
            var pages = GetPagesFromFile();
            var maxId = pages.Max(p => p.Id);
            obj.Id = maxId + 1;
            pages.Add(obj);

            File.WriteAllText(FilePath, JsonConvert.SerializeObject(pages));
        }

        private List<Page> GetPagesFromFile()
        {
            var json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Page>>(json);
        }
        private void Update(Page obj)
        {
            var pages = GetPagesFromFile();
            foreach (var page in pages)
            {
                if (page.Id == obj.Id)
                {
                    page.Name = obj.Name;
                    page.Content = obj.Content;
                }
            }

            File.WriteAllText(FilePath, JsonConvert.SerializeObject(pages));
        }
    }
}
