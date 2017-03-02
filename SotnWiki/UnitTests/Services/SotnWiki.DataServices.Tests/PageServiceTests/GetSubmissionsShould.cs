using Moq;
using NUnit.Framework;
using SotnWiki.Data.Common;
using SotnWiki.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SotnWiki.DataServices.Tests.PageServiceTests
{
    [TestFixture]
    public class GetSubmissionsShould
    {
        [Test]
        [Ignore("TODO: Integration test")]
        public void CallGetAllMethodOfPageRepository()
        {
            //Arrange
            var mockedPageRepository = new Mock<IRepository<Page>>();
            var mockedCharacterRepository = new Mock<IRepository<Character>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Func<IUnitOfWork> mockedUnitOfWorkFactory = () => { return mockedUnitOfWork.Object; };
            var pageServiceUnderTest = new PageService(mockedPageRepository.Object, mockedCharacterRepository.Object, mockedUnitOfWorkFactory);

            //Act
            pageServiceUnderTest.GetSubmissions();

            //Assert
            mockedPageRepository.Verify(m => m.GetAll<Tuple<string, DateTime, string>>(It.IsAny<Expression<Func<Page, bool>>>(), It.IsAny<Expression<Func<Page, Tuple<string, DateTime, string>>>>()), Times.Once());
        }
    }
}
