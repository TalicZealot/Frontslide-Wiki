using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using System;
using SotnWiki.Data.Common;
using SotnWiki.Models;
using SotnWiki.Data.Common.Contracts;

namespace SotnWiki.DataServices.Tests.ContentSubmissionServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenPageServicetIsNull()
        {
            //Arrange
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object;};
            string expectedExceptionMessage = "IPageService";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => {
                new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageEfRepository.Object, mockedUnitOfWorkFactory, null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPageContentSubmissionRepositoryIsNull()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };
            string expectedExceptionMessage = "IContentSubmissionRepository";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => {
                new ContentSubmissionService(null, mockedPageEfRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);
            });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPageEfRepositoryIsNull()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };
            string expectedExceptionMessage = "IPageEfRepository";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => {
                new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, null, mockedUnitOfWorkFactory, mockedPageService.Object);
            });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullException_WhenUnitOfWorkFactoryIsNull()
        {
            //Arrange
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            string expectedExceptionMessage = "Func";

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => {
                new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageEfRepository.Object, null, mockedPageService.Object);
            });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void ReturnsAnInstance_WhenParametersAreNotNull()
        {
            //Arrange
            var mockedPageEfRepository = new Mock<IPageEfRepository>();
            var mockedPageService = new Mock<IPageService>();
            var mockedPageContentSubmissionRepository = new Mock<IContentSubmissionRepository>();
            Func<IEfUnitOfWork> mockedUnitOfWorkFactory = () => { return new Mock<IEfUnitOfWork>().Object; };

            //Act
            var result = new ContentSubmissionService(mockedPageContentSubmissionRepository.Object, mockedPageEfRepository.Object, mockedUnitOfWorkFactory, mockedPageService.Object);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
