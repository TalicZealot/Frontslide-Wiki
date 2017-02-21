using SotnWiki.Models;
using System;
using System.Collections.Generic;

namespace SotnWiki.DataServices.Contracts
{
    public interface IPageService
    {
        Page GetPageByTitle(string title);

        Page GetPageById(Guid id);

        void CreatePage(string characterName, string type, string title, string content, bool publish);

        IEnumerable<Page> FindPages(string text);

        IEnumerable<Page> GetSubmissions();

        void PublishPage(string editedContent, string title);

        Page GetSubmissionByTitle(string title);

        void DismissSubmission(string title);
    }
}
