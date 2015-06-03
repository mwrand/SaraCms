// ***********************************************************************
// Assembly         : SaraCms.Api
// Author           : Michael Randall
// Created          : 06-01-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 06-01-2015
// ***********************************************************************
// <copyright file="NinjectWebCommon.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SaraCms.Api.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SaraCms.Api.App_Start.NinjectWebCommon), "Stop")]

namespace SaraCms.Api.App_Start
{
    using Code;
    using Data.File;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using SaraCms.Models.ViewModels;
    using System;
    using System.Web;
    using System.Web.Http;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                // Install our Ninject-based IDependencyResolver into the Web API config
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            //kernel.Bind<IApiManagerModel>().To<ApiManagerModel>().InRequestScope();
            kernel.Bind<IApplicationSettings>().To<ApplicationSettings>().InSingletonScope()
                .WithConstructorArgument("settings", Settings.GetApplicationSettings());
            kernel.Bind<IPageRepository>().To<PageRepository>().InRequestScope();
        }
    }
}
