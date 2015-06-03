// ***********************************************************************
// Assembly         : SaraCms.Api
// Author           : Michael Randall
// Created          : 06-03-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 06-03-2015
// ***********************************************************************
// <copyright file="Settings.cs" company="Randall Web Design">
//     Copyright © Microsoft 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Api.Code
{
    using System.Configuration;
    using System.Globalization;
    using SaraCms.Models.ViewModels;
    public class Settings
    { /// <summary>
      /// Gets the application settings.
      /// </summary>
      /// <returns>ApplicationSettings.</returns>
        public static ApplicationSettings GetApplicationSettings()
        {
            var appSettings = ConfigurationManager.AppSettings;
            return new ApplicationSettings
            {
                FileRepositoryFolderPath = appSettings["FileRepositoryFolderPath"].ToString(new CultureInfo("en-us")),
            };
        }
    }
}