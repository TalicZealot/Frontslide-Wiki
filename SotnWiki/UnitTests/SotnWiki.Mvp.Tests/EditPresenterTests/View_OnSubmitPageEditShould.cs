using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.CustomEventArgs;
using SotnWiki.Mvp.Edit;
using System.Web;

namespace SotnWiki.Mvp.Tests.EditPresenterTests
{
    [TestFixture]
    public class View_OnSubmitPageEditShould
    {
        [Test]
        public void CallsSubmitEditMethodOfContentSubmissionService()
        {   
            //Arrange
            var mockedView = new Mock<IEditView>();
            mockedView.Setup(v => v.Model).Returns(new EditViewModel());
            var mockedPageService = new Mock<IPageService>();
            var mockedContentSubmissionService = new Mock<IContentSubmissionService>();
            var editPresenterUnderTest = new EditPresenter(mockedView.Object, mockedPageService.Object, mockedContentSubmissionService.Object);
            var mockedHttpContext = new Mock<HttpContextBase>();
            var mockedHttpResponseBase = new Mock<HttpResponseBase>();
            editPresenterUnderTest.HttpContext = mockedHttpContext.Object;
            mockedHttpContext.Setup(x => x.Response).Returns(mockedHttpResponseBase.Object);
            mockedHttpResponseBase.Setup(x => x.Redirect(It.IsAny<string>())).Verifiable();

            //Act
            mockedView.Raise(v => v.OnSubmitPageEdit += null, new EditPageEventArgs("title","content",false));

            //Assert
            mockedContentSubmissionService.Verify(x => x.SubmitEdit(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ActivatesResponseRedirect()
        {
            //Arrange
            var mockedView = new Mock<IEditView>();
            mockedView.Setup(v => v.Model).Returns(new EditViewModel());
            var mockedPageService = new Mock<IPageService>();
            var mockedContentSubmissionService = new Mock<IContentSubmissionService>();
            var editPresenterUnderTest = new EditPresenter(mockedView.Object, mockedPageService.Object, mockedContentSubmissionService.Object);
            var mockedHttpContext = new Mock<HttpContextBase>();
            var mockedHttpResponseBase = new Mock<HttpResponseBase>();
            editPresenterUnderTest.HttpContext = mockedHttpContext.Object;
            mockedHttpContext.Setup(x => x.Response).Returns(mockedHttpResponseBase.Object);
            mockedHttpResponseBase.Setup(x => x.Redirect(It.IsAny<string>())).Verifiable();

            //Act
            mockedView.Raise(v => v.OnSubmitPageEdit += null, new EditPageEventArgs("title", "content", false));

            //Assert
            mockedHttpResponseBase.Verify(x => x.Redirect(It.IsAny<string>()), Times.Once);
        }
    }
}
