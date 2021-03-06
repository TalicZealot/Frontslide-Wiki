﻿using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;
using SotnWiki.Auth.Contracts;
using SotnWiki.MvcClient.Controllers;
using System.Web.Mvc;

namespace SotnWiki.MvcClient.Tests.AccountControllerTests
{
    [TestFixture]
    public class ExternalLoginShould
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
        public void ShouldReturnChallengeResult()
        {
            //Arrange
            var UrlHelperMock = new Mock<UrlHelper>();
            controllerUnderTest.Url = UrlHelperMock.Object;

            //Act
            var result = controllerUnderTest.ExternalLogin("asd", "asd");

            //Assert
            Assert.IsInstanceOf<HttpUnauthorizedResult>(result);
        }
    }
}
