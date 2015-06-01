// ***********************************************************************
// Assembly         : SaraCms.Api
// Author           : Michael Randall
// Created          : 06-01-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 06-01-2015
// ***********************************************************************
// <copyright file="RequestDetail.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Api.Code
{
    using Model.ViewModels;
    using Lib.Helpers;
    using System;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http.Controllers;

    public class RequestDetails
    {
        private RequestDetail _requestDetail;

        public RequestDetail GetRequestDetail(HttpActionContext actionContext)
        {
            if (_requestDetail == null)
            {
                var token = StringHelper.GetPropFromQueryParams(actionContext.Request.GetQueryNameValuePairs(), "token");
                _requestDetail = new RequestDetail
                {
                    IpAddress = (HttpContext.Current != null) ? HttpContext.Current.Request.UserHostAddress : string.Empty,
                    Occurred = DateTime.Now,
                    RequestUrl = (HttpContext.Current != null) ? HttpContext.Current.Request.Url : null,
                    Version = StringHelper.GetPropFromQueryParams(actionContext.Request.GetQueryNameValuePairs(), "v")
                };
            }
            return _requestDetail;
        }

        public RequestDetail GetRequestDetail(HttpContext actionContext)
        {
            if (_requestDetail == null)
            {
                var httpRequestMessage = HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage;
                var token = StringHelper.GetPropFromQueryParams(httpRequestMessage.GetQueryNameValuePairs(), "token");
                _requestDetail = new RequestDetail
                {
                    IpAddress = (HttpContext.Current != null) ? HttpContext.Current.Request.UserHostAddress : string.Empty,
                    Occurred = DateTime.Now,
                    RequestMethod = (HttpContext.Current != null) ? HttpContext.Current.Request.HttpMethod : string.Empty,
                    RequestUrl = (HttpContext.Current != null) ? HttpContext.Current.Request.Url : null,
                    Version = StringHelper.GetPropFromQueryParams(httpRequestMessage.GetQueryNameValuePairs(), "v")
                };
            }
            return _requestDetail;
        }
    }
}