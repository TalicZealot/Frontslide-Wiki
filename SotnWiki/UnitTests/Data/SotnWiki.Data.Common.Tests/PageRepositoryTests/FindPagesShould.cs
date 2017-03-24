using Moq;
using NUnit.Framework;
using SotnWiki.Data.Repositories;
using SotnWiki.Data.Common.Tests.Mocks;
using SotnWiki.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SotnWiki.Data.Common.Tests.PageEfRepositoryTests
{
    [TestFixture]
    public class FindPagesShould
    {
        [Ignore("Automapper")]
        [Test]
        public void ReturnIEnumerableOfTypePage()
        {
            //Arrange
            var mockedDbContext = new Mock<ISotnWikiDbContext>();
            var pages = new List<Page>
            {
                new Page() {Id = Guid.NewGuid(), Title = "page", Content = "cntnt", IsPublished = true},
                new Page() {Id = Guid.NewGuid(), Title = "pagea", Content = "cntnta", IsPublished = true}
            };
            var mockedPageSet = QueryableDbSetMock.GetQueryableMockDbSet<Page>(pages);
            mockedDbContext.Setup(c => c.Set<Page>()).Returns(mockedPageSet);
            mockedDbContext.Setup(c => c.Pages).Returns(mockedPageSet);
            var repositoryUnderTest = new PageEfRepository(mockedDbContext.Object);

            //Act & Assert
            var result = repositoryUnderTest.FindPages("pag");

            //Assert
            Assert.IsInstanceOf<IEnumerable<Page>>(result);
        }

        [Ignore("Automapper")]
        [Test]
        public void ReturnCorrectResult()
        {
            //Arrange
            var mockedDbContext = new Mock<ISotnWikiDbContext>();
            var expectedTitle = "mayhem";
            var pages = new List<Page>
            {
                new Page() {Id = Guid.NewGuid(), Title = expectedTitle, Content = "cntnt", IsPublished = true},
                new Page() {Id = Guid.NewGuid(), Title = "pagea", Content = "cntnta", IsPublished = true}
            };
            var mockedPageSet = QueryableDbSetMock.GetQueryableMockDbSet<Page>(pages);
            mockedDbContext.Setup(c => c.Set<Page>()).Returns(mockedPageSet);
            mockedDbContext.Setup(c => c.Pages).Returns(mockedPageSet);
            var repositoryUnderTest = new PageEfRepository(mockedDbContext.Object);

            //Act & Assert
            var result = repositoryUnderTest.FindPages("mayhem").ToList();

            //Assert
            Assert.AreEqual(expectedTitle, result[0].Title);
        }
    }
}
