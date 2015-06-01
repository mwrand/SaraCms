// ***********************************************************************
// Assembly         : SaraCms.Api
// Author           : Michael Randall
// Created          : 05-29-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 05-29-2015
// ***********************************************************************
// <copyright file="WebApiConfig.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Api
{
    using Code;
    using Microsoft.Owin.Security.OAuth;
    using System.Web.Http;
    using System.Web.Http.Dispatcher;
    /// <summary>
    /// Class WebApiConfig.
    /// </summary>
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            //Override selector to allow for versioning
            config.Services.Replace(typeof(IHttpControllerSelector), new ControllerSelector(config));
            config.MessageHandlers.Add(new MessageHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
