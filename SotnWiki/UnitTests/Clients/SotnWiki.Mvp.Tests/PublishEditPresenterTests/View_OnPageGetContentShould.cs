using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Models;
using SotnWiki.Mvp.CustomEventArgs;
using SotnWiki.Mvp.PublishEdit;
using System;
using System.Web;

namespace SotnWiki.Mvp.Tests.PublishEditPresenterTests
{
    [TestFixture]
    public class View_OnPageGetContentShould
    {
        [Test]
        public void SetHttpResponseTo404WhenContentSubmissionIsNotFound()
        {
            //Arrange
            var mockedView = new Mock<IPublishEditView>();
            mockedView.Setup(v => v.Model).Returns(new PublishEditViewModel());
            var mockedPageService = new Mock<IPageService>();
            var mockedContentSubmissionService = new Mock<IContentSubmissionService>();
            var pagePresenterUnderTest = new PublishEditPresenter(mockedView.Object, mockedPageService.Object, mockedContentSubmissionService.Object);
            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns((SotnWiki.Models.Page)null);
            mockedContentSubmissionService.Setup(x => x.GetPageContentSubmissionById(It.IsAny<Guid>())).Returns((PageContentSubmission)null);
            var mockedHttpContext = new Mock<HttpContextBase>();
            var mockedHttpResponseBase = new Mock<HttpResponseBase>();
            pagePresenterUnderTest.HttpContext = mockedHttpContext.Object;
            mockedHttpContext.Setup(x => x.Response).Returns(mockedHttpResponseBase.Object);
            mockedHttpResponseBase.SetupSet(x => x.StatusCode = 404).Verifiable();
            mockedHttpResponseBase.SetupSet(x => x.Status = "404 not found").Verifiable();

            //Act
            mockedView.Raise(v => v.OnPageGetContent += null, new IdEventArgs(Guid.NewGuid(), ""));

            //Assert
            mockedHttpResponseBase.Verify();
        }

        [Test]
        public void SetViewModelTitleCorrectly()
        {
            //Arrange
            var mockedView = new Mock<IPublishEditView>();
            mockedView.Setup(v => v.Model).Returns(new PublishEditViewModel());
            var mockedPageService = new Mock<IPageService>();
            var mockedContentSubmissionService = new Mock<IContentSubmissionService>();
            var pagePresenterUnderTest = new PublishEditPresenter(mockedView.Object, mockedPageService.Object, mockedContentSubmissionService.Object);
            string expectedTitle = "page title";
            string expectedContent = "edit content";
            var contentSubmission = new PageContentSubmission()
            {
                Content = expectedContent
            };
            mockedContentSubmissionService.Setup(x => x.GetPageContentSubmissionById(It.IsAny<Guid>())).Returns(contentSubmission);

            //Act
            mockedView.Raise(v => v.OnPageGetContent += null, new IdEventArgs(Guid.NewGuid(), expectedTitle));

            //Assert
            Assert.AreEqual(expectedTitle, mockedView.Object.Model.Title);
        }

        [Test]
        public void SetViewModelHtmlCorrectly()
        {
            //Arrange
            var mockedView = new Mock<IPublishEditView>();
            mockedView.Setup(v => v.Model).Returns(new PublishEditViewModel());
            var mockedPageService = new Mock<IPageService>();
            var mockedContentSubmissionService = new Mock<IContentSubmissionService>();
            var defaultPresenterUnderTest = new PublishEditPresenter(mockedView.Object, mockedPageService.Object, mockedContentSubmissionService.Object);
            string expectedTitle = "page title";
            string expectedContent = "edit content";
            var contentSubmission = new PageContentSubmission()
            {
                Content = expectedContent
            };
            mockedContentSubmissionService.Setup(x => x.GetPageContentSubmissionById(It.IsAny<Guid>())).Returns(contentSubmission);

            //Act
            mockedView.Raise(v => v.OnPageGetContent += null, new IdEventArgs(Guid.NewGuid(), expectedTitle));

            //Assert
            Assert.AreEqual(expectedContent, mockedView.Object.Model.Content);
        }
    }
}
