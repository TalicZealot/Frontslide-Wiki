using SotnWiki.Models;
using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SotnWiki.DataServices.Tests.RunServiceTests
{
    [TestFixture]
    public class GetWorldRecordInCategoryShould
    {
        [TestFixture]
        public class ConstructorShould
        {

            [Test]
            public void ThrowArgumentNullExceptionWhenPassedCategoryNameIsNull()
            {
                //Arrange
                var mockedRunRepository = new Mock<IRepository<Run>>();
                Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IUnitOfWork>().Object; };
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
            public void ThrowArgumentNullExceptionWhenPassedCategoryNameIsEmpty()
            {
                //Arrange
                var mockedRunRepository = new Mock<IRepository<Run>>();
                Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IUnitOfWork>().Object; };
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
            [Ignore("TODO: Integration test")]
            public void ReturnTheRunWithTheLowestTime()
            {
                //Arrange
                var mockedRunRepository = new Mock<IRepository<Run>>();
                Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IUnitOfWork>().Object; };
                var serviceUnderTest = new RunService(mockedRunRepository.Object, mockedUnitOfWorkFactory);
                var runs = new[]
                {
                    new {Runner = "runner1", Time = "33:33", Url = "testurl1", Platform = Platform.Playstation},
                    new {Runner = "runner2", Time = "1:11", Url = "testurl2", Platform = Platform.Playstation},
                    new {Runner = "runner3", Time = "22:22", Url = "testurl3", Platform = Platform.Playstation}
                }.ToList();

                mockedRunRepository.Setup(r => r.GetAll(It.IsAny<Expression<Func<Run, bool>>>(), It.IsAny<Expression<Func<Run, Type>>>())).Returns((IEnumerable<Type>)runs);
                var expectedWR = new Run() { Runner = "runner2", Time = "1:11", Url = "testurl2", Platform = Platform.Playstation };

                //Act
                var result = serviceUnderTest.GetWorldRecordInCategory("test");

                //Assert

                Assert.AreEqual(expectedWR, result);
            }
        }
    }
}
