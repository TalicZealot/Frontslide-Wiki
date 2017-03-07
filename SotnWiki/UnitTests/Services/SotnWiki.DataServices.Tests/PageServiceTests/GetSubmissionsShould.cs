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
            Expression<Func<Page, bool>> filter = (Page model) => !model.IsPublished;
            Expression<Func<Page, Type>> select = (Page model) => model.GetType();

            //Act
            pageServiceUnderTest.GetSubmissions();

            //Assert
            mockedPageRepository.Verify(m => m.GetAll(filter, select), Times.Once());
        }
    }
}
