using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Controllers;
using SotnWiki.MvcClient.Models;
using TestStack.FluentMVCTesting;

namespace SotnWiki.MvcClient.Tests.SearchControllerTests
{
    [TestFixture]
    public class SearchShould
    {
        private SearchController controllerUnderTest;

        [SetUp]
        public void Setup()
        {
            var mockedPageService = new Mock<IPageService>();
            controllerUnderTest = new SearchController(mockedPageService.Object);
        }

        [Test]
        public void ShouldRenderDefaultViewWithModelSearchViewModel()
        {
            //Act & Assert
            controllerUnderTest.WithCallTo(c => c.Search(It.IsAny<string>()))
                .ShouldRenderDefaultView()
                .WithModel<SearchViewModel>();
        }
    }
}
