// ***********************************************************************
// Assembly         : SaraCms.Data.File
// Author           : Michael Randall
// Created          : 05-27-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 05-27-2015
// ***********************************************************************
// <copyright file="RoleRepository.cs" company="Randall Web Design">
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
    public class RoleRepository : IRepository<Role>
    {
        private readonly string FilePath;
        
        public RoleRepository(string filePath)
        {
            FilePath = filePath;
        }

        public void Delete(int id)
        {
            var list = GetFromFile().Where(p => p.Id != id);
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(list));
        }

        public Role Get(int id)
        {
            return GetFromFile().SingleOrDefault(p => p.Id == id);
        }

        public List<Role> GetAll()
        {
            return GetFromFile();
        }

        public void Save(Role obj)
        {
            if (obj == null) return;

            if (obj.Id == 0)
                Insert(obj);
            else
                Update(obj);
        }

        private void Insert(Role obj)
        {
            var list = GetFromFile();
            var maxId = list.Max(p => p.Id);
            obj.Id = maxId + 1;
            list.Add(obj);

            File.WriteAllText(FilePath, JsonConvert.SerializeObject(list));
        }

        private List<Role> GetFromFile()
        {
            var json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Role>>(json);
        }
        private void Update(Role obj)
        {
            var list = GetFromFile();
            foreach (var item in list)
            {
                if (item.Id == obj.Id)
                {
                    item.Name = obj.Name;
                }
            }

            File.WriteAllText(FilePath, JsonConvert.SerializeObject(list));
        }
    }
}
