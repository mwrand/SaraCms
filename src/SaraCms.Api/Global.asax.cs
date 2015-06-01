// ***********************************************************************
// Assembly         : SaraCms.Api
// Author           : Michael Randall
// Created          : 05-29-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 06-01-2015
// ***********************************************************************
// <copyright file="Global.asax.cs" company="Randall Web Design">
//     Copyright © Microsoft 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Api
{
    using Lib.Helpers;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Net.Http.Formatting;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            jsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("json", "true", "application/json"));
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        protected void Application_Error()
        {
            // Get the exception object.
            Exception ex = Server.GetLastError();

            // Handle HTTP errors
            if (ex.GetType() == typeof(HttpException))
            {
                // The Complete Error Handling Example generates
                // some errors using URLs with "NoCatch" in them;
                // ignore these here to simulate what would happen
                // if a global.asax handler were not implemented.
                if (ex.Message.Contains("NoCatch") || ex.Message.Contains("maxUrlLength"))
                    return;
            }

            var method = ex.TargetSite;
            var methodName = (method != null) ? method.Name : string.Empty;
            var controller = (method != null && method.ReflectedType != null) ? method.ReflectedType.Name : string.Empty;
            var version = StringHelper.GetVersionFromQueryString(HttpContext.Current.Request.Url);

            throw ex;
            //new Error(new ApiManagerModel()).Log(controller, methodName, "Unhandled exception:", HttpContext.Current.Request, DateTime.Now, ex, version);
        }
    }
}
