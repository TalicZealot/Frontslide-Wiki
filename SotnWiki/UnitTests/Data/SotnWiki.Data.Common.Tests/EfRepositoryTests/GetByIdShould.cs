using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common.Tests.Mocks;
using SotnWiki.Models;
using System;
using System.Collections.Generic;

namespace SotnWiki.Data.Common.Tests.EfGenericRepositoryTests
{
    [TestFixture]
    public class GetByIdShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedIdIsNull()
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
            string expectedExceptionMessage = "id";

            var repositoryUnderTest = new EfRepository<Page>(mockedDbContext.Object);

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => repositoryUnderTest.GetById(null));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ReturnsFoundObject()
        {
            //Arrange
            var pages = new List<Page>
            {
                new Page() {Id = Guid.NewGuid(), Title = "first", Content = "c2tgagntnt"},
                new Page() {Id = Guid.NewGuid(), Title = "pag5hgberge", Content = "cntnrts ftget"}
            };
            var mockedDbContext = new Mock<ISotnWikiDbContext>();
            var mockedPageSet = QueryableDbSetMock.GetQueryableMockDbSet<Page>(pages);

            mockedDbContext.Setup(c => c.Set<Page>()).Returns(mockedPageSet);
            mockedDbContext.Setup(c => c.Pages).Returns(mockedPageSet);

            var repositoryUnderTest = new EfRepository<Page>(mockedDbContext.Object);

            //Act
            var result = repositoryUnderTest.GetById(pages[0].Id);

            //Assert
            Assert.AreEqual(pages[0].Title, result.Title);
        }
    }
}
