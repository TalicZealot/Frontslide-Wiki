using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
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
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IUnitOfWork>().Object; };
            string expectedExceptionMessage = "IRepository";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => {
                new RunService(null, mockedUnitOfWorkFactory);
            });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
