using NUnit.Framework;
using SotnWiki.MvcClient.Controllers;
using TestStack.FluentMVCTesting;

namespace SotnWiki.MvcClient.Tests.LeaderboardsControllerTests
{
    [TestFixture]
    public class LeaderboardsShould
    {
        [Test]
        public void ShouldRenderDefaultView()
        {
            //Arrange
            var controllerUnderTest = new LeaderboardsController();

            //Act & Assert
            controllerUnderTest.WithCallTo(c => c.Leaderboards())
                .ShouldRenderDefaultView();
        }
    }
}
