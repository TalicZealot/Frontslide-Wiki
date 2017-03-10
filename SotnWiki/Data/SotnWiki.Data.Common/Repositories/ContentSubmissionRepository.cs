using Bytes2you.Validation;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.Models;
using System.Collections.Generic;
using System.Linq;

namespace SotnWiki.Data.Common.Repositories
{
    public class ContentSubmissionRepository : EfGenericRepository<PageContentSubmission>, IContentSubmissionRepository
    {
        public ContentSubmissionRepository(ISotnWikiDbContext context)
            : base(context)
        {
        }

        public IEnumerable<PageContentSubmission> GetSubmissions(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            return this.DbSet.Where(x => string.Equals(x.PageEdit.Title.ToLower(), title.ToLower())).ToList();
        }
    }
}
