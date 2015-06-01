// ***********************************************************************
// Assembly         : STR.ProductReports.Api
// Author           : mrandall
// Created          : 06-01-2015
//
// Last Modified By : mrandall
// Last Modified On : 06-01-2015
// ***********************************************************************
// <copyright file="MessageHandler.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Api.Code
{
    using System;
    using System.Configuration;
    using System.Globalization;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;

    public class MessageHandler : DelegatingHandler
    {
        private string _currentVersion = "";
        private string CurrentVersion
        {
            get
            {
                if (_currentVersion.Length == 0)
                    _currentVersion = ConfigurationManager.AppSettings["currentApiVersion"].ToString(CultureInfo.CurrentCulture);

                return _currentVersion;
            }
        }

        /// <summary>
        /// Gets or sets the current request message.
        /// </summary>
        /// <value>The current request message.</value>
        public HttpRequestMessage CurrentRequestMessage { get; set; }

        /// <summary>
        /// Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
        /// </summary>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />. The task object representing the asynchronous operation.</returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            CurrentRequestMessage = request;
            var response = base.SendAsync(request, cancellationToken);
            if (response.Result.StatusCode == HttpStatusCode.NotFound)
            {
                //Create new HttpResponseMessage message
                if (RequestedUserController(request.RequestUri))
                {
                    if (PassedVersion(request.RequestUri))
                        return ResponseTask("This version is not supported.");

                    var currentUrl = request.RequestUri;
                    var msg = currentUrl.ToString().ToLower().Contains("/user/login") ? 
                        string.Format("To use this api you must pass a version number as a query parameter, ex: {0}.", LoginExampleUrl(request.RequestUri)) : 
                        string.Format("To use this api you must pass a token and a version number as query parameters, ex: {0}.", ProductsExampleUrl(request.RequestUri));

                    return ResponseTask(msg);
                }
            }
            return response;
        }

        private string LoginExampleUrl(Uri uri)
        {
            return string.Format("{0}://{1}/user/login?username=UserName&password=Password&v={2}", uri.Scheme, uri.Authority, CurrentVersion);
        }

        private string ProductsExampleUrl(Uri uri)
        {
            return string.Format("{0}://{1}/user/products?token=[tokenValue]&v={2}", uri.Scheme, uri.Authority, CurrentVersion);
        }

        private static bool PassedVersion(Uri uri)
        {
            var coll = HttpUtility.ParseQueryString(uri.ToString());
            return (coll["v"] != null);
        }

        private static bool RequestedUserController(Uri requestUri)
        {
            return (requestUri.AbsolutePath.ToLower().StartsWith("/user"));

            // Uri.UnescapeDataString(HttpUtility.ParseQueryString(uri.ToString()).Get("v"));
        }

        private Task<HttpResponseMessage> ResponseTask(string msg)
        {
            var responseMsg = new ResponseMessage(CurrentVersion, msg);
            return Task<HttpResponseMessage>.Factory.StartNew(() =>
                           CurrentRequestMessage.CreateResponse(responseMsg.StatusCode, responseMsg));
        }

        public class ResponseMessage
        {
            public HttpStatusCode StatusCode { get; set; }
            public string RequestMessage { get; set; }
            public string CurrentVersions { get; set; }

            public ResponseMessage(string currentVersions, string requestMessage)
            {
                RequestMessage = requestMessage;
                CurrentVersions = currentVersions;
                StatusCode = HttpStatusCode.BadRequest;
            }
        }
    }
}