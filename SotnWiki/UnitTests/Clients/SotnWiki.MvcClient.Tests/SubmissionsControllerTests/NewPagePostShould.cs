using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Controllers;
using SotnWiki.MvcClient.Models;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestStack.FluentMVCTesting;

namespace SotnWiki.MvcClient.Tests.SubmissionsControllerTests
{
    [TestFixture]
    public class NewPagePostShould
    {
        private SubmissionsController controllerUnderTest;
        private Mock<IPageService> mockedPageService;
        private Mock<IContentSubmissionService> mockedContentSubmissionService;

        [SetUp]
        public void Setup()
        {
            mockedPageService = new Mock<IPageService>();
            mockedContentSubmissionService = new Mock<IContentSubmissionService>();
            controllerUnderTest = new SubmissionsController(mockedPageService.Object, mockedContentSubmissionService.Object);
        }

        [Test]
        public void ShouldRenderDefaultViewWithSameModelWhenModelHasErrors()
        {
            //Arrange
            var vm = new NewPageViewModel();

            //Act & Assert
            controllerUnderTest.WithModelErrors().WithCallTo(c => c.NewPage(vm))
                .ShouldRenderDefaultView()
                .WithModel(vm);
        }

        [Test]
        public void ShouldRedirectToHomePageWhenModelPublishIsFalse()
        {
            //Arrange
            var vm = new NewPageViewModel() { Character = "Alucard", Content = "asdasd", Title = "asdasd", Type = "asdasd", Publish = false };

            //Act & Assert
            controllerUnderTest.WithCallTo(c => c.NewPage(vm))
                .ShouldRedirectTo<HomeController>(x => x.Index());
        }

        [Test]
        public void ShouldRedirectToTheNewPageWhenModelPublishIsTrue()
        {
            //Arrange
            var expectedRouteValue = "test-title";
            var vm = new NewPageViewModel() { Publish = true, Character = "Alucard", Content = "asdasd", Title = expectedRouteValue, Type = "asdasd" };
            var mockedHttpCOntext = new Mock<HttpContextBase>();
            var mockedUser = new Mock<IPrincipal>();
            mockedHttpCOntext.SetupGet(h => h.User).Returns(mockedUser.Object);
            mockedUser.Setup(u => u.IsInRole(It.IsAny<string>())).Returns(true);
            controllerUnderTest.ControllerContext = new ControllerContext(mockedHttpCOntext.Object, new RouteData(), controllerUnderTest);

            //Act & Assert
            controllerUnderTest.WithCallTo(c => c.NewPage(vm))
                .ShouldRedirectTo<HomeController>(x => x.Page(expectedRouteValue));
        }

        [Test]
        public void ShouldCallCreatePageMethodOfPageService()
        {
            //Arrange
            var expectedRouteValue = "test-title";
            var vm = new NewPageViewModel() { Publish = true, Character = "Alucard", Content = "asdasd", Title = expectedRouteValue, Type = "asdasd" };
            var mockedHttpCOntext = new Mock<HttpContextBase>();
            var mockedUser = new Mock<IPrincipal>();
            mockedHttpCOntext.SetupGet(h => h.User).Returns(mockedUser.Object);
            mockedUser.Setup(u => u.IsInRole(It.IsAny<string>())).Returns(true);
            controllerUnderTest.ControllerContext = new ControllerContext(mockedHttpCOntext.Object, new RouteData(), controllerUnderTest);

            //Act
            var result = controllerUnderTest.NewPage(vm);

            //Assert
            mockedPageService.Verify(p => p.CreatePage(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()), Times.Once());
        }
    }
}
