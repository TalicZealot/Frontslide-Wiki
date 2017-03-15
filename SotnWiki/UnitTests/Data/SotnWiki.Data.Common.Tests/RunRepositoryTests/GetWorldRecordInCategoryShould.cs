using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common.Repositories;
using SotnWiki.Data.Common.Tests.Mocks;
using SotnWiki.Models;
using System;
using System.Collections.Generic;

namespace SotnWiki.Data.Common.Tests.RunRepositoryTests
{
    [TestFixture]
    public class GetWorldRecordInCategoryShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenTitleIsNull()
        {
            //Arrange
            var mockedDbContext = new Mock<ISotnWikiDbContext>();
            string expectedExceptionMessage = "categoryName";
            var runs = new List<Run>
            {
                new Run() {Id = Guid.NewGuid(), Runner="asd", Time = "11"},
                new Run() {Id = Guid.NewGuid(), Runner="kl", Time = "22"}
            };
            var mockedRunSet = QueryableDbSetMock.GetQueryableMockDbSet<Run>(runs);
            mockedDbContext.Setup(c => c.Set<Run>()).Returns(mockedRunSet);
            mockedDbContext.Setup(c => c.Runs).Returns(mockedRunSet);
            var repositoryUnderTest = new RunRepository(mockedDbContext.Object);

            //Act & Assert
            var exc = Assert.Throws<ArgumentNullException>(() => { repositoryUnderTest.GetWorldRecordInCategory(null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenTitleIsEmptyString()
        {
            //Arrange
            var mockedDbContext = new Mock<ISotnWikiDbContext>();
            string expectedExceptionMessage = "categoryName";
            var runs = new List<Run>
            {
                new Run() {Id = Guid.NewGuid(), Runner="asd", Time = "11"},
                new Run() {Id = Guid.NewGuid(), Runner="kl", Time = "22"}
            };
            var mockedRunSet = QueryableDbSetMock.GetQueryableMockDbSet<Run>(runs);
            mockedDbContext.Setup(c => c.Set<Run>()).Returns(mockedRunSet);
            mockedDbContext.Setup(c => c.Runs).Returns(mockedRunSet);
            var repositoryUnderTest = new RunRepository(mockedDbContext.Object);

            //Act & Assert
            var exc = Assert.Throws<ArgumentException>(() => { repositoryUnderTest.GetWorldRecordInCategory(""); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ReturnObjectOfTypeRun()
        {
            //Arrange
            var mockedDbContext = new Mock<ISotnWikiDbContext>();
            var runs = new List<Run>
            {
                new Run() {Id = Guid.NewGuid(), Runner="asd", Time = "11", Category=Category.AlucardACE},
                new Run() {Id = Guid.NewGuid(), Runner="kl", Time = "22", Category=Category.AlucardACE}
            };
            var mockedRunSet = QueryableDbSetMock.GetQueryableMockDbSet<Run>(runs);
            mockedDbContext.Setup(c => c.Set<Run>()).Returns(mockedRunSet);
            mockedDbContext.Setup(c => c.Runs).Returns(mockedRunSet);
            var repositoryUnderTest = new RunRepository(mockedDbContext.Object);

            //Act & Assert
            var result = repositoryUnderTest.GetWorldRecordInCategory("AlucardACE");

            //Assert
            Assert.IsInstanceOf<Run>(result);
        }
    }
}
