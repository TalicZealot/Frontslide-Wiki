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

namespace SotnWiki.MvcClient.Tests.EditControllerTests
{
    [TestFixture]
    public class EditGetShould
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
        public void ThrowArgumentNullExceptionWhenNameIsNull()
        {
            //Arrange
            var model = new EditViewModel();
            string expectedExceptionMessage = "name";

            //Arrange & ACT & Assert
            var exc = Assert.Throws<ArgumentNullException>(() => { controllerUnderTest.Edit((string)null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentExceptionWhenNameIsEmptyString()
        {
            //Arrange
            var model = new EditViewModel();
            string expectedExceptionMessage = "name";

            //Arrange & ACT & Assert
            var exc = Assert.Throws<ArgumentException>(() => { controllerUnderTest.Edit(""); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void CallGetPageByTitleMethodOfPageService()
        {
            //Act
            var result = controllerUnderTest.Edit("asdf");

            //Assert
            mockedPageService.Verify(m => m.GetPageByTitle(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void ReturnHttpNotFoundIfPageIsNotFound()
        {
            //Arrange
            mockedPageService.Setup(p => p.GetPageByTitle(It.IsAny<string>())).Returns((PageViewDTO)null);

            //Act & Assert
            controllerUnderTest.WithCallTo(c => c.Edit("asdf"))
            .ShouldGiveHttpStatus(404);
        }

        [Test]
        public void ShouldRenderDefaultViewWithModelEditViewModel()
        {
            //Arrange
            var stubPageDto = new PageViewDTO();
            mockedPageService.Setup(p => p.GetPageByTitle(It.IsAny<string>())).Returns(stubPageDto);

            //Act & Assert
            controllerUnderTest.WithCallTo(c => c.Edit("asdf"))
            .ShouldRenderDefaultView()
            .WithModel<EditViewModel>();
        }
    }
}
