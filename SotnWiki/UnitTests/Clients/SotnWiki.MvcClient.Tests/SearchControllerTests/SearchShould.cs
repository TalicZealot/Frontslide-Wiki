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
            //Arrange
            var modelStub = new SearchViewModel();
            modelStub.searchPhrase = "asdasd";

            //Act & Assert
            controllerUnderTest.WithCallTo(c => c.Search(modelStub))
                .ShouldRenderDefaultView()
                .WithModel<SearchViewModel>();
        }
    }
}
