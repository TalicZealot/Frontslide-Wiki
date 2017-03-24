using SotnWiki.Models;
using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using System;
using SotnWiki.Data.Common.Contracts;
using System.Collections.Generic;
using SotnWiki.DTOs.RunViewsDTOs;

namespace SotnWiki.DataServices.Tests.RunServiceTests
{
    [TestFixture]
    public class GetRunsInCategoryShould
    {
        [TestFixture]
        public class ConstructorShould
        {
            [Test]
            public void ThrowArgumentNullException_WhenPassedCategoryNameIsNull()
            {
                //Arrange
                var mockedRunRepository = new Mock<IRunRepository>();
                Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };
                var serviceUnderTest = new RunService(mockedRunRepository.Object, mockedUnitOfWorkFactory);
                string expectedExceptionMessage = "categoryName";

                //Act
                var exc = Assert.Throws<ArgumentNullException>(() => {
                    serviceUnderTest.GetRunsInCategory(null);
                });

                //Assert
                StringAssert.Contains(expectedExceptionMessage, exc.Message);
            }

            [Test]
            public void ThrowArgumentNullExceptionWhenPassedCategoryNameIsEmpty()
            {
                //Arrange
                var mockedRunRepository = new Mock<IRunRepository>();
                Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };
                var serviceUnderTest = new RunService(mockedRunRepository.Object, mockedUnitOfWorkFactory);
                string expectedExceptionMessage = "categoryName";

                //Act
                var exc = Assert.Throws<ArgumentException>(() => {
                    serviceUnderTest.GetRunsInCategory("");
                });

                //Assert
                StringAssert.Contains(expectedExceptionMessage, exc.Message);
            }

            [Test]
            public void ReturnCollectionOfTypeLeaderboardRunDTO()
            {
                //Arrange
                var mockedRunRepository = new Mock<IRunRepository>();
                Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };
                var serviceUnderTest = new RunService(mockedRunRepository.Object, mockedUnitOfWorkFactory);

                //Act
                var result = serviceUnderTest.GetRunsInCategory("123asd");

                //Assert
                Assert.IsInstanceOf<IEnumerable<LeaderboardRunDTO>>(result);
            }
        }
    }
}
