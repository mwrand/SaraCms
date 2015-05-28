// ***********************************************************************
// Assembly         : SaraCms.Data.File
// Author           : Michael Randall
// Created          : 05-27-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 05-27-2015
// ***********************************************************************
// <copyright file="AccountRepository.cs" company="Randall Web Design">
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
    public class AccountRepository : IRepository<Account>
    {
        private readonly string FilePath;
        
        public AccountRepository(string filePath)
        {
            FilePath = filePath;
        }

        public void Delete(int id)
        {
            var list = GetFromFile().Where(p => p.Id != id);
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(list));
        }

        public Account Get(int id)
        {
            return GetFromFile().SingleOrDefault(p => p.Id == id);
        }

        public List<Account> GetAll()
        {
            return GetFromFile();
        }

        public void Save(Account obj)
        {
            if (obj == null) return;

            if (obj.Id == 0)
                Insert(obj);
            else
                Update(obj);
        }

        private void Insert(Account obj)
        {
            var list = GetFromFile();
            var maxId = list.Max(p => p.Id);
            obj.Id = maxId + 1;
            list.Add(obj);

            File.WriteAllText(FilePath, JsonConvert.SerializeObject(list));
        }

        private List<Account> GetFromFile()
        {
            var json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Account>>(json);
        }
        private void Update(Account obj)
        {
            var list = GetFromFile();
            foreach (var item in list)
            {
                if (item.Id == obj.Id)
                {
                    item.CreatedBy = obj.CreatedBy;
                    item.CreatedDate = obj.CreatedDate;
                    item.Email = obj.Email;
                    item.FirstName = obj.FirstName;
                    item.LastName = obj.LastName;
                    item.RoleId = obj.RoleId;
                    item.UpdatedBy = obj.UpdatedBy;
                    item.UpdatedDate = obj.UpdatedDate;
                    item.UserName = obj.UserName;
                }
            }

            File.WriteAllText(FilePath, JsonConvert.SerializeObject(list));
        }
    }
}
