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
    public class PublishEditPostShould
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
        public void ShouldRenderDefaultViewWithTheSameModelAsParameter_WhenModelStateIsNotValid()
        {
            //Arrange
            var model = new EditViewModel()
            {
                Id = Guid.NewGuid()
            };

            //Act & Assert
            controllerUnderTest.WithModelErrors().WithCallTo(c => c.PublishEdit(model))
            .ShouldRenderDefaultView()
            .WithModel<EditViewModel>(model);
        }

        [Test]
        public void ShouldRedirectToPage_WhenModelStateIsValid()
        {
            //Arrange
            var routeData = new RouteData();
            routeData.Values.Add("title", "value1");
            var mockedHttpCOntext = new Mock<HttpContextBase>();
            var controllerContext = new ControllerContext(mockedHttpCOntext.Object, routeData, controllerUnderTest);
            controllerUnderTest.ControllerContext = controllerContext;

            var model = new EditViewModel()
            {
                Id = Guid.NewGuid()
            };

            //Act & Assert
            controllerUnderTest.WithCallTo(c => c.PublishEdit(model))
            .ShouldRedirectTo<HomeController>(typeof(HomeController).GetMethod("Page"));
        }
    }
}
