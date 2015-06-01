// ***********************************************************************
// Assembly         : SaraCms.Lib
// Author           : Michael Randall
// Created          : 06-01-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 06-01-2015
// ***********************************************************************
// <copyright file="ApplicationModel.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Lib
{
    using Models.ViewModels;
    
    public class ApplicationModel : IApplicationModel 
    {
        /// <summary>
        /// The _settings
        /// </summary>
        private readonly ApplicationSettings _settings = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationModel" /> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public ApplicationModel(ApplicationSettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <returns>ApplicationSettings.</returns>
        public ApplicationSettings GetSettings()
        {
            return _settings;
        }
    }
}