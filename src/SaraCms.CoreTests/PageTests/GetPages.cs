// ***********************************************************************
// Assembly         : SaraCms.CoreTests
// Author           : MichaelR
// Created          : 05-27-2015
//
// Last Modified By : MichaelR
// Last Modified On : 05-27-2015
// ***********************************************************************
// <copyright file="PageTests.cs" company="Randall Web Design">
//     Copyright © Randall  Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.CoreTests.Pages
{
    using Data;
    using Rhino;
    using Rhino.Mocks;
    using SaraCms.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    public class PageTests
    {
        [Fact]
        public void Get_Page_Does_Not_Return_Null()
        {
            var mockDataService = MockRepository.Mock<IDataService>();
            var service = new Core.Pages.PageService(mockDataService);
            var page = service.Get(1);
            mockDataService.AssertWasCalled(x => x.Get(Arg<int>.Is.NotNull));
        }

        [Fact]
        public void Get_Page_Assert_Was_Called()
        {
            var id =1;

            var mockDataService = MockRepository.Mock<IDataService>();

            mockDataService.Expect(d => d.Get(id));

            var service = new Core.Pages.PageService(mockDataService);
            var page = service.Get(id);

            mockDataService.AssertWasCalled(x => x.Get(id));
            mockDataService.AssertWasCalled(x => x.Get(Arg<int>.Matches(y => y == id)));
        }
    }
}
