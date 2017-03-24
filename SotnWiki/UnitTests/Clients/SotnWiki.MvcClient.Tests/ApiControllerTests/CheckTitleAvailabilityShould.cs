using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Controllers;
using System;
using System.Web.Mvc;

namespace SotnWiki.MvcClient.Tests.ApiControllerTests
{
    [TestFixture]
    public class CheckTitleAvailabilityShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenNameParameterIsNull()
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
        public void ThrowArgumentException_WhenNameParameterIsEmptyString()
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
            mockedPageService.Setup(p => p.CheckTitleAvailability(It.IsAny<string>())).Returns(false);

            //Act
            var result = controllerUnderTest.CheckTitleAvailability("asd");

            //Assert
            Assert.IsInstanceOf<JsonResult>(result);
        }

        [Test]
        public void ReturnsFalse_WhenPageIsFound()
        {
            //Arrange
            var mockedRunService = new Mock<IRunService>();
            var mockedPageService = new Mock<IPageService>();
            var controllerUnderTest = new ApiController(mockedPageService.Object, mockedRunService.Object);
            mockedPageService.Setup(p => p.CheckTitleAvailability(It.IsAny<string>())).Returns(false);
            var expectedJson = "false";

            //Act
            var result = controllerUnderTest.CheckTitleAvailability("asd") as JsonResult;
            var json = JsonConvert.SerializeObject(result.Data);

            //Assert
            Assert.AreEqual(expectedJson, json);
        }

        [Test]
        public void ReturnsTrue_WhenPageIsNotFound()
        {
            //Arrange
            var mockedRunService = new Mock<IRunService>();
            var mockedPageService = new Mock<IPageService>();
            var controllerUnderTest = new ApiController(mockedPageService.Object, mockedRunService.Object);
            mockedPageService.Setup(p => p.CheckTitleAvailability(It.IsAny<string>())).Returns(true);
            var expectedJson = "true";

            //Act
            var result = controllerUnderTest.CheckTitleAvailability("asd") as JsonResult;
            var json = JsonConvert.SerializeObject(result.Data);

            //Assert
            Assert.AreEqual(expectedJson, json);
        }
    }
}
