using Bytes2you.Validation;
using SotnWiki.Data.Common;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SotnWiki.DataServices
{
    public class PageService : IPageService
    {
        private readonly IPageRepository pageRepository;
        private readonly ICharacterRepository characterRepository;
        private readonly Func<IUnitOfWork> unitOfWorkFactory;

        public PageService(IPageRepository pageRepository, ICharacterRepository characterRepository, Func<IUnitOfWork> unitOfWorkFactory)
        {
            Guard.WhenArgument(characterRepository, nameof(ICharacterRepository)).IsNull().Throw();
            Guard.WhenArgument(pageRepository, nameof(IPageRepository)).IsNull().Throw();
            Guard.WhenArgument(unitOfWorkFactory, nameof(Func<IUnitOfWork>)).IsNull().Throw();

            this.pageRepository = pageRepository;
            this.characterRepository = characterRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public Page GetPageByTitle(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            return this.pageRepository.GetPageByTitle(title);
        }

        public Page GetSubmissionByTitle(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            return this.pageRepository.GetSubmissionByTitle(title);
        }

        public void CreatePage(int characterId, string type, string title, string content, bool publish)
        {
            Guard.WhenArgument(characterId, "characterId").IsLessThan(1).Throw();
            Guard.WhenArgument(characterId, "characterId").IsGreaterThan(4).Throw();
            Guard.WhenArgument(type, "type").IsNullOrEmpty().Throw();
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();
            Guard.WhenArgument(content, "content").IsNullOrEmpty().Throw();

            var character = this.characterRepository.GetById(characterId);
            if (character == null)
            {
                throw new NullReferenceException("Character not found!");
            }

            var pageToCreate = new Page()
            {
                Title = title,
                Content = content,
                IsPublished = publish
            };

            if (type == "General")
            {
                pageToCreate.GeneralCharacter = character;
            }
            else if (type == "Category")
            {
                pageToCreate.CategoryCharacter = character;
            }
            else if (type == "Glitch")
            {
                pageToCreate.GlitchCharacter = character;
            }

            using (var unitOfWork = this.unitOfWorkFactory())
            {
                this.pageRepository.Add(pageToCreate);
                unitOfWork.Commit();
            }
        }

        public void PublishPage(string editedContent, string title)
        {
            Guard.WhenArgument(editedContent, "editedContent").IsNullOrEmpty().Throw();
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            var page = this.GetSubmissionByTitle(title);
            if (page == null)
            {
                throw new NullReferenceException("Page not found!");
            }

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
            if (page == null)
            {
                throw new NullReferenceException("Page not found!");
            }

            using (var unitOfWork = this.unitOfWorkFactory())
            {
                this.pageRepository.Delete(page);
                unitOfWork.Commit();
            }
        }

        public IEnumerable<Page> GetSubmissions()
        {
            return this.pageRepository.GetSubmissions();
        }

        public IEnumerable<Page> FindPages(string text)
        {
            Guard.WhenArgument(text, "text").IsNullOrEmpty().Throw();

            Page exactTitleMatch = this.pageRepository.GetPageByTitle(text);

            if (exactTitleMatch != null)
            {
                return new List<Page>() { exactTitleMatch };
            }

            return this.pageRepository.FindPages(text);
        }
    }
}
