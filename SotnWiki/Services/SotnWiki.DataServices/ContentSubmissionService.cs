using Bytes2you.Validation;
using SotnWiki.Data.Common;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.DataServices.Contracts;
using SotnWiki.DTOs.EditViewsDTOs;
using SotnWiki.Models;
using System;
using System.Collections.Generic;

namespace SotnWiki.DataServices
{
    public class ContentSubmissionService : IContentSubmissionService
    {
        private readonly IContentSubmissionRepository pageContentSubmissionRepository;
        private readonly IPageEfRepository PageEfRepository;
        private readonly Func<IEfUnitOfWork> unitOfWorkFactory;
        private readonly IPageService pageService;

        public ContentSubmissionService(IContentSubmissionRepository pageContentSubmissionRepository, IPageEfRepository PageEfRepository, Func<IEfUnitOfWork> unitOfWorkFactory, IPageService pageService)
        {
            Guard.WhenArgument(pageService, nameof(IPageService)).IsNull().Throw();
            Guard.WhenArgument(pageContentSubmissionRepository, nameof(IContentSubmissionRepository)).IsNull().Throw();
            Guard.WhenArgument(PageEfRepository, nameof(IPageEfRepository)).IsNull().Throw();
            Guard.WhenArgument(unitOfWorkFactory, nameof(Func<IEfUnitOfWork>)).IsNull().Throw();

            this.pageService = pageService;
            this.pageContentSubmissionRepository = pageContentSubmissionRepository;
            this.PageEfRepository = PageEfRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void SubmitEdit(string content, string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();
            Guard.WhenArgument(content, "content").IsNullOrEmpty().Throw();

            var page = this.PageEfRepository.GetPageEntityByTitle(title);
            if (page == null)
            {
                throw new NullReferenceException("Page not found!");
            }

            var submission = new PageContentSubmission() { Content = content, PageEdit = page };

            using (var unitOfWork = this.unitOfWorkFactory())
            {
                this.pageContentSubmissionRepository.Add(submission);
                unitOfWork.Commit();
            }
        }

        public void PublishEdit(Guid pageId, string content, Guid id)
        {
            Guard.WhenArgument(content, "content").IsNullOrEmpty().Throw();

            var pageContentSubmission = this.pageContentSubmissionRepository.GetById(id);
            pageContentSubmission.PageHistory = pageContentSubmission.PageEdit;
            pageContentSubmission.PageEdit = null;
            var page = this.PageEfRepository.GetById(pageId);
            pageContentSubmission.Content = page.Content;
            page.Content = content;
            page.LastEdit = DateTime.Now;

            using (var unitOfWork = this.unitOfWorkFactory())
            {
                this.PageEfRepository.Update(page);
                this.pageContentSubmissionRepository.Update(pageContentSubmission);
                unitOfWork.Commit();
            }
        }

        public void SubmitAndPublishEdit(string content, string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();
            Guard.WhenArgument(content, "content").IsNullOrEmpty().Throw();


            var page = this.PageEfRepository.GetPageEntityByTitle(title);
            if (page == null)
            {
                throw new NullReferenceException("Page not found!");
            }

            var submission = new PageContentSubmission() { Content = content, PageHistory = page };
            submission.Content = page.Content;
            page.Content = content;
            page.LastEdit = DateTime.Now;
            

            using (var unitOfWork = this.unitOfWorkFactory())
            {
                this.pageContentSubmissionRepository.Add(submission);
                unitOfWork.Commit();
            }
        }

        public void DismissEdit(Guid id)
        {
            var pageContentSubmission = this.pageContentSubmissionRepository.GetById(id);

            using (var unitOfWork = this.unitOfWorkFactory())
            {
                this.pageContentSubmissionRepository.Delete(pageContentSubmission);
                unitOfWork.Commit();
            }
        }

        public EditsViewDTO GetPageContentSubmissionById(Guid id)
        {
            return this.pageContentSubmissionRepository.GetByIdProjected(id);
        }

        public IEnumerable<EditsViewDTO> GetEdits(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            return this.pageContentSubmissionRepository.GetEdits(title);
        }
    }
}
