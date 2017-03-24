using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.Models;
using System;

namespace SotnWiki.DataServices.Tests.PageServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenPageEfRepositoryIsNull()
        {
            //Arrange
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };
            string expectedExceptionMessage = "IPageEfRepository";
            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => {
                new PageService(null, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenCharacterRepositoryIsNull()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };
            string expectedExceptionMessage = "ICharacterRepository";
            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => {
                new PageService(mockedPageEfRepository.Object, null, mockedUnitOfWorkFactory);
            });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenUnitOfWorkFactoryIsNull()
        {
            //Arrange
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            string expectedExceptionMessage = "Func";
            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => {
                new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, null);
            });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
