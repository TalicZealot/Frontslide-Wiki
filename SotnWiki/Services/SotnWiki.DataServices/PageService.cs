using Bytes2you.Validation;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.DataServices.Contracts;
using SotnWiki.DTOs.PageViewsDTOs;
using SotnWiki.Models;
using System;
using System.Collections.Generic;

namespace SotnWiki.DataServices
{
    public class PageService : IPageService
    {
        private readonly IPageEfRepository PageEfRepository;
        private readonly ICharacterRepository characterRepository;
        private readonly Func<IEfUnitOfWork> unitOfWorkFactory;

        public PageService(IPageEfRepository PageEfRepository, ICharacterRepository characterRepository, Func<IEfUnitOfWork> unitOfWorkFactory)
        {
            Guard.WhenArgument(characterRepository, nameof(ICharacterRepository)).IsNull().Throw();
            Guard.WhenArgument(PageEfRepository, nameof(IPageEfRepository)).IsNull().Throw();
            Guard.WhenArgument(unitOfWorkFactory, nameof(Func<IEfUnitOfWork>)).IsNull().Throw();

            this.PageEfRepository = PageEfRepository;
            this.characterRepository = characterRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public bool CheckTitleAvailability(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            return this.PageEfRepository.CheckTitleAvailability(title);
        }

        public PageViewDTO GetPageByTitle(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            return this.PageEfRepository.GetPageByTitle(title);
        }

        public PageViewDTO GetSubmissionByTitle(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            return this.PageEfRepository.GetSubmissionByTitle(title);
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
                this.PageEfRepository.Add(pageToCreate);
                unitOfWork.Commit();
            }
        }

        public void PublishPage(string editedContent, string title)
        {
            Guard.WhenArgument(editedContent, "editedContent").IsNullOrEmpty().Throw();
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            var page = this.PageEfRepository.GetSubmissionEntityByTitle(title);
            if (page == null)
            {
                throw new NullReferenceException("Page not found!");
            }

            page.Content = editedContent;
            page.IsPublished = true;
            using (var unitOfWork = this.unitOfWorkFactory())
            {
                this.PageEfRepository.Update(page);
                unitOfWork.Commit();
            }
        }

        public void DismissSubmission(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            var page = this.PageEfRepository.GetSubmissionEntityByTitle(title);
            if (page == null)
            {
                throw new NullReferenceException("Page not found!");
            }

            using (var unitOfWork = this.unitOfWorkFactory())
            {
                this.PageEfRepository.Delete(page);
                unitOfWork.Commit();
            }
        }

        public IEnumerable<SubmissionsDTO> GetSubmissions()
        {
            return this.PageEfRepository.GetSubmissions();
        }

        public IEnumerable<PageSearchDTO> FindPages(string text)
        {
            Guard.WhenArgument(text, "text").IsNullOrEmpty().Throw();

            PageViewDTO exactTitleMatch = this.PageEfRepository.GetPageByTitle(text);

            if (exactTitleMatch != null)
            {
                return new List<PageSearchDTO>() { new PageSearchDTO()
                { Title = exactTitleMatch.Title, Content = exactTitleMatch.Content,
                    CreatedOn = exactTitleMatch.CreatedOn, LastEdit = exactTitleMatch.LastEdit,
                    Type = exactTitleMatch.Type } };
            }

            return this.PageEfRepository.FindPages(text);
        }
    }
}
