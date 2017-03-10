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
        public void ThrowArgumentNullExceptionWhenPageRepositoryIsNull()
        {
            //Arrange
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IUnitOfWork>().Object; };
            string expectedExceptionMessage = "IPageRepository";
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
            var mockedPageRepository = new Mock<IPageRepository>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IUnitOfWork>().Object; };
            string expectedExceptionMessage = "ICharacterRepository";
            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => {
                new PageService(mockedPageRepository.Object, null, mockedUnitOfWorkFactory);
            });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenUnitOfWorkFactoryIsNull()
        {
            //Arrange
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedPageRepository = new Mock<IPageRepository>();
            string expectedExceptionMessage = "Func";
            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => {
                new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, null);
            });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
