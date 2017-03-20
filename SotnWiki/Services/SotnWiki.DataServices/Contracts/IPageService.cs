using SotnWiki.DTOs.PageViewsDTOs;
using System.Collections.Generic;

namespace SotnWiki.DataServices.Contracts
{
    public interface IPageService
    {
        bool CheckTitleAvailability(string title);

        PageViewDTO GetPageByTitle(string title);

        void CreatePage(int characterId, string type, string title, string content, bool publish);

        IEnumerable<PageSearchDTO> FindPages(string text);

        IEnumerable<SubmissionsDTO> GetSubmissions();

        void PublishPage(string editedContent, string title);

        PageViewDTO GetSubmissionByTitle(string title);

        void DismissSubmission(string title);
    }
}
