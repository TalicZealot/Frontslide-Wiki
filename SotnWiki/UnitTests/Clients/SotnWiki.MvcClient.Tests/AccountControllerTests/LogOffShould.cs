using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;
using SotnWiki.Auth.Contracts;
using SotnWiki.MvcClient.Controllers;
using TestStack.FluentMVCTesting;

namespace SotnWiki.MvcClient.Tests.AccountControllerTests
{
    [TestFixture]
    public class LogOffShould
    {
        private AccountController controllerUnderTest;
        private Mock<IUserService> mockedUserService;
        private Mock<ISignInService> mockedSignInService;
        private Mock<IAuthenticationManager> mockedAuthenticationManager;

        [SetUp]
        public void Setup()
        {
            this.mockedUserService = new Mock<IUserService>();
            this.mockedSignInService = new Mock<ISignInService>();
            this.mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            this.controllerUnderTest = new AccountController(mockedSignInService.Object, mockedUserService.Object, mockedAuthenticationManager.Object);
        }

        [Test]
        public void ShouldRedirectToMainPage()
        {
            //Act & Assert
            controllerUnderTest.WithCallTo(c => c.LogOff())
                .ShouldRedirectTo<HomeController>(typeof(HomeController).GetMethod("Index"));
        }

        [Test]
        public void CallSignOutMethodOfAuthManager()
        {
            //Act
            controllerUnderTest.LogOff();

            //Assert
            mockedAuthenticationManager.Verify(m => m.SignOut(It.IsAny<string>()), Times.Once());
        }
    }
}
