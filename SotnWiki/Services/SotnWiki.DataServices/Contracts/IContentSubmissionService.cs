using SotnWiki.DTOs.EditViewsDTOs;
using System;
using System.Collections.Generic;

namespace SotnWiki.DataServices.Contracts
{
    public interface IContentSubmissionService
    {
        void SubmitEdit(string content, string title);

        IEnumerable<EditsViewDTO> GetEdits(string title);

        EditsViewDTO GetPageContentSubmissionById(Guid id);

        void PublishEdit(Guid pageId, string content, Guid id);

        void SubmitAndPublishEdit(string content, string title);

        void DismissEdit(Guid id);
    }
}
