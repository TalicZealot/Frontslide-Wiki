using NUnit.Framework;
using System;

namespace SotnWiki.Data.Common.Tests.EfUnitOfWorkTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenContextIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "ISotnWikiDbContext";

            //Act & Assert
            var exc = Assert.Throws<ArgumentNullException>(() => { new EfUnitOfWork(null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
