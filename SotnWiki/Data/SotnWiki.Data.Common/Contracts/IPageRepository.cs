using SotnWiki.DTOs.PageViewsDTOs;
using SotnWiki.Models;
using System.Collections.Generic;

namespace SotnWiki.Data.Common.Contracts
{
    public interface IPageRepository
    {
        bool CheckTitleAvailability(string title);

        Page GetPageEntityByTitle(string title);

        Page GetSubmissionEntityByTitle(string title);

        PageViewDTO GetPageByTitle(string title);

        PageViewDTO GetSubmissionByTitle(string title);

        IEnumerable<SubmissionsDTO> GetSubmissions();

        IEnumerable<PageSearchDTO> FindPages(string text);

        void Add(Page entity);

        void Delete(Page entity);

        void Update(Page entity);
    }
}
