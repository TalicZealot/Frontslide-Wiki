using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common.Tests.Mocks;
using SotnWiki.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SotnWiki.Data.Common.Tests.EfGenericRepositoryTests
{
    [TestFixture]
    public class DeleteShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenPassedEntityIsNull()
        {
            //Arrange
            var pages = new List<Page>
            {
                new Page() {Id = Guid.NewGuid(), Title = "page", Content = "cntnt"},
                new Page() {Id = Guid.NewGuid(), Title = "page", Content = "cntnt"}
            };
            var mockedDbContext = new Mock<ISotnWikiDbContext>();
            var mockedPageSet = QueryableDbSetMock.GetQueryableMockDbSet<Page>(pages);

            mockedDbContext.Setup(c => c.Set<Page>()).Returns(mockedPageSet);
            mockedDbContext.Setup(c => c.Pages).Returns(mockedPageSet);
            string expectedExceptionMessage = "entity";

            var repositoryUnderTest = new EfGenericRepository<Page>(mockedDbContext.Object);

            //Act & Assert
            var exc = Assert.Throws<ArgumentNullException>(() => repositoryUnderTest.Delete(null));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
