// ***********************************************************************
// Assembly         : STR.ProductReports.Api
// Author           : mrandall
// Created          : 02-06-2015
//
// Last Modified By : mrandall
// Last Modified On : 02-06-2015
// ***********************************************************************
// <copyright file="ControllerSelector.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Api.Code
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Dispatcher;
    using System.Web.Http.Routing;

    public class ControllerSelector : DefaultHttpControllerSelector
    {
        /// <summary>
        /// Gets or sets the _config.
        /// </summary>
        /// <value>The _config.</value>
        public HttpConfiguration _config { get; set; }

        public ControllerSelector(HttpConfiguration config)
            : base(config)
        {
            _config = config;
        }

        /// <summary>
        /// Selects a <see cref="T:System.Web.Http.Controllers.HttpControllerDescriptor" /> for the given <see cref="T:System.Net.Http.HttpRequestMessage" />.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <returns>The <see cref="T:System.Web.Http.Controllers.HttpControllerDescriptor" /> instance for the given <see cref="T:System.Net.Http.HttpRequestMessage" />.</returns>
        /// <exception cref="System.Web.Http.HttpResponseException">
        /// </exception>
        /// <exception cref="HttpResponseException"></exception>
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            HttpControllerDescriptor controllerDescriptor = null;

            // get list of all controllers provided by the default selector
            var controllers = GetControllerMapping();
            var routeData = request.GetRouteData();

            if (routeData == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //check if this route is actually an attribute route
            var attributeSubRoutes = routeData.GetSubRoutes();

            var apiVersion = Lib.Helpers.StringHelper.GetVersionFromQueryString(request.RequestUri);

            if (attributeSubRoutes == null)
            {
                var controllerName = GetRouteVariable<string>(routeData, "controller");
                if (controllerName == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                var newControllerName = String.Concat(controllerName, "V", apiVersion);

                if (controllers.TryGetValue(newControllerName, out controllerDescriptor))
                    return controllerDescriptor;

                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // we want to find all controller descriptors whose controller type names end with
            // the following suffix (example: PeopleV1)
            var newControllerNameSuffix = String.Concat("V", apiVersion);

            var filteredSubRoutes = attributeSubRoutes
                .Where(attrRouteData =>
                {
                    var currentDescriptor = GetControllerDescriptor(attrRouteData);
                    var match = currentDescriptor.ControllerName.EndsWith(newControllerNameSuffix);

                    if (match && (controllerDescriptor == null))
                        controllerDescriptor = currentDescriptor;

                    return match;
                });

            routeData.Values["MS_SubRoutes"] = filteredSubRoutes.ToArray();

            return controllerDescriptor;
        }

        private static HttpControllerDescriptor GetControllerDescriptor(IHttpRouteData routeData)
        {
            return ((HttpActionDescriptor[])routeData.Route.DataTokens["actions"]).First().ControllerDescriptor;
        }

        private static T GetRouteVariable<T>(IHttpRouteData routeData, string name)
        {
            object result = null;
            if (routeData.Values.TryGetValue(name, out result))
            {
                return (T)result;
            }
            return default(T);
        }
    }
}