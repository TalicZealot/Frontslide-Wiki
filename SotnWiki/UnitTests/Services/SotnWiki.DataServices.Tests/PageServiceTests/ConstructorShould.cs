using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
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
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IUnitOfWork>().Object; };
            string expectedExceptionMessage = "IRepository";
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
            var mockedPageRepository = new Mock<IRepository<Page>>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IUnitOfWork>().Object; };
            string expectedExceptionMessage = "IRepository";
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
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedPageRepository = new Mock<IRepository<Page>>();
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
