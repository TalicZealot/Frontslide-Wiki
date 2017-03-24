using AutoMapper;
using Bytes2you.Validation;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.DTOs.PageViewsDTOs;
using SotnWiki.Models;
using System.Collections.Generic;
using System.Linq;

namespace SotnWiki.Data.Repositories
{
    public class PageEfRepository : EfRepository<Page>, IPageEfRepository
    {
        public PageEfRepository(ISotnWikiDbContext context)
            : base(context)
        {
        }

        public Page GetPageEntityByTitle(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            return this.DbSet.Where(x => x.IsPublished && string.Equals(x.Title.ToLower(), title.ToLower())).FirstOrDefault();
        }

        public Page GetSubmissionEntityByTitle(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            return this.DbSet.Where(x => !x.IsPublished && string.Equals(x.Title.ToLower(), title.ToLower())).FirstOrDefault();
        }

        public PageViewDTO GetPageByTitle(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            return this.DbSet.Where(x => x.IsPublished && string.Equals(x.Title.ToLower(), title.ToLower())).ProjectToFirstOrDefault<PageViewDTO>();
        }

        public bool CheckTitleAvailability(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            return !this.DbSet.Any(x => string.Equals(x.Title.ToLower(), title.ToLower()));
        }

        public PageViewDTO GetSubmissionByTitle(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            return this.DbSet.Where(x => !x.IsPublished && string.Equals(x.Title.ToLower(), title.ToLower())).ProjectToFirstOrDefault<PageViewDTO>();
        }

        public IEnumerable<SubmissionsDTO> GetSubmissions()
        {
            return this.DbSet.Where(x => !x.IsPublished).ProjectToList<SubmissionsDTO>();
        }

        public IEnumerable<PageSearchDTO> FindPages(string text)
        {
            return this.DbSet.Where(x => x.IsPublished && x.Title.IndexOf(text) >= 0
                ||
                x.IsPublished && x.Content.IndexOf(text) >= 0).ProjectToList<PageSearchDTO>();
        }
    }
}
