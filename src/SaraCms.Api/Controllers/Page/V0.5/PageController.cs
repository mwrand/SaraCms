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
namespace SaraCms.Api.Controllers.Page.V0_5
{
    using System.Collections.Generic;
    using System.Web.Http;
    using SaraCms.Models;
    using SaraCms.Models.Pages;
    using Core.Pages;
    using Data.File;
    using Data;
    using SaraCms.Lib;

    [RoutePrefix("api/Page")]
    public class PageV0_5Controller : BaseController
    {
        private readonly IPageRepository _pageRepository = null;
        
        public PageV0_5Controller(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        [Route("Delete")]
        [HttpDelete]
        public Result<bool> DeletePage(DeletePageRequestModel model)
        {
            new PageService(_pageRepository).Delete(model.PageId);
            return new Result<bool>
            {
                Data = true,
                Hyperlink = GetHyperlink(),
                Validation = Validation.GetSuccessValidation("Your page was deleted")
            };
        }

        [Route("Get")]
        [HttpGet]
        public Result<Page> GetPage(GetPageRequestModel model)
        {
            return new Result<Page>
            {
                Data = new PageService(_pageRepository).Get(model.PageId),
                Hyperlink = GetHyperlink(),
                Validation = Validation.GetSuccessValidation()
            };
        }

        [Route("GetAll")]
        [HttpGet]
        public Result<List<Page>> GetAllPages()
        {
            return new Result<List<Page>>
            {
                Data = new PageService(_pageRepository).GetAll(),
                Hyperlink = GetHyperlink(),
                Validation = Validation.GetSuccessValidation()
            };
        }

        [Route("Save")]
        [HttpPost]
        public Result<Page> SavePage(Page page)
        {
            new PageService(_pageRepository).Save(page);

            return new Result<Page>
            {
                Data = page,
                Hyperlink = GetHyperlink(),
                Validation = Validation.GetSuccessValidation("Your page was saved.")
            };
        }
    }
}
