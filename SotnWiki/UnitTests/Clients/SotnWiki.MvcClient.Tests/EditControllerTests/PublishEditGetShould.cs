using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.DTOs.EditViewsDTOs;
using SotnWiki.MvcClient.Controllers;
using SotnWiki.MvcClient.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestStack.FluentMVCTesting;

namespace SotnWiki.MvcClient.Tests.EditControllerTests
{
    [TestFixture]
    public class PublishEditGetShould
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
        public void ReturnHttpNotFound_WhenContentSubmissionIsNotFound()
        {
            //Act
            var result = controllerUnderTest.PublishEdit(Guid.NewGuid().ToString());

            //Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(result);
        }

        [Test]
        public void ReturnHttpNotFound_WhenParameterIsNotValidGuid()
        {
            //Act
            var result = controllerUnderTest.PublishEdit("asdasd");

            //Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(result);
        }

        [Test]
        public void ShouldRenderDefaultViewWithModelEditViewModel_WhenEditIsFound()
        {
            //Arrange
            var routeData = new RouteData();
            routeData.Values.Add("title", "value1");
            var mockedHttpCOntext = new Mock<HttpContextBase>();
            var controllerContext = new ControllerContext(mockedHttpCOntext.Object, routeData, controllerUnderTest);
            controllerUnderTest.ControllerContext = controllerContext;

            var edit = new EditsViewDTO()
            {
                Content = "adaadad"
            };

            mockedContentSubmissionService.Setup(c => c.GetPageContentSubmissionById(It.IsAny<Guid>())).Returns(edit);

            //Act & Assert
            controllerUnderTest.WithCallTo(c => c.PublishEdit(Guid.NewGuid().ToString()))
            .ShouldRenderDefaultView()
            .WithModel<EditViewModel>();
        }
    }
}
