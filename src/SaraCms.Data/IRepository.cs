// ***********************************************************************
// Assembly         : SaraCms.Data
// Author           : Michael Randall
// Created          : 05-27-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 05-27-2015
// ***********************************************************************
// <copyright file="IDataService.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SaraCms.Models;
    public interface IRepository<T>
    {
        void Delete(int id);

        T Get(int id);

        List<T> GetAll();

        void Save(T obj);
    }
}
