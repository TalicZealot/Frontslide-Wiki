using SotnWiki.Models;
using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using System;

namespace SotnWiki.DataServices.Tests.RunServiceTests
{
    [TestFixture]
    public class GetRunsInCategoryShould
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
                    serviceUnderTest.GetRunsInCategory(null);
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
                    serviceUnderTest.GetRunsInCategory("");
                });

                //Assert
                StringAssert.Contains(expectedExceptionMessage, exc.Message);
            }
        }
    }
}
