using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.CustomEventArgs;
using SotnWiki.Mvp.Edit;
using SotnWiki.TextManipulation.Contracts;
using System.Web;

namespace SotnWiki.Mvp.Tests.EditPresenterTests
{
    [TestFixture]
    public class View_OnPageGetContentShould
    {
        [Test]
        public void SetsHttpResponseTo404()
        {
            //Arrange
            var mockedView = new Mock<IEditView>();
            mockedView.Setup(v => v.Model).Returns(new EditViewModel());
            var mockedPageService = new Mock<IPageService>();
            var mockedContentSubmissionService = new Mock<IContentSubmissionService>();
            var editPresenterUnderTest = new EditPresenter(mockedView.Object, mockedPageService.Object, mockedContentSubmissionService.Object);
            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns((SotnWiki.Models.Page)null);
            var mockedHttpContext = new Mock<HttpContextBase>();
            var mockedHttpResponseBase = new Mock<HttpResponseBase>();

            editPresenterUnderTest.HttpContext = mockedHttpContext.Object;
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
            var mockedView = new Mock<IEditView>();
            mockedView.Setup(v => v.Model).Returns(new EditViewModel());
            var mockedPageService = new Mock<IPageService>();
            var mockedContentSubmissionService = new Mock<IContentSubmissionService>();
            var pagePresenterUnderTest = new EditPresenter(mockedView.Object, mockedPageService.Object, mockedContentSubmissionService.Object);
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
            var mockedView = new Mock<IEditView>();
            mockedView.Setup(v => v.Model).Returns(new EditViewModel());
            var mockedPageService = new Mock<IPageService>();
            var mockedContentSubmissionService = new Mock<IContentSubmissionService>();
            var defaultPresenterUnderTest = new EditPresenter(mockedView.Object, mockedPageService.Object, mockedContentSubmissionService.Object);
            string expectedContent = "<h1>";
            var page = new SotnWiki.Models.Page()
            {
                Title = "aa",
                Content = expectedContent
            };
            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns(page);

            //Act
            mockedView.Raise(v => v.OnPageGetContent += null, new PageEventArgs(""));

            //Assert
            Assert.AreEqual(expectedContent, mockedView.Object.Model.Content);
        }
    }
}
