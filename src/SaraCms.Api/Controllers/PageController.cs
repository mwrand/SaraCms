// ***********************************************************************
// Assembly         : SaraCms.Api
// Author           : Michael Randall
// Created          : 05-29-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 05-29-2015
// ***********************************************************************
// <copyright file="PageController.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Api.Controllers
{
    using System.Web.Http;
    using SaraCms.Models;
    using SaraCms.Models.Pages;
    using SaraCms.Models.ViewModels;
    using Core.Pages;
    using Data.File;

    [RoutePrefix("api/Page")]
    public class PageController : BaseController
    {
        [Route("Delete")]
        public Result<bool> DeletePage(DeletePageRequestModel model)
        {
            new PageService(new PageRepository(string.Empty)).Delete(model.PageId);
            return new Result<bool>
            {
                Data = true,
                Hyperlink = GetHyperlink(),
                Validation = Validation.GetSuccessValidation()
            };
        }
    }
}
