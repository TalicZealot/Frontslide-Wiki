﻿using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common.Tests.Mocks;
using SotnWiki.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace SotnWiki.Data.Common.Tests.EfGenericRepositoryTests
{
    [TestFixture]
    public class AddShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedEntityIsNull()
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

            var repositoryUnderTest = new EfRepository<Page>(mockedDbContext.Object);

            //Act & Assert
            var exc = Assert.Throws<ArgumentNullException>(() => repositoryUnderTest.Add(null));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void CallSetAddedMethodOfDbContext()
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
            mockedDbContext.Setup(c => c.SetAdded(It.IsAny<object>())).Returns(true);

            var repositoryUnderTest = new EfRepository<Page>(mockedDbContext.Object);

            //Act & Assert
            repositoryUnderTest.Add(pages[0]);

            //Assert
            mockedDbContext.Verify(mc => mc.SetAdded(It.IsAny<object>()), Times.Once());
        }

        [Test]
        public void CallAddMethodOfDbset_WhenSetAddedReturnsFalse()
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
            mockedDbContext.Setup(c => c.SetAdded(It.IsAny<object>())).Returns(false);

            var repositoryUnderTest = new EfRepository<Page>(mockedDbContext.Object);

            //Act & Assert
            var exc = Assert.Throws<ArgumentNullException>(() => repositoryUnderTest.Add(pages[0]));
            StringAssert.Contains("add", exc.Message);
        }
    }
}
