using Moq;
using NUnit.Framework;
using SotnWiki.Data.Repositories;
using SotnWiki.Data.Common.Tests.Mocks;
using SotnWiki.Models;
using System;
using System.Collections.Generic;

namespace SotnWiki.Data.Common.Tests.PageEfRepositoryTests
{
    [TestFixture]
    public class GetPageEntityByTitleShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenTitleIsNull()
        {
            //Arrange
            var mockedDbContext = new Mock<ISotnWikiDbContext>();
            string expectedExceptionMessage = "title";
            var pages = new List<Page>
            {
                new Page() {Id = Guid.NewGuid(), Title = "page", Content = "cntnt"},
                new Page() {Id = Guid.NewGuid(), Title = "page", Content = "cntnt"}
            };
            var mockedPageSet = QueryableDbSetMock.GetQueryableMockDbSet<Page>(pages);
            mockedDbContext.Setup(c => c.Set<Page>()).Returns(mockedPageSet);
            mockedDbContext.Setup(c => c.Pages).Returns(mockedPageSet);
            var repositoryUnderTest = new PageEfRepository(mockedDbContext.Object);

            //Act & Assert
            var exc = Assert.Throws<ArgumentNullException>(() => { repositoryUnderTest.GetPageEntityByTitle(null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullException_WhenTitleIsEmptyString()
        {
            //Arrange
            var mockedDbContext = new Mock<ISotnWikiDbContext>();
            string expectedExceptionMessage = "title";
            var pages = new List<Page>
            {
                new Page() {Id = Guid.NewGuid(), Title = "page", Content = "cntnt"},
                new Page() {Id = Guid.NewGuid(), Title = "page", Content = "cntnt"}
            };
            var mockedPageSet = QueryableDbSetMock.GetQueryableMockDbSet<Page>(pages);
            mockedDbContext.Setup(c => c.Set<Page>()).Returns(mockedPageSet);
            mockedDbContext.Setup(c => c.Pages).Returns(mockedPageSet);
            var repositoryUnderTest = new PageEfRepository(mockedDbContext.Object);

            //Act & Assert
            var exc = Assert.Throws<ArgumentException>(() => { repositoryUnderTest.GetPageEntityByTitle(""); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ReturnsNullWhenPageIsNotFound()
        {
            //Arrange
            var mockedDbContext = new Mock<ISotnWikiDbContext>();
            var pages = new List<Page>
            {
                new Page() {Id = Guid.NewGuid(), Title = "page", Content = "cntnt", IsPublished = true},
                new Page() {Id = Guid.NewGuid(), Title = "page", Content = "cntnt", IsPublished = true}
            };
            var mockedPageSet = QueryableDbSetMock.GetQueryableMockDbSet<Page>(pages);
            mockedDbContext.Setup(c => c.Set<Page>()).Returns(mockedPageSet);
            mockedDbContext.Setup(c => c.Pages).Returns(mockedPageSet);
            var repositoryUnderTest = new PageEfRepository(mockedDbContext.Object);

            //Act & Assert
            var result = repositoryUnderTest.GetPageEntityByTitle("fthfth");

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void ReturnsObjectOfTypePage()
        {
            //Arrange
            var mockedDbContext = new Mock<ISotnWikiDbContext>();
            var pages = new List<Page>
            {
                new Page() {Id = Guid.NewGuid(), Title = "page1", Content = "cntnt", IsPublished = true},
                new Page() {Id = Guid.NewGuid(), Title = "page2", Content = "cntnt", IsPublished = true}
            };
            var mockedPageSet = QueryableDbSetMock.GetQueryableMockDbSet<Page>(pages);
            mockedDbContext.Setup(c => c.Set<Page>()).Returns(mockedPageSet);
            mockedDbContext.Setup(c => c.Pages).Returns(mockedPageSet);
            var repositoryUnderTest = new PageEfRepository(mockedDbContext.Object);

            //Act & Assert
            var result = repositoryUnderTest.GetPageEntityByTitle("page1");

            //Assert
            Assert.IsInstanceOf<Page>(result);
        }
    }
}
