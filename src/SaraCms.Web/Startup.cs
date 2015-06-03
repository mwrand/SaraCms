// ***********************************************************************
// Assembly         : SaraCms.Web
// Author           : Michael Randall
// Created          : 06-03-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 06-03-2015
// ***********************************************************************
// <copyright file="Startup.cs" company="Randall Web Design">
//     Copyright (c) Randall Web Design. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Http;
    using Microsoft.Framework.DependencyInjection;
    using Microsoft.AspNet.StaticFiles;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseFileServer(new FileServerOptions
            {
                EnableDefaultFiles = true,
                EnableDirectoryBrowsing = true,
            });
        }
    }
}
