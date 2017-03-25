using Moq;
using NUnit.Framework;

namespace SotnWiki.Data.Common.Tests.EfUnitOfWorkTests
{
    [TestFixture]
    public class DisposeShould
    {
        [Test]
        public void NotThrow()
        {
            //Arrange
            var mockedDbContext = new Mock<ISotnWikiDbContext>();
            var unitOfWorkUnderTest = new EfUnitOfWork(mockedDbContext.Object);

            //Assert
            Assert.DoesNotThrow(() => unitOfWorkUnderTest.Dispose());
        }
    }
}
