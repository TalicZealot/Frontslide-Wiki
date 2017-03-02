using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.CustomEventArgs;
using SotnWiki.Mvp.Page;
using SotnWiki.TextManipulation.Contracts;
using System.Web;

namespace SotnWiki.Mvp.Tests.PagePresenterTests
{
    [TestFixture]
    public class View_OnPageGetContentShould
    {
        [Test]
        public void SetHttpResponseTo404WhenPageIsNotFound()
        {
            //Arrange
            var mockedView = new Mock<IPageView>();
            mockedView.Setup(v => v.Model).Returns(new PageViewModel());
            var mockedPageService = new Mock<IPageService>();
            var mockedConverter = new Mock<IMarkupConverter>();
            var pagePresenterUnderTest = new PagePresenter(mockedView.Object, mockedPageService.Object, mockedConverter.Object);
            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns((SotnWiki.Models.Page)null);
            var mockedHttpContext = new Mock<HttpContextBase>();
            var mockedHttpResponseBase = new Mock<HttpResponseBase>();

            pagePresenterUnderTest.HttpContext = mockedHttpContext.Object;
            mockedHttpContext.Setup(x => x.Response).Returns(mockedHttpResponseBase.Object);
            mockedHttpResponseBase.SetupSet(x => x.StatusCode = 404).Verifiable();
            mockedHttpResponseBase.SetupSet(x => x.Status = "404 not found").Verifiable();

            //Act
            mockedView.Raise(v => v.OnPageGetContent += null, new PageEventArgs(""));

            //Assert
            mockedHttpResponseBase.Verify();
        }

        [Test]
        public void SetViewModelTitleCorrectly()
        {
            //Arrange
            var mockedView = new Mock<IPageView>();
            mockedView.Setup(v => v.Model).Returns(new PageViewModel());
            var mockedPageService = new Mock<IPageService>();
            var mockedConverter = new Mock<IMarkupConverter>();
            var pagePresenterUnderTest = new PagePresenter(mockedView.Object, mockedPageService.Object, mockedConverter.Object);
            string expectedTitle = "page title";
            var page = new SotnWiki.Models.Page()
            {
                Title = expectedTitle
            };

            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns(page);

            //Act
            mockedView.Raise(v => v.OnPageGetContent += null, new PageEventArgs(""));

            //Assert
            Assert.AreEqual(expectedTitle, mockedView.Object.Model.Title);
        }

        [Test]
        public void SetViewModelHtmlCorrectly()
        {
            //Arrange
            var mockedView = new Mock<IPageView>();
            mockedView.Setup(v => v.Model).Returns(new PageViewModel());
            var mockedPageService = new Mock<IPageService>();
            var mockedConverter = new Mock<IMarkupConverter>();
            var defaultPresenterUnderTest = new PagePresenter(mockedView.Object, mockedPageService.Object, mockedConverter.Object);
            string expectedContent = "<h1>";
            var page = new SotnWiki.Models.Page()
            {
                Title = "aa",
                Content = ".h1"
            };
            mockedConverter.Setup(x => x.ScriptToHtml(It.IsAny<string>())).Returns(expectedContent);
            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns(page);

            //Act
            mockedView.Raise(v => v.OnPageGetContent += null, new PageEventArgs(""));

            //Assert
            Assert.AreEqual(expectedContent, mockedView.Object.Model.PageHtml);
        }
    }
}
