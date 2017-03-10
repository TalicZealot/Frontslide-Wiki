using SotnWiki.Models;
using System.Collections.Generic;

namespace SotnWiki.Data.Common.Contracts
{
    public interface IContentSubmissionRepository
    {
        IEnumerable<PageContentSubmission> GetSubmissions(string title);

        PageContentSubmission GetById(object id);

        void Add(PageContentSubmission entity);

        void Delete(PageContentSubmission entity);

        void Update(PageContentSubmission entity);
    }
}
