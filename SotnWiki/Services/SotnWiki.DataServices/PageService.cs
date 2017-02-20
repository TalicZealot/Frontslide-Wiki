using SotnWiki.Data.Common;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SotnWiki.DataServices
{
    public class PageService : IPageService
    {
        private readonly IRepository<Page> pageRepository;
        private readonly IRepository<Character> characterRepository;
        private readonly Func<IUnitOfWork> unitOfWorkFactory;

        public PageService(IRepository<Page> pageRepository, IRepository<Character> characterRepository, Func<IUnitOfWork> unitOfWorkFactory)
        {
            this.pageRepository = pageRepository;
            this.characterRepository = characterRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public Page GetPageByTitle(string name)
        {
            return this.pageRepository.GetAll().Where(x => string.Equals(x.Title, name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public Page GetPageById(Guid id)
        {
            return this.pageRepository.GetById(id);
        }

        public void CreatePage(string characterName, string type, string title, string content, bool publish)
        {
            var character = this.characterRepository.GetAll().Where(x => x.Name == characterName).FirstOrDefault();

            using (var unitOfWork = this.unitOfWorkFactory())
            {
                if (type == "General")
                {
                    this.pageRepository.Add(
                    new Page() {
                        Title = title,
                        GeneralCharacter = character,
                        Content = content,
                        IsPublished = publish
                    });
                }
                else if (type == "Category")
                {
                    this.pageRepository.Add(
                    new Page()
                    {
                        Title = title,
                        CategoryCharacter = character,
                        Content = content,
                        IsPublished = publish
                    });
                }
                else if (type == "Glitch")
                {
                    this.pageRepository.Add(
                    new Page()
                    {
                        Title = title,
                        GlitchCharacter = character,
                        Content = content,
                        IsPublished = publish
                    });
                }
                unitOfWork.Commit();
            }
        }

        public IEnumerable<Page> FindPages(string text)
        {
            IEnumerable<Page> exactTitleMatch = this.pageRepository.GetAll().Where(x => string.Equals(x.Title, text, StringComparison.OrdinalIgnoreCase)).ToList();

            if (exactTitleMatch.Count() > 0)
            {
                return exactTitleMatch;
            }

            return this.pageRepository.GetAll().Where(
                x => x.Title.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0
                ||
                x.Content.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0
            ).ToList();
        }
    }
}
