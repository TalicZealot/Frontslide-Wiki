using CvSpeedruns.Models;
using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using System;

namespace SotnWiki.DataServices.Tests.RunServiceTests
{
    [TestFixture]
    public class getRunsInCategoryShould
    {
        [TestFixture]
        public class ConstructorShould
        {
            [Test]
            public void ThrowArgumentNullExceptionWhenRunRepositoryIsNull()
            {
                //Arrange
                var mockedRunRepository = new Mock<IRepository<Run>>();
                Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IUnitOfWork>().Object; };
                var serviceUnderTest = new RunService(mockedRunRepository.Object, mockedUnitOfWorkFactory);
                string expectedExceptionMessage = "categoryName";

                //Act
                var exc = Assert.Throws<ArgumentNullException>(() => {
                    serviceUnderTest.getRunsInCategory(null);
                });

                //Assert
                StringAssert.Contains(expectedExceptionMessage, exc.Message);
            }
        }
    }
}
