﻿using Moq;
using NUnit.Framework;
using SotnWiki.Data.Repositories;
using SotnWiki.Data.Common.Tests.Mocks;
using SotnWiki.Models;
using System;
using System.Collections.Generic;

namespace SotnWiki.Data.Common.Tests.RunRepositoryTests
{
    [TestFixture]
    public class GetRunsInCategoryShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenTitleIsNull()
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
            var repositoryUnderTest = new RunEfRepository(mockedDbContext.Object);

            //Act & Assert
            var exc = Assert.Throws<ArgumentNullException>(() => { repositoryUnderTest.GetRunsInCategory(null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullException_WhenTitleIsEmptyString()
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
            var repositoryUnderTest = new RunEfRepository(mockedDbContext.Object);

            //Act & Assert
            var exc = Assert.Throws<ArgumentException>(() => { repositoryUnderTest.GetRunsInCategory(""); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
