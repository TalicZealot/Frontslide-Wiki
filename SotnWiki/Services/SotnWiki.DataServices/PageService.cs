using Bytes2you.Validation;
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
            Guard.WhenArgument(characterRepository, nameof(IRepository<Character>)).IsNull().Throw();
            Guard.WhenArgument(pageRepository, nameof(IRepository<Page>)).IsNull().Throw();
            Guard.WhenArgument(unitOfWorkFactory, nameof(Func<IUnitOfWork>)).IsNull().Throw();

            this.pageRepository = pageRepository;
            this.characterRepository = characterRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public Page GetPageByTitle(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            return this.pageRepository.GetAll(x => x.IsPublished && string.Equals(x.Title.ToLower(), title.ToLower())).FirstOrDefault();
        }

        public Page GetSubmissionByTitle(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            return this.pageRepository.GetAll(x => !x.IsPublished && string.Equals(x.Title.ToLower(), title.ToLower())).FirstOrDefault();
        }

        public Page GetPageById(Guid id)
        {
            return this.pageRepository.GetById(id);
        }

        public void CreatePage(string characterName, string type, string title, string content, bool publish)
        {
            Guard.WhenArgument(characterName, "characterName").IsNullOrEmpty().Throw();
            Guard.WhenArgument(type, "type").IsNullOrEmpty().Throw();
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();
            Guard.WhenArgument(content, "content").IsNullOrEmpty().Throw();

            var characterId = this.characterRepository.GetAll(x => string.Equals(x.Name, characterName), y => y.Id).FirstOrDefault();
            var character = this.characterRepository.GetById(characterId);

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

        public void PublishPage(string editedContent, string title)
        {
            Guard.WhenArgument(editedContent, "editedContent").IsNullOrEmpty().Throw();
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            var page = this.GetSubmissionByTitle(title);
            page.Content = editedContent;
            page.IsPublished = true;
            using (var unitOfWork = this.unitOfWorkFactory())
            {
                this.pageRepository.Update(page);
                unitOfWork.Commit();
            }
        }

        public void DismissSubmission(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            var page = this.GetSubmissionByTitle(title);
            using (var unitOfWork = this.unitOfWorkFactory())
            {
                this.pageRepository.Delete(page);
                unitOfWork.Commit();
            }
        }

        public IEnumerable<Page> GetSubmissions()
        {
            var result = this.pageRepository.GetAll(x => !x.IsPublished, y => new { Content = y.Content, CreatedOn = y.CreatedOn, Title = y.Title }).ToList();
            return result.Select(z => new Page { Content = z.Content, CreatedOn = z.CreatedOn, Title = z.Title }).ToList();
        }

        public IEnumerable<Page> FindPages(string text)
        {
            Guard.WhenArgument(text, "text").IsNullOrEmpty().Throw();

            IEnumerable<Page> exactTitleMatch = this.pageRepository.GetAll(x => x.IsPublished && string.Equals(x.Title.ToLower(), text.ToLower()), y => new { Content = y.Content, CreatedOn = y.CreatedOn, Title = y.Title })
                .Select(z => new Page { Content = z.Content, CreatedOn = z.CreatedOn, Title = z.Title }).ToList();

            if (exactTitleMatch.Count() > 0)
            {
                return exactTitleMatch;
            }

            return this.pageRepository.GetAll(
                x => x.IsPublished && x.Title.IndexOf(text) >= 0
                ||
                x.IsPublished && x.Content.IndexOf(text) >= 0
            , y => new { Content = y.Content, CreatedOn = y.CreatedOn, Title = y.Title })
            .Select(z => new Page { Content = z.Content, CreatedOn = z.CreatedOn, Title = z.Title }).ToList();
        }
    }
}
