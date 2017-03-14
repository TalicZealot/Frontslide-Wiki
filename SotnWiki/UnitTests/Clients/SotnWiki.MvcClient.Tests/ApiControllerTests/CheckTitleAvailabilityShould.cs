using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Models;
using SotnWiki.MvcClient.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SotnWiki.MvcClient.Tests.ApiControllerTests
{
    [TestFixture]
    public class CheckTitleAvailabilityShould
    {
        [Test]
        public void ThrowArgumentNullExceptionIfNameParameterIsNull()
        {
            //Arrange
            var mockedRunService = new Mock<IRunService>();
            var mockedPageService = new Mock<IPageService>();
            var controllerUnderTest = new ApiController(mockedPageService.Object, mockedRunService.Object);
            string expectedExceptionMessage = "title";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { controllerUnderTest.CheckTitleAvailability(null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentExceptionIfNameParameterIsEmptyString()
        {
            //Arrange
            var mockedRunService = new Mock<IRunService>();
            var mockedPageService = new Mock<IPageService>();
            var controllerUnderTest = new ApiController(mockedPageService.Object, mockedRunService.Object);
            string expectedExceptionMessage = "name";

            //Act
            var exc = Assert.Throws<ArgumentException>(() => { controllerUnderTest.CheckTitleAvailability(""); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ReturnsObjectOfTypeJsonResult()
        {
            //Arrange
            var mockedRunService = new Mock<IRunService>();
            var mockedPageService = new Mock<IPageService>();
            var controllerUnderTest = new ApiController(mockedPageService.Object, mockedRunService.Object);
            var page = new Page() { Title = "asdf" };
            mockedPageService.Setup(p => p.GetPageByTitle(It.IsAny<string>())).Returns(page);

            //Act
            var result = controllerUnderTest.CheckTitleAvailability("asd");

            //Assert
            Assert.IsInstanceOf<JsonResult>(result);
        }

        [Test]
        public void ReturnsFalseIfPageIsFound()
        {
            //Arrange
            var mockedRunService = new Mock<IRunService>();
            var mockedPageService = new Mock<IPageService>();
            var controllerUnderTest = new ApiController(mockedPageService.Object, mockedRunService.Object);
            var page = new Page() { Title = "asdf" };
            mockedPageService.Setup(p => p.GetPageByTitle(It.IsAny<string>())).Returns(page);
            var expectedJson = "false";

            //Act
            var result = controllerUnderTest.CheckTitleAvailability("asd") as JsonResult;
            var json = JsonConvert.SerializeObject(result.Data);

            //Assert
            Assert.AreEqual(expectedJson, json);
        }

        [Test]
        public void ReturnsTrueIfPageIsNotFound()
        {
            //Arrange
            var mockedRunService = new Mock<IRunService>();
            var mockedPageService = new Mock<IPageService>();
            var controllerUnderTest = new ApiController(mockedPageService.Object, mockedRunService.Object);
            var page = new Page() { Title = "asdf" };
            mockedPageService.Setup(p => p.GetPageByTitle(It.IsAny<string>())).Returns((Page)null);
            var expectedJson = "true";

            //Act
            var result = controllerUnderTest.CheckTitleAvailability("asd") as JsonResult;
            var json = JsonConvert.SerializeObject(result.Data);

            //Assert
            Assert.AreEqual(expectedJson, json);
        }
    }
}
