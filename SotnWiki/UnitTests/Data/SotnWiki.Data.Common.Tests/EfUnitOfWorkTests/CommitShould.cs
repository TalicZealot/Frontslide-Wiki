using Moq;
using NUnit.Framework;
using System;

namespace SotnWiki.Data.Common.Tests.EfUnitOfWorkTests
{
    [TestFixture]
    public class CommitShould
    {
        [Test]
        public void CallContextSaveChanges()
        {
            //Arrange
            var mockedDbContext = new Mock<ISotnWikiDbContext>();
            var unitOfWorkUnderTest = new EfUnitOfWork(mockedDbContext.Object);

            //Act & Assert
            unitOfWorkUnderTest.Commit();

            //Assert
            mockedDbContext.Verify(c => c.SaveChanges(), Times.Once());
        }
    }
}
