using SotnWiki.Models;
using System;
using System.Collections.Generic;

namespace SotnWiki.DataServices.Contracts
{
    public interface IContentSubmissionService
    {
        void SubmitEdit(string content, string title);

        IEnumerable<PageContentSubmission> GetSubmissions(string title);

        PageContentSubmission GetPageContentSubmissionById(Guid id);

        void PublishEdit(string title, string content, Guid id);

        void DismissEdit(Guid id);
    }
}
