// ***********************************************************************
// Assembly         : SaraCms.Data.File
// Author           : Michael Randall
// Created          : 06-03-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 06-03-2015
// ***********************************************************************
// <copyright file="IPageRepository.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Data.File
{
    using Models;
    using System.Collections.Generic;
    public interface IPageRepository
    {
        void Delete(int id);
        
        Page Get(int id);
        
        List<Page> GetAll();
        
        void Save(Page obj);
    }
}
