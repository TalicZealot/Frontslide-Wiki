using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;
using SotnWiki.Auth.Contracts;
using SotnWiki.MvcClient.Controllers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SotnWiki.MvcClient.Tests.AccountControllerTests
{
    [TestFixture]
    public class ExternalLoginCallbackShould
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
        public async Task ShouldReturnChallengeResult_WhenLoginInfoIsNull()
        {
            //Act
            var result = await controllerUnderTest.ExternalLoginCallback("asd") as RedirectToRouteResult;

            //Assert
            Assert.AreEqual("ExternalLoginFailure", result.RouteValues["action"]);
            Assert.IsNull(result.RouteValues["controller"]);
        }
    }
}
