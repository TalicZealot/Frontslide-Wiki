using NUnit.Framework;
using SotnWiki.MvcClient.Controllers;

namespace SotnWiki.MvcClient.Tests.LeaderboardsControllerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ReturnsAnInstance_WhenParametersAreNotNull()
        {
            //Act
            var controllerUnderTest = new LeaderboardsController();

            //Assert
            Assert.IsNotNull(controllerUnderTest);
        }
    }
}
