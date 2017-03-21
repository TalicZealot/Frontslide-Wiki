﻿using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Controllers;
using SotnWiki.MvcClient.Models;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestStack.FluentMVCTesting;

namespace SotnWiki.MvcClient.Tests.EditControllerTests
{
    [TestFixture]
    public class EditPostShould
    {
        private EditController controllerUnderTest;
        private Mock<IPageService> mockedPageService;
        private Mock<IContentSubmissionService> mockedContentSubmissionService;

        [SetUp]
        public void Setup()
        {
            this.mockedPageService = new Mock<IPageService>();
            this.mockedContentSubmissionService = new Mock<IContentSubmissionService>();
            this.controllerUnderTest = new EditController(mockedPageService.Object, mockedContentSubmissionService.Object);
        }

        [Test]
        public void RenderEditViewWhenModelHasErrors()
        {
            //Arrange
            var model = new EditViewModel();

            //Arrange & ACT & Assert
            controllerUnderTest.WithModelErrors().WithCallTo(c => c.Edit(model))
            .ShouldRenderDefaultView()
            .WithModel(model);
        }

        [Test]
        public void RedirectToThePageWhenModelIsValid()
        {
            //Arrange
            var model = new EditViewModel() { Publish = false };

            //Arrange & Act & Assert
            controllerUnderTest.WithCallTo(c => c.Edit(model))
            .ShouldRedirectTo<HomeController>(x => x.Page(It.IsAny<string>()));
        }

        [Test]
        public void CallSubmitAndPublishEditWhenModelPublishPropertyIsTrue()
        {
            //Arrange
            var model = new EditViewModel() { Publish = true };
            var mockedHttpCOntext = new Mock<HttpContextBase>();
            var mockedUser = new Mock<IPrincipal>();
            mockedHttpCOntext.SetupGet(h => h.User).Returns(mockedUser.Object);
            mockedUser.Setup(u => u.IsInRole(It.IsAny<string>())).Returns(true);
            controllerUnderTest.ControllerContext = new ControllerContext(mockedHttpCOntext.Object, new RouteData(), controllerUnderTest);

            //Act
            var result = controllerUnderTest.Edit(model);

            //Assert
            mockedContentSubmissionService.Verify(m => m.SubmitAndPublishEdit(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void CallSubmitEditWhenModelPublishPropertyIsFalse()
        {
            //Arrange
            var model = new EditViewModel() { Publish = false };

            //Act
            var result = controllerUnderTest.Edit(model);

            //Assert
            mockedContentSubmissionService.Verify(m => m.SubmitEdit(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }
    }
}