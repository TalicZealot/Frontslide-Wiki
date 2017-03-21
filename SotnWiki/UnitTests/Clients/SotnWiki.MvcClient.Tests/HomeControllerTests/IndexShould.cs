using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.DTOs.PageViewsDTOs;
using SotnWiki.MvcClient.Controllers;
using SotnWiki.MvcClient.Models;
using SotnWiki.TextManipulation.Contracts;
using System.Web.Mvc;

namespace SotnWiki.MvcClient.Tests.HomeControllerTests
{
    [TestFixture]
    public class IndexShould
    {
        [Test]
        public void ReturnObjectOfTypeHttpNotFoundResultIfPageServiceReturnsNull()
        {
            //Arrange
            var mockedConverter = new Mock<IMarkupConverter>();
            var mockedPageService = new Mock<IPageService>();
            var controllerUnderTest = new HomeController(mockedPageService.Object, mockedConverter.Object);
            string expectedContent = "<h1>";
            mockedConverter.Setup(x => x.ScriptToHtml(It.IsAny<string>())).Returns(expectedContent);
            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns((PageViewDTO)null);

            //Act
            var result = controllerUnderTest.Index();

            //Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(result);
        }

        [Test]
        public void ReturnObjectOfTypeViewResult()
        {
            //Arrange
            var mockedConverter = new Mock<IMarkupConverter>();
            var mockedPageService = new Mock<IPageService>();
            var controllerUnderTest = new HomeController(mockedPageService.Object , mockedConverter.Object);
            string expectedContent = "<h1>";
            var page = new PageViewDTO()
            {
                Title = "aa",
                Content = ".h1"
            };
            mockedConverter.Setup(x => x.ScriptToHtml(It.IsAny<string>())).Returns(expectedContent);
            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns(page);

            //Act
            var result = controllerUnderTest.Index();

            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void PassesModelOfTypePageViewModelToView()
        {
            //Arrange
            var mockedConverter = new Mock<IMarkupConverter>();
            var mockedPageService = new Mock<IPageService>();
            var controllerUnderTest = new HomeController(mockedPageService.Object, mockedConverter.Object);
            string expectedContent = "<h1>";
            var page = new PageViewDTO()
            {
                Title = "aa",
                Content = ".h1"
            };
            mockedConverter.Setup(x => x.ScriptToHtml(It.IsAny<string>())).Returns(expectedContent);
            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns(page);

            //Act
            var result = (ViewResult)controllerUnderTest.Index();
            var model = result.ViewData.Model;
            

            //Assert
            Assert.IsInstanceOf<PageViewModel>(model);
        }

        [Test]
        public void SetViewModelTitleCorrectly()
        {
            //Arrange
            var mockedConverter = new Mock<IMarkupConverter>();
            var mockedPageService = new Mock<IPageService>();
            var controllerUnderTest = new HomeController(mockedPageService.Object, mockedConverter.Object);
            string expectedContent = "<h1>";
            string expectedTitle = "test-title";
            var page = new PageViewDTO()
            {
                Title = expectedTitle,
                Content = ".h1"
            };
            mockedConverter.Setup(x => x.ScriptToHtml(It.IsAny<string>())).Returns(expectedContent);
            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns(page);

            //Act
            var result = (ViewResult)controllerUnderTest.Index();
            var model = (PageViewModel)result.ViewData.Model;


            //Assert
            Assert.AreEqual(expectedTitle, model.Title);
        }

        [Test]
        public void SetViewModelContentCorrectly()
        {
            //Arrange
            var mockedConverter = new Mock<IMarkupConverter>();
            var mockedPageService = new Mock<IPageService>();
            var controllerUnderTest = new HomeController(mockedPageService.Object, mockedConverter.Object);
            string expectedContent = "<h1>";
            string expectedTitle = "test-title";
            var page = new PageViewDTO()
            {
                Title = expectedTitle,
                Content = ".h1"
            };
            mockedConverter.Setup(x => x.ScriptToHtml(It.IsAny<string>())).Returns(expectedContent);
            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns(page);

            //Act
            var result = (ViewResult)controllerUnderTest.Index();
            var model = (PageViewModel)result.ViewData.Model;


            //Assert
            Assert.AreEqual(expectedContent, model.PageHtml);
        }
    }
}
