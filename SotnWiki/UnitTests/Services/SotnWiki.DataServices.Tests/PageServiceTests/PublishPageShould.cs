using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.Models;
using System;

namespace SotnWiki.DataServices.Tests.PageServiceTests
{
    [TestFixture]
    public class PublishPageShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenEditedContentArgumentIsNull()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "editedContent";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => pageServiceUnderTest.PublishPage(null, "aa"));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentException_WhenEditedContentArgumentIsEmpty()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedExceptionMessage = "editedContent";

            //Act
            var exc = Assert.Throws<ArgumentException>(() => pageServiceUnderTest.PublishPage("", "aa"));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

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
            var exc = Assert.Throws<ArgumentNullException>(() => pageServiceUnderTest.PublishPage("aa", null));

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
            var exc = Assert.Throws<ArgumentException>(() => pageServiceUnderTest.PublishPage("aa", ""));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowNullReferenceException_WhenPageIsNotFound()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            mockedPageEfRepository.Setup(x => x.GetSubmissionEntityByTitle(It.IsAny<string>())).Returns((Page)null);
            var expectedExceptionMessage = "Page not found!";

            //Act
            var exc = Assert.Throws<NullReferenceException>(() => pageServiceUnderTest.PublishPage("aa", "aa"));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void CallsCommitMethodOfUnitOfWork()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var page = new Page()
            {
                Content = "aa",
                LastEdit = null,
            };
            mockedPageEfRepository.Setup(x => x.GetSubmissionEntityByTitle(It.IsAny<string>())).Returns(page);

            //Act
            pageServiceUnderTest.PublishPage("aa", "aa");

            //Assert
            mockedUnitOfWork.Verify(m => m.Commit(), Times.Once());
        }

        [Test]
        public void CallsUpdateMethodOfPageEfRepository()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var page = new Page()
            {
                Content = "aa",
                LastEdit = null,
            };
            mockedPageEfRepository.Setup(x => x.GetSubmissionEntityByTitle(It.IsAny<string>())).Returns(page);

            //Act
            pageServiceUnderTest.PublishPage("aa", "aa");

            //Assert
            mockedPageEfRepository.Verify(m => m.Update(It.IsAny<Page>()), Times.Once());
        }

        [Test]
        public void UpdatePageContent()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageEfRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);
            var expectedContent = "new content";
            var page = new Page()
            {
                Content = expectedContent,
                LastEdit = null,
            };
            mockedPageEfRepository.Setup(x => x.GetSubmissionEntityByTitle(It.IsAny<string>())).Returns(page);

            //Act
            pageServiceUnderTest.PublishPage(expectedContent, "aa");

            //Assert
            Assert.AreEqual(expectedContent, page.Content);
        }
    }
}
