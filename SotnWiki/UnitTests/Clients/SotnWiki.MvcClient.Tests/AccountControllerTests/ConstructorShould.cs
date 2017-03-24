using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;
using SotnWiki.Auth.Contracts;
using SotnWiki.MvcClient.Controllers;
using System;

namespace SotnWiki.MvcClient.Tests.AccountControllerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenSignInServiceIsNull()
        {
            //Arrange
            var mockedSignInService = new Mock<ISignInService>();
            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            string expectedExceptionMessage = "userService";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new AccountController(mockedSignInService.Object, null, mockedAuthenticationManager.Object); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserServiceIsNull()
        {
            //Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            string expectedExceptionMessage = "signInService";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new AccountController(null, mockedUserService.Object, mockedAuthenticationManager.Object); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullException_WhenAuthenticationManagerIsNull()
        {
            //Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedSignInService = new Mock<ISignInService>();
            string expectedExceptionMessage = "authenticationManager";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new AccountController(mockedSignInService.Object, mockedUserService.Object, null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ReturnsAnInstance_WhenBothParametersAreNotNull()
        {
            //Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedSignInService = new Mock<ISignInService>();
            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();

            //Act
            var controllerUnderTest = new AccountController(mockedSignInService.Object, mockedUserService.Object, mockedAuthenticationManager.Object);

            //Assert
            Assert.IsNotNull(controllerUnderTest);
        }
    }
}
