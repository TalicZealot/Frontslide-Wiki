using SotnWiki.DTOs.EditViewsDTOs;
using SotnWiki.Models;
using System.Collections.Generic;

namespace SotnWiki.Data.Common.Contracts
{
    public interface IContentSubmissionRepository
    {
        IEnumerable<EditsViewDTO> GetEdits(string title);

        EditsViewDTO GetByIdProjected(object id);

        void Add(PageContentSubmission entity);

        void Delete(PageContentSubmission entity);

        void Update(PageContentSubmission entity);

        PageContentSubmission GetById(object id);
    }
}
