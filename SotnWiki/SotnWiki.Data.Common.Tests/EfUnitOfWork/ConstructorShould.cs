using System;
using MSTestExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Telerik.JustMock;

namespace SotnWiki.Data.Common.Tests.EfUnitOfWork
{
    public class ConstructorShould
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenDbContextIsNull()
        {
            //Arrange
            //Act
            //Assert
            ThrowsAssert.Throws<ArgumentNullException>(() => { new SotnWiki.Data.Common.EfUnitOfWork(null); }, "DbContext cannot be null!", ExceptionMessageCompareOptions.Exact, ExceptionInheritanceOptions.Inherits);
        }

        [TestMethod]
        public void NotThrow_WhenDbContextIsValid()
        {
            //Arrange
            var mockedContext = Mock.Create<ISotnWikiDbContext>();
            //Act Assert
            try
            {
                var unitOfWork = new SotnWiki.Data.Common.EfUnitOfWork(mockedContext);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }
}
