using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.DTOs.PageViewsDTOs;
using SotnWiki.MvcClient.Controllers;
using SotnWiki.MvcClient.Models;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace SotnWiki.MvcClient.Tests.SubmissionsControllerTests
{
    [TestFixture]
    public class PublishGetShould
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
        public void ReturnHttpNotFound_WhenPageIsNotFound()
        {
            //Act
            var result = controllerUnderTest.Publish("asd");

            //Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(result);
        }

        [Test]
        public void ShouldRenderDefaultViewWithModelEditViewModel_WhenPageIsFound()
        {
            //Arrange
            var page = new PageViewDTO()
            {
                Title = "taityl"
            };
            mockedPageService.Setup(p => p.GetSubmissionByTitle(It.IsAny<string>())).Returns(page);

            //Act & Assert
            controllerUnderTest.WithCallTo(c => c.Publish("asd"))
           .ShouldRenderDefaultView()
           .WithModel<EditViewModel>();
        }
    }
}
