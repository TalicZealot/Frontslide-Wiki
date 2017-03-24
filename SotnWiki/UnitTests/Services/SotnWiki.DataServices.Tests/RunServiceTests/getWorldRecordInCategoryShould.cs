using SotnWiki.Models;
using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.DTOs.RunViewsDTOs;

namespace SotnWiki.DataServices.Tests.RunServiceTests
{
    [TestFixture]
    public class GetWorldRecordInCategoryShould
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
                    serviceUnderTest.GetWorldRecordInCategory(null);
                });

                //Assert
                StringAssert.Contains(expectedExceptionMessage, exc.Message);
            }

            [Test]
            public void ThrowArgumentNullException_WhenPassedCategoryNameIsEmpty()
            {
                //Arrange
                var mockedRunRepository = new Mock<IRunRepository>();
                Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };
                var serviceUnderTest = new RunService(mockedRunRepository.Object, mockedUnitOfWorkFactory);
                string expectedExceptionMessage = "categoryName";

                //Act
                var exc = Assert.Throws<ArgumentException>(() => {
                    serviceUnderTest.GetWorldRecordInCategory("");
                });

                //Assert
                StringAssert.Contains(expectedExceptionMessage, exc.Message);
            }

            [Test]
            public void ReturnResultOfTypeLeaderboardRunDTO()
            {
                //Arrange
                var mockedRunRepository = new Mock<IRunRepository>();
                Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };
                var serviceUnderTest = new RunService(mockedRunRepository.Object, mockedUnitOfWorkFactory);
                var run = new LeaderboardRunDTO()
                {
                    Time = "1:00"
                };
                mockedRunRepository.Setup(r => r.GetWorldRecordInCategory(It.IsAny<string>())).Returns(run);

                //Act
                var result = serviceUnderTest.GetWorldRecordInCategory("5yhr5u");

                //Assert
                Assert.IsInstanceOf<LeaderboardRunDTO>(result);
            }
        }
    }
}
