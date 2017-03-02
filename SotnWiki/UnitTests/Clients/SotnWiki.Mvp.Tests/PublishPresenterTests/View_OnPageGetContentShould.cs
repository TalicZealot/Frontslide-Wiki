using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.CustomEventArgs;
using SotnWiki.Mvp.Publish;
using System.Web;

namespace SotnWiki.Mvp.Tests.PublishPresenterTests
{
    [TestFixture]
    public class View_OnPageGetContentShould
    {
        [Test]
        public void SetHttpResponseTo404WhenPageIsNotFound()
        {
            //Arrange
            var mockedView = new Mock<IPublishView>();
            mockedView.Setup(v => v.Model).Returns(new PublishViewModel());
            var mockedPageService = new Mock<IPageService>();
            var publishPresenterUnderTest = new PublishPresenter(mockedView.Object, mockedPageService.Object);
            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns((SotnWiki.Models.Page)null);
            var mockedHttpContext = new Mock<HttpContextBase>();
            var mockedHttpResponseBase = new Mock<HttpResponseBase>();
            publishPresenterUnderTest.HttpContext = mockedHttpContext.Object;
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
            var mockedView = new Mock<IPublishView>();
            mockedView.Setup(v => v.Model).Returns(new PublishViewModel());
            var mockedPageService = new Mock<IPageService>();
            var publishPresenterUnderTest = new PublishPresenter(mockedView.Object, mockedPageService.Object);
            string expectedTitle = "page title";
            string expectedContent = "edit content";
            var page = new SotnWiki.Models.Page()
            {
                Title = expectedTitle,
                Content = expectedContent
            };
            mockedPageService.Setup(x => x.GetSubmissionByTitle(It.IsAny<string>())).Returns(page);

            //Act
            mockedView.Raise(v => v.OnPageGetContent += null, new PageEventArgs(""));

            //Assert
            Assert.AreEqual(expectedTitle, mockedView.Object.Model.Title);
        }

        [Test]
        public void SetViewModelContentCorrectly()
        {
            //Arrange
            var mockedView = new Mock<IPublishView>();
            mockedView.Setup(v => v.Model).Returns(new PublishViewModel());
            var mockedPageService = new Mock<IPageService>();
            var publishPresenterUnderTest = new PublishPresenter(mockedView.Object, mockedPageService.Object);
            string expectedContent = "edit content";
            var page = new SotnWiki.Models.Page()
            {
                Content = expectedContent
            };
            mockedPageService.Setup(x => x.GetSubmissionByTitle(It.IsAny<string>())).Returns(page);

            //Act
            mockedView.Raise(v => v.OnPageGetContent += null, new PageEventArgs(""));

            //Assert
            Assert.AreEqual(expectedContent, mockedView.Object.Model.Content);
        }
    }
}
