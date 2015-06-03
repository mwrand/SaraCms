// ***********************************************************************
// Assembly         : SaraCms.Models
// Author           : Michael Randall
// Created          : 06-01 -2015
//
// Last Modified By : Michael Randall
// Last Modified On : 06-01-2015
// ***********************************************************************
// <copyright file="ApplicationSettings.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Models.ViewModels
{
    public class ApplicationSettings : IApplicationSettings
    {
        public ApplicationSettings()
        {

        }

        public ApplicationSettings(IApplicationSettings settings)
        {
            FileRepositoryFolderPath = settings.FileRepositoryFolderPath;
        }

        public string FileRepositoryFolderPath { get; set; }
    }
}
