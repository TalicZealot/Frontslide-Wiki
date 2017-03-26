using Ninject;
using NUnit.Framework;
using SotnWiki.Data;
using SotnWiki.DataServices.Contracts;
using SotnWiki.DTOs.PageViewsDTOs;
using SotnWiki.Models;
using SotnWiki.MvcClient.App_Start;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SotnWiki.DataServices.IntegrationTests.PageServiceTests
{
    [TestFixture]
    public class FindPagesShould
    {
        public class GetSubmissionsShould
        {
            private string defaultPageContent =
    @"h1. This page is empty

There is currently no Alucard content in this page. Use the edit page button to edit and submit new content. Please adhere to the site templates.


This wiki uses TxStyle markup, for reference visit  ""https://txstyle.org/"":https://txstyle.org/.";

            private List<Character> characters = new List<Character>()
            {
                new Character () { Name = "Site", Id = 0},
                new Character () { Name = "Alucard", Id = 1}
            };

            private List<Page> pages = new List<Page>();

            private static IKernel kernel;

            [SetUp]
            public void Init()
            {
                kernel = NinjectWebCommon.CreateKernel();

                ISotnWikiDbContext dbContext = kernel.Get<ISotnWikiDbContext>();

                dbContext.Characters.Add(characters[0]);
                dbContext.Characters.Add(characters[1]);
                dbContext.SaveChanges();

                var siteEntity = dbContext.Characters.Find(0);
                var alucardEntity = dbContext.Characters.Find(1);
                pages = new List<Page>()
            {
                new Page () { Id = Guid.NewGuid(), IsPublished = true, Title = "Main Page", CreatedOn = DateTime.Now, GeneralCharacter = siteEntity , Content = defaultPageContent},
                new Page () { Id = Guid.NewGuid(), IsPublished = true, Title = "Alucard All Bosses", CreatedOn = DateTime.Now, GeneralCharacter = alucardEntity , Content = defaultPageContent}
            };

                dbContext.Pages.Add(pages[0]);
                dbContext.Pages.Add(pages[1]);
                dbContext.SaveChanges();
            }

            [TearDown]
            public void Dispose()
            {
                ISotnWikiDbContext dbContext = kernel.Get<ISotnWikiDbContext>();
                dbContext.Entry(characters[0]).State = EntityState.Detached;
                dbContext.Entry(characters[1]).State = EntityState.Detached;

                dbContext.Entry(pages[0]).State = EntityState.Detached;
                dbContext.Entry(pages[1]).State = EntityState.Detached;
                dbContext.Database.ExecuteSqlCommand("DELETE FROM [Pages]");
                dbContext.Database.ExecuteSqlCommand("DELETE FROM [Characters]");
                dbContext.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Characters',RESEED,0);");
            }

            [Test]
            public void ReturnProjectedCollectionOfPagesToPageSearchDTO()
            {
                //Arrange
                IPageService pageService = kernel.Get<IPageService>();

                //Act
                var result = pageService.FindPages("something");

                //Assert
                Assert.IsInstanceOf<IEnumerable<PageSearchDTO>>(result);
            }

            [Test]
            public void ReturnEmptyCollectionWhenPhraseDoesntMatch()
            {
                //Arrange
                IPageService pageService = kernel.Get<IPageService>();

                //Act
                var result = pageService.FindPages("dedoviq").ToList();

                //Assert
                Assert.AreEqual(0, result.Count);
            }

            [Test]
            public void ReturnCollectionWithOneObjectWhenThereIsAnExactTitleMatch()
            {
                //Arrange
                IPageService pageService = kernel.Get<IPageService>();

                //Act
                var result = pageService.FindPages("Alucard All Bosses").ToList();

                //Assert
                Assert.AreEqual(1, result.Count);
            }
        }
    }
}
