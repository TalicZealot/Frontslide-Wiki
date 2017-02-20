using SotnWiki.Data.Common;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Models;
using System;
using System.Linq;

namespace SotnWiki.DataServices
{
    public class ContentSubmissionService : IContentSubmissionService
    {
        private readonly IRepository<Page> pageRepository;
        private readonly IRepository<PageContentSubmission> pageContentSubmissionRepository;
        private readonly Func<IUnitOfWork> unitOfWorkFactory;

        public ContentSubmissionService(IRepository<Page> pageRepository, IRepository<PageContentSubmission> pageContentSubmissionRepository, Func<IUnitOfWork> unitOfWorkFactory)
        {
            this.pageRepository = pageRepository;
            this.pageContentSubmissionRepository = pageContentSubmissionRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void SubmitEdit(string content, string title)
        {
            var page = this.pageRepository.GetAll().Where(x => x.Title == title).FirstOrDefault();
            var submission = new PageContentSubmission() { Content = content, PageEdit = page };
            using (var unitOfWork = this.unitOfWorkFactory())
            {
                this.pageContentSubmissionRepository.Add(submission);
                unitOfWork.Commit();
            }
        }
    }
}
