using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.CustomEventArgs;
using SotnWiki.Mvp.Publish;
using System.Web;

namespace SotnWiki.Mvp.Tests.PublishPresenterTests
{
    [TestFixture]
    public class View_OnPublishPageShould
    {
        [Test]
        public void CallPublishPageMethodOfPageService()
        {
            //Arrange
            var mockedView = new Mock<IPublishView>();
            mockedView.Setup(v => v.Model).Returns(new PublishViewModel());
            var mockedPageService = new Mock<IPageService>();
            var pagePresenterUnderTest = new PublishPresenter(mockedView.Object, mockedPageService.Object);
            var mockedHttpContext = new Mock<HttpContextBase>();
            var mockedHttpResponseBase = new Mock<HttpResponseBase>();
            pagePresenterUnderTest.HttpContext = mockedHttpContext.Object;
            mockedHttpContext.Setup(x => x.Response).Returns(mockedHttpResponseBase.Object);

            //Act
            mockedView.Raise(v => v.OnPublishPage += null, new PublishEventArgs("", ""));

            //Assert
            mockedPageService.Verify(x => x.PublishPage(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void RedirectToPublishedPage()
        {
            //Arrange
            var mockedView = new Mock<IPublishView>();
            mockedView.Setup(v => v.Model).Returns(new PublishViewModel());
            var mockedPageService = new Mock<IPageService>();
            var pagePresenterUnderTest = new PublishPresenter(mockedView.Object, mockedPageService.Object);
            var mockedHttpContext = new Mock<HttpContextBase>();
            var mockedHttpResponseBase = new Mock<HttpResponseBase>();
            pagePresenterUnderTest.HttpContext = mockedHttpContext.Object;
            mockedHttpContext.Setup(x => x.Response).Returns(mockedHttpResponseBase.Object);
            string title = "test-title";

            //Act
            mockedView.Raise(v => v.OnPublishPage += null, new PublishEventArgs(title, ""));

            //Assert
            mockedHttpResponseBase.Verify(x => x.Redirect(string.Format("~/page?title={0}", title)), Times.Once);
        }
    }
}
