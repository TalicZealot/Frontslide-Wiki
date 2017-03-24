using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;
using SotnWiki.Auth.Contracts;
using SotnWiki.MvcClient.Controllers;
using TestStack.FluentMVCTesting;

namespace SotnWiki.MvcClient.Tests.AccountControllerTests
{
    [TestFixture]
    public class ExternalLoginFailureShould
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
        public void ShouldRenderDefaultView()
        {
            //Arrange & ACT & Assert
            controllerUnderTest.WithCallTo(c => c.ExternalLoginFailure())
            .ShouldRenderDefaultView();
        }
    }
}
