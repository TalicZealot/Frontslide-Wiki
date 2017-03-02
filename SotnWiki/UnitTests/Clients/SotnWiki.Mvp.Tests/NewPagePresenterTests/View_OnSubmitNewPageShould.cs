using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.CustomEventArgs;
using SotnWiki.Mvp.NewPage;
using System.Web;

namespace SotnWiki.Mvp.Tests.NewPagePresenterTests
{
    [TestFixture]
    public class View_OnSubmitNewPageShould
    {
        [Test]
        public void ActivatesResponseRedirect()
        {
            //Arrange
            var mockedView = new Mock<INewPageView>();
            mockedView.Setup(v => v.Model).Returns(new NewPageViewModel());
            var mockedPageService = new Mock<IPageService>();
            var newPagePresenterUnderTest = new NewPagePresenter(mockedView.Object, mockedPageService.Object);
            var mockedHttpContext = new Mock<HttpContextBase>();
            var mockedHttpResponseBase = new Mock<HttpResponseBase>();
            newPagePresenterUnderTest.HttpContext = mockedHttpContext.Object;
            mockedHttpContext.Setup(x => x.Response).Returns(mockedHttpResponseBase.Object);
            mockedHttpResponseBase.Setup(x => x.Redirect(It.IsAny<string>())).Verifiable();

            //Act
            mockedView.Raise(v => v.OnSubmitNewPage += null, new PageSubmitEventArgs("aa", "aa", "aa", "aa", false));

            //Assert
            mockedHttpResponseBase.Verify(x => x.Redirect(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CallCreatePageMethodOfPageService()
        {
            //Arrange
            var mockedView = new Mock<INewPageView>();
            mockedView.Setup(v => v.Model).Returns(new NewPageViewModel());
            var mockedPageService = new Mock<IPageService>();
            var newPagePresenterUnderTest = new NewPagePresenter(mockedView.Object, mockedPageService.Object);
            var mockedHttpContext = new Mock<HttpContextBase>();
            var mockedHttpResponseBase = new Mock<HttpResponseBase>();
            newPagePresenterUnderTest.HttpContext = mockedHttpContext.Object;
            mockedHttpContext.Setup(x => x.Response).Returns(mockedHttpResponseBase.Object);
            mockedHttpResponseBase.Setup(x => x.Redirect(It.IsAny<string>())).Verifiable();

            //Act
            mockedView.Raise(v => v.OnSubmitNewPage += null, new PageSubmitEventArgs("aa", "aa", "aa", "aa", false));

            //Assert
            mockedPageService.Verify(x => x.CreatePage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()), Times.Once);
        }
    }
}
