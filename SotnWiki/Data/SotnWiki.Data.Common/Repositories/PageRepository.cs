using Bytes2you.Validation;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.Models;
using System.Collections.Generic;
using System.Linq;

namespace SotnWiki.Data.Common.Repositories
{
    public class PageRepository : EfGenericRepository<Page>, IPageRepository
    {
        public PageRepository(ISotnWikiDbContext context)
            : base(context)
        {
        }

        public Page GetPageByTitle(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            return this.DbSet.Where(x => x.IsPublished && string.Equals(x.Title.ToLower(), title.ToLower())).FirstOrDefault();
        }

        public Page GetSubmissionByTitle(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();
            
            return this.DbSet.Where(x => !x.IsPublished && string.Equals(x.Title.ToLower(), title.ToLower())).FirstOrDefault();
            //TODO topmapper projection
        }

        public IEnumerable<Page> GetSubmissions()
        {
            return this.DbSet.Where(x => !x.IsPublished).ToList();
            //TODO topmapper projection
        }

        public IEnumerable<Page> FindPages(string text)
        {
            return this.DbSet.Where(x => x.IsPublished && x.Title.IndexOf(text) >= 0
                ||
                x.IsPublished && x.Content.IndexOf(text) >= 0).ToList();
            //TODO Autopmapper projection
        }
    }
}
