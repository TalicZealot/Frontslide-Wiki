using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.CustomEventArgs;
using SotnWiki.Mvp.Publish;
using System.Web;

namespace SotnWiki.Mvp.Tests.PublishPresenterTests
{
    [TestFixture]
    public class View_OnDismissPageShould
    {
        [Test]
        public void CallDismissSubmissionMethodOfPageService()
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
            mockedView.Raise(v => v.OnDismissPage += null, new PageEventArgs(""));

            //Assert
            mockedPageService.Verify(x => x.DismissSubmission(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void RedirectToSubmissionsPage()
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
            mockedView.Raise(v => v.OnDismissPage += null, new PageEventArgs(""));

            //Assert
            mockedHttpResponseBase.Verify(x => x.Redirect("~/submissions"), Times.Once);
        }
    }
}
