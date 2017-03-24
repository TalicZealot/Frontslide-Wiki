using Moq;
using NUnit.Framework;
using SotnWiki.Data.Repositories;
using SotnWiki.Data.Common.Tests.Mocks;
using SotnWiki.Models;
using System;
using System.Collections.Generic;

namespace SotnWiki.Data.Common.Tests.ContentSubmissionRepositoryTests
{
    [TestFixture]
    public class GetByIdProjectedShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenIdIsNull()
        {
            //Arrange
            var mockedDbContext = new Mock<ISotnWikiDbContext>();
            string expectedExceptionMessage = "id";
            var submissions = new List<PageContentSubmission>
            {
                new PageContentSubmission() { Id = Guid.NewGuid(), Content = "asdasd" },
                new PageContentSubmission() { Id = Guid.NewGuid(), Content = "asdasd" }
            };
            var mockedSet = QueryableDbSetMock.GetQueryableMockDbSet<PageContentSubmission>(submissions);
            mockedDbContext.Setup(c => c.Set<PageContentSubmission>()).Returns(mockedSet);
            mockedDbContext.Setup(c => c.PageContentSubmissions).Returns(mockedSet);
            var repositoryUnderTest = new ContentSubmissionEfRepository(mockedDbContext.Object);

            //Act & Assert
            var exc = Assert.Throws<ArgumentNullException>(() => { repositoryUnderTest.GetByIdProjected(null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
