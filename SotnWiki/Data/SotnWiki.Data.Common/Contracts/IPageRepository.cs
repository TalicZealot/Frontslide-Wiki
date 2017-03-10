using SotnWiki.Models;
using System.Collections.Generic;

namespace SotnWiki.Data.Common.Contracts
{
    public interface IPageRepository
    {
        Page GetPageByTitle(string title);

        Page GetSubmissionByTitle(string title);

        IEnumerable<Page> GetSubmissions();

        IEnumerable<Page> FindPages(string text);

        void Add(Page entity);

        void Delete(Page entity);

        void Update(Page entity);
    }
}
