using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.CustomEventArgs;
using SotnWiki.Mvp.PublishEdit;
using System;
using System.Web;

namespace SotnWiki.Mvp.Tests.PublishEditPresenterTests
{
    [TestFixture]
    public class View_OnSubmitPageEditShould
    {
        [Test]
        public void CallPublishEditMEthodOfContentSubmissionService()
        {
            //Arrange
            var mockedView = new Mock<IPublishEditView>();
            mockedView.Setup(v => v.Model).Returns(new PublishEditViewModel());
            var mockedPageService = new Mock<IPageService>();
            var mockedContentSubmissionService = new Mock<IContentSubmissionService>();
            var pagePresenterUnderTest = new PublishEditPresenter(mockedView.Object, mockedPageService.Object, mockedContentSubmissionService.Object);
            var mockedHttpContext = new Mock<HttpContextBase>();
            var mockedHttpResponseBase = new Mock<HttpResponseBase>();
            pagePresenterUnderTest.HttpContext = mockedHttpContext.Object;
            mockedHttpContext.Setup(x => x.Response).Returns(mockedHttpResponseBase.Object);

            //Act
            mockedView.Raise(v => v.OnSubmitPageEdit += null, new PublishEditEventArgs("title", "content", Guid.NewGuid()));

            //Assert
            mockedContentSubmissionService.Verify(x => x.PublishEdit(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Guid>()), Times.Once);
        }

        [Test]
        public void RedirectToTheParentPageOfTheContentSubmission()
        {
            //Arrange
            var mockedView = new Mock<IPublishEditView>();
            mockedView.Setup(v => v.Model).Returns(new PublishEditViewModel());
            var mockedPageService = new Mock<IPageService>();
            var mockedContentSubmissionService = new Mock<IContentSubmissionService>();
            var pagePresenterUnderTest = new PublishEditPresenter(mockedView.Object, mockedPageService.Object, mockedContentSubmissionService.Object);
            var mockedHttpContext = new Mock<HttpContextBase>();
            var mockedHttpResponseBase = new Mock<HttpResponseBase>();
            pagePresenterUnderTest.HttpContext = mockedHttpContext.Object;
            mockedHttpContext.Setup(x => x.Response).Returns(mockedHttpResponseBase.Object);
            string title = "test-title";

            //Act
            mockedView.Raise(v => v.OnSubmitPageEdit += null, new PublishEditEventArgs(title, "content", Guid.NewGuid()));

            //Assert
            mockedHttpResponseBase.Verify(x => x.Redirect(string.Format("~/page?title={0}", title)), Times.Once);
        }
    }
}
