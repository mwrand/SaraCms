// ***********************************************************************
// Assembly         : SaraCms.Api
// Author           : Michael Randall
// Created          : 06-01-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 06-01-2015
// ***********************************************************************
// <copyright file="BaseController.cs" company="Randall Web Design">
//     Copyright © Microsoft 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Api.Controllers
{
    using Lib;
    using Model.ViewModels;
    using SaraCms.Models.ViewModels;
    using System.Web;
    using System.Web.Http;

    public class BaseController : ApiController
    {
        protected IApplicationModel ApplicationModel { get; set; }

        private ApplicationSettings _applicationSettings = null;
        private ApplicationSettings ApplicationSettings
        {
            get { return _applicationSettings ?? (_applicationSettings = ApplicationModel.GetSettings()); }
        }

        private string _appPath;
        protected string AppPath
        {
            get { return _appPath ?? (_appPath = HttpContext.Current.Server.MapPath(@"~/")); }
        }

        private string _baseUrl;
        protected string BaseUrl
        {
            get { return _baseUrl ?? (_baseUrl = GetBaseUrl()); }
        }

        private RequestDetail _requestDetail;
        public RequestDetail RequestDetail
        {
            get
            {
                if (_requestDetail == null && HttpContext.Current != null)
                {
                    _requestDetail = HttpContext.Current.Items["RequestDetail"] != null
                        ? (RequestDetail)HttpContext.Current.Items["RequestDetail"]
                        : new Code.RequestDetails().GetRequestDetail(HttpContext.Current);
                }
                return _requestDetail;
            }
            set { _requestDetail = value; }
        }

        protected string GetBaseUrl()
        {
            var uri = RequestDetail.RequestUrl;
            var port = string.Empty;
            if (uri.Port > 0) port = ":" + uri.Port;
            return string.Format("{0}://{1}{2}/", uri.Scheme, uri.Host, port);
        }

        protected Hyperlink GetHyperlink(string next = "", string nextMethod = "")
        {
            var uri = RequestDetail.RequestUrl;
            if (next.Length > 0)
            {
                var port = string.Empty;
                if (uri.Port > 0) port = ":" + uri.Port;
                next = string.Format("{0}://{1}:{2}/{3}&v={4}", uri.Scheme, uri.Host, port, next, RequestDetail.Version);
            }
            return new Hyperlink
            {
                Self = uri == null ? string.Empty : uri.ToString(),
                SelfMethod = RequestDetail.RequestMethod,
                Next = next,
                NextMethod = nextMethod
            };
        }
    }
}