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
        public void ThrowArgumentNullExceptionWhenRunRepositoryIsNull()
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
    }
}
