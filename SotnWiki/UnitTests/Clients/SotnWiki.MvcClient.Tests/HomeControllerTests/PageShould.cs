using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Controllers;
using SotnWiki.MvcClient.Models;
using SotnWiki.TextManipulation.Contracts;
using System;
using System.Web.Mvc;

namespace SotnWiki.MvcClient.Tests.HomeControllerTests
{
    [TestFixture]
    public class PageShould
    {
        [Test]
        public void ThrowArgumentNullExceptionIfPassedNameParameterIsNull()
        {
            //Arrange
            var mockedConverter = new Mock<IMarkupConverter>();
            var mockedPageService = new Mock<IPageService>();
            var controllerUnderTest = new HomeController(mockedPageService.Object, mockedConverter.Object);
            string expectedContent = "<h1>";
            var page = new SotnWiki.Models.Page()
            {
                Title = "aa",
                Content = ".h1"
            };
            mockedConverter.Setup(x => x.ScriptToHtml(It.IsAny<string>())).Returns(expectedContent);
            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns(page);
            string expectedExceptionMessage = "name";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { controllerUnderTest.Page(null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentExceptionIfPassedNameParameterIsEmptyString()
        {
            //Arrange
            var mockedConverter = new Mock<IMarkupConverter>();
            var mockedPageService = new Mock<IPageService>();
            var controllerUnderTest = new HomeController(mockedPageService.Object, mockedConverter.Object);
            string expectedContent = "<h1>";
            var page = new SotnWiki.Models.Page()
            {
                Title = "aa",
                Content = ".h1"
            };
            mockedConverter.Setup(x => x.ScriptToHtml(It.IsAny<string>())).Returns(expectedContent);
            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns(page);
            string expectedExceptionMessage = "name";

            //Act
            var exc = Assert.Throws<ArgumentException>(() => { controllerUnderTest.Page(""); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ReturnObjectOfTypeViewResult()
        {
            //Arrange
            var mockedConverter = new Mock<IMarkupConverter>();
            var mockedPageService = new Mock<IPageService>();
            var controllerUnderTest = new HomeController(mockedPageService.Object, mockedConverter.Object);
            string expectedContent = "<h1>";
            var page = new SotnWiki.Models.Page()
            {
                Title = "aa",
                Content = ".h1"
            };
            mockedConverter.Setup(x => x.ScriptToHtml(It.IsAny<string>())).Returns(expectedContent);
            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns(page);

            //Act
            var result = controllerUnderTest.Page("asd");

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
            var page = new SotnWiki.Models.Page()
            {
                Title = "aa",
                Content = ".h1"
            };
            mockedConverter.Setup(x => x.ScriptToHtml(It.IsAny<string>())).Returns(expectedContent);
            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns(page);

            //Act
            var result = (ViewResult)controllerUnderTest.Page("asd");
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
            var page = new SotnWiki.Models.Page()
            {
                Title = expectedTitle,
                Content = ".h1"
            };
            mockedConverter.Setup(x => x.ScriptToHtml(It.IsAny<string>())).Returns(expectedContent);
            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns(page);

            //Act
            var result = (ViewResult)controllerUnderTest.Page("asd");
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
            var page = new SotnWiki.Models.Page()
            {
                Title = expectedTitle,
                Content = ".h1"
            };
            mockedConverter.Setup(x => x.ScriptToHtml(It.IsAny<string>())).Returns(expectedContent);
            mockedPageService.Setup(x => x.GetPageByTitle(It.IsAny<string>())).Returns(page);

            //Act
            var result = (ViewResult)controllerUnderTest.Page("asd");
            var model = (PageViewModel)result.ViewData.Model;


            //Assert
            Assert.AreEqual(expectedContent, model.PageHtml);
        }
    }
}
