using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using SotnWiki.Data.Common.Contracts;
using System;

namespace SotnWiki.DataServices.Tests.PageServiceTests
{
    [TestFixture]
    public class CheckTitleAvailabilityShould
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
            var exc = Assert.Throws<ArgumentNullException>(() => pageServiceUnderTest.CheckTitleAvailability(null));

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
            var exc = Assert.Throws<ArgumentException>(() => pageServiceUnderTest.CheckTitleAvailability(""));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void CallCheckTitleAvailabilityMethodOfPageEfRepository()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);

            //Act
            var result = pageServiceUnderTest.CheckTitleAvailability("asasd");

            //Assert
            mockedPageEfRepository.Verify(m => m.CheckTitleAvailability(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void ReturnsResultOfTypeBool()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);

            //Act
            var result = pageServiceUnderTest.CheckTitleAvailability("asasd");

            //Assert
            Assert.IsInstanceOf<Boolean>(result);
        }

        [Test]
        public void ReturnsCorrectValue()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            mockedPageEfRepository.Setup(r => r.CheckTitleAvailability(It.IsAny<string>())).Returns(true);

            //Act
            var result = pageServiceUnderTest.CheckTitleAvailability("asasd");

            //Assert
            Assert.AreEqual(true, result);
        }
    }
}
