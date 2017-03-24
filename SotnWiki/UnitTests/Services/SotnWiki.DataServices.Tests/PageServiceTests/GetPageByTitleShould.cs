using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using SotnWiki.Data.Common.Contracts;
using System;

namespace SotnWiki.DataServices.Tests.PageServiceTests
{
    [TestFixture]
    public class GetPageByTitleShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenTitleArgumentIsNull()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "title";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => pageServiceUnderTest.GetPageByTitle(null));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentException_WhenTitleArgumentIsEmpty()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "title";

            //Act
            var exc = Assert.Throws<ArgumentException>(() => pageServiceUnderTest.GetPageByTitle(""));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void CallGetPageByTitleMethodOfPageEfRepository()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);

            //Act
            pageServiceUnderTest.GetPageByTitle("title");

            //Assert
            mockedPageEfRepository.Verify(m => m.GetPageByTitle(It.IsAny<string>()), Times.Once());
        }
    }
}
