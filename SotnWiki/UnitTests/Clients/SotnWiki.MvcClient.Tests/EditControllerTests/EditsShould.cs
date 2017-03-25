using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.DTOs.EditViewsDTOs;
using SotnWiki.MvcClient.Controllers;
using SotnWiki.MvcClient.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace SotnWiki.MvcClient.Tests.EditControllerTests
{
    [TestFixture]
    public class EditsShould
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
        public void ShouldRenderDefaultViewWithModelEditsViewModel()
        {
            //Arrange & ACT & Assert
            controllerUnderTest.WithModelErrors().WithCallTo(c => c.Edits("asd"))
            .ShouldRenderDefaultView()
            .WithModel<EditsViewModel>();
        }

        [Test]
        public void ShouldInsertCorrectCollectionIntoViewModel()
        {
            //Arrange
            var edits = new List<EditsViewDTO>()
            {
                new EditsViewDTO() { Content = "adas" },
                new EditsViewDTO() { Content = "ad33aas" }
            };
            mockedContentSubmissionService.Setup(c => c.GetEdits(It.IsAny<string>())).Returns(edits);

            //Act
            var result = controllerUnderTest.Edits("asd") as ViewResult;
            EditsViewModel model = (EditsViewModel)result.ViewData.Model;

            //Assert
            CollectionAssert.AreEquivalent(edits, model.Results);
        }
    }
}
