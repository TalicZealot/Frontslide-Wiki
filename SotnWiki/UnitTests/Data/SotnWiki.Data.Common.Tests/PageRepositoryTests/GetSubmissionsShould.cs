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
    public class GetSubmissionsShould
    {
        [Ignore("Automapper")]
        [Test]
        public void ReturnIEnumerableOfTypePage()
        {
            //Arrange
            var mockedDbContext = new Mock<ISotnWikiDbContext>();
            var pages = new List<Page>
            {
                new Page() {Id = Guid.NewGuid(), Title = "page", Content = "cntnt", IsPublished = false},
                new Page() {Id = Guid.NewGuid(), Title = "pagea", Content = "cntnta", IsPublished = false}
            };
            var mockedPageSet = QueryableDbSetMock.GetQueryableMockDbSet<Page>(pages);
            mockedDbContext.Setup(c => c.Set<Page>()).Returns(mockedPageSet);
            mockedDbContext.Setup(c => c.Pages).Returns(mockedPageSet);
            var repositoryUnderTest = new PageEfRepository(mockedDbContext.Object);

            //Act & Assert
            var result = repositoryUnderTest.GetSubmissions();

            //Assert
            Assert.IsInstanceOf<IEnumerable<Page>>(result);
        }
    }
}
