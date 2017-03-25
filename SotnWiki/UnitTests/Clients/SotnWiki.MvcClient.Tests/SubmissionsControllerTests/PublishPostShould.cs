using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.DTOs.PageViewsDTOs;
using SotnWiki.MvcClient.Controllers;
using SotnWiki.MvcClient.Models;
using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestStack.FluentMVCTesting;

namespace SotnWiki.MvcClient.Tests.SubmissionsControllerTests
{
    [TestFixture]
    public class PublishPostShould
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
        public void ShouldRenderDefaultViewWithSameModelAsParameter_WhenModelStateIsNotValid()
        {
            //Arrange
            var model = new EditViewModel() { Id = Guid.NewGuid() };

            //Act & Assert
            controllerUnderTest.WithModelErrors().WithCallTo(c => c.Publish(model))
           .ShouldRenderDefaultView()
           .WithModel<EditViewModel>(model);
        }

        [Test]
        public void ShouldRedirectToPage_WhenModelStateIsValid()
        {
            //Arrange
            var model = new EditViewModel() { Id = Guid.NewGuid(), Title = "asd1" };

            //Act & Assert
            controllerUnderTest.WithCallTo(c => c.Publish(model))
           .ShouldRedirectTo<HomeController>(typeof(HomeController).GetMethod("Page"));
        }
    }
}
