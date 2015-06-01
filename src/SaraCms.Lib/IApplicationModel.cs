// ***********************************************************************
// Assembly         : STR.ProductReports.Lib
// Author           : Michael Randall
// Created          : 01-26-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 05-07-2015
// ***********************************************************************
// <copyright file="IApplicationModel.cs" company="STR">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Lib
{
    using Models.ViewModels;

    public interface IApplicationModel
    {
        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <returns>ApplicationSettings.</returns>
        ApplicationSettings GetSettings();
    }
}
