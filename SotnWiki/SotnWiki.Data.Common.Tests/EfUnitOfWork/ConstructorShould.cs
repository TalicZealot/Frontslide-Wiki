using System;
using Telerik.JustMock;
using MSTestExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SotnWiki.Data.Common.Tests.EfUnitOfWork
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenDbContextIsNull()
        {
            //Arrange
            //Act
            //Assert
            ThrowsAssert.Throws<ArgumentNullException>(() => { new SotnWiki.Data.Common.EfUnitOfWork(null); }, "DbContext cannot be null!", ExceptionMessageCompareOptions.Contains, ExceptionInheritanceOptions.Inherits);
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
