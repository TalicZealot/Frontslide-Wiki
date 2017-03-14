using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Models;
using SotnWiki.MvcClient.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SotnWiki.MvcClient.Tests.ApiControllerTests
{
    [TestFixture]
    public class AlucardACEShould
    {
        [Test]
        public void ReturnsObjectOfTypeJsonResult()
        {
            //Arrange
            var mockedRunService = new Mock<IRunService>();
            var controllerUnderTest = new ApiController(mockedRunService.Object);
            var runs = new List<Run>()
            {
                new Run () { Runner = "Dr4gonBlitz", Time = "16:54", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "romscout", Time = "16:59", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "BenAuton", Time = "17:10", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Metako", Time = "17:26", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360}
            };
            mockedRunService.Setup(x => x.GetRunsInCategory(It.IsAny<string>())).Returns(runs);

            //Act
            var result = controllerUnderTest.AlucardACE();

            //Assert
            Assert.IsInstanceOf<JsonResult>(result);
        }

        [Test]
        public void ReturnCorrectOrderedJsonCollection()
        {
            //Arrange
            var mockedRunService = new Mock<IRunService>();
            var controllerUnderTest = new ApiController(mockedRunService.Object);
            var runs = new List<Run>()
            {
                new Run () { Runner = "Metako", Time = "17:26", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Dr4gonBlitz", Time = "16:54", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "romscout", Time = "16:59", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "BenAuton", Time = "17:10", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360}
            };
            mockedRunService.Setup(x => x.GetRunsInCategory(It.IsAny<string>())).Returns(runs);

            var expectedJson = JsonConvert.SerializeObject(runs.OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList());

            //Act
            var result = controllerUnderTest.AlucardACE() as JsonResult;
            var json = JsonConvert.SerializeObject(result.Data);

            //Assert
            Assert.AreEqual(expectedJson, json);
        }
    }
}
