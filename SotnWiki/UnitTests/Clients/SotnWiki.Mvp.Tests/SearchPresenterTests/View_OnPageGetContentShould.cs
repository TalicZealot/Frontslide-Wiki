using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.CustomEventArgs;
using SotnWiki.Mvp.Search;
using System.Collections.Generic;
using System.Web;

namespace SotnWiki.Mvp.Tests.SearchPresenterTests
{
    [TestFixture]
    public class View_OnPageGetContentShould
    {
        [Test]
        public void CallFindPagesMethodOfPageService()
        {
            //Arrange
            var mockedView = new Mock<ISearchView>();
            mockedView.Setup(v => v.Model).Returns(new SearchViewModel());
            var mockedPageService = new Mock<IPageService>();
            var presenterUnderTest = new SearchPresenter(mockedView.Object, mockedPageService.Object);
            var pages = new List<SotnWiki.Models.Page>()
            {
                new Models.Page() { Title = "t1"},
                new Models.Page() { Title = "t2"}
            };

            mockedPageService.Setup(m => m.FindPages(It.IsAny<string>())).Returns(pages);
            //Act

            mockedView.Raise(v => v.OnPageGetContent += null, new SearchEventArgs(""));
            //Assert

            mockedPageService.Verify(x => x.FindPages(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void FillViewModelResultsWithSearchResult()
        {
            //Arrange
            var mockedView = new Mock<ISearchView>();
            mockedView.Setup(v => v.Model).Returns(new SearchViewModel());
            var mockedPageService = new Mock<IPageService>();
            var presenterUnderTest = new SearchPresenter(mockedView.Object, mockedPageService.Object);
            var pages = new List<SotnWiki.Models.Page>()
            {
                new Models.Page() { Title = "t1"},
                new Models.Page() { Title = "t2"}
            };

            mockedPageService.Setup(m => m.FindPages(It.IsAny<string>())).Returns(pages);
            //Act

            mockedView.Raise(v => v.OnPageGetContent += null, new SearchEventArgs(""));
            //Assert

            CollectionAssert.AreEqual(pages, mockedView.Object.Model.Results);
        }

        [Test]
        public void RedirectToPageIfExactMatchIsFound()
        {
            //Arrange
            var mockedView = new Mock<ISearchView>();
            mockedView.Setup(v => v.Model).Returns(new SearchViewModel());
            var mockedPageService = new Mock<IPageService>();
            var presenterUnderTest = new SearchPresenter(mockedView.Object, mockedPageService.Object);
            string title = "test-title";
            var pages = new List<SotnWiki.Models.Page>()
            {
                new Models.Page() { Title = title}
            };
            mockedPageService.Setup(m => m.FindPages(It.IsAny<string>())).Returns(pages);
            var mockedHttpContext = new Mock<HttpContextBase>();
            var mockedHttpResponseBase = new Mock<HttpResponseBase>();
            presenterUnderTest.HttpContext = mockedHttpContext.Object;
            mockedHttpContext.Setup(x => x.Response).Returns(mockedHttpResponseBase.Object);

            //Act

            mockedView.Raise(v => v.OnPageGetContent += null, new SearchEventArgs(""));
            //Assert

            mockedHttpResponseBase.Verify(x => x.Redirect(string.Format("~/page?title={0}", title)), Times.Once);
        }
    }
}
