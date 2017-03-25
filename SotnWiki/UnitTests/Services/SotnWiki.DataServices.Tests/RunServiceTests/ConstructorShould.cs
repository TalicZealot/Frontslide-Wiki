using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common.Contracts;
using System;

namespace SotnWiki.DataServices.Tests.RunServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenRunRepositoryIsNull()
        {
            //Arrange
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };
            string expectedExceptionMessage = "IRunRepository";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => {
                new RunService(null, mockedUnitOfWorkFactory);
            });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullException_WhenUnitOfWorkFactIsNull()
        {
            //Arrange
            var mockedRunEfRepository = new Mock<IRunRepository>();
            string expectedExceptionMessage = "EfUnitOfWork";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => {
                new RunService(mockedRunEfRepository.Object, null);
            });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ReturnsAnInstance_WhenParametersAreNotNull()
        {
            //Arrange
            var mockedRunEfRepository = new Mock<IRunRepository>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };

            //Act
            var result = new RunService(mockedRunEfRepository.Object, mockedUnitOfWorkFactory);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
