using AutoMapper;
using Bytes2you.Validation;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.DTOs.EditViewsDTOs;
using SotnWiki.Models;
using System.Collections.Generic;
using System.Linq;

namespace SotnWiki.Data.Repositories
{
    public class ContentSubmissionEfRepository : EfRepository<PageContentSubmission>, IContentSubmissionRepository
    {
        public ContentSubmissionEfRepository(ISotnWikiDbContext context)
            : base(context)
        {
        }

        public IEnumerable<EditsViewDTO> GetEdits(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            return this.DbSet.Where(x => string.Equals(x.PageEdit.Title.ToLower(), title.ToLower())).ProjectToList<EditsViewDTO>();
        }

        public EditsViewDTO GetByIdProjected(object id)
        {
            Guard.WhenArgument(id, "id").IsNull().Throw();

            return Mapper.Map<EditsViewDTO>(this.GetById(id));
        }
    }
}
