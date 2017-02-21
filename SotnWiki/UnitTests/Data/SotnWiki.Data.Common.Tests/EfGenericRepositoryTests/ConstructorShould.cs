using Moq;
using NUnit.Framework;
using SotnWiki.Models;
using System;
using System.Data.Entity;

namespace SotnWiki.Data.Common.Tests.EfGenericRepositoryTests
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
            var exc = Assert.Throws<ArgumentNullException>(() => { new EfGenericRepository<Page>(null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentExceptionWhenContextDbSetIsNull()
        {
            //Arrange
            var mockedDbContext = new Mock<ISotnWikiDbContext>();
            mockedDbContext.Setup(c => c.Pages).Returns<IDbSet<Page>>(null);
            string expectedExceptionMessage = "DbContext does not contain DbSet";

            //Act & Assert
            var exc = Assert.Throws<ArgumentException>(() => { new EfGenericRepository<Page>(mockedDbContext.Object); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
