using System.Linq;

namespace SotnWiki.Mvp.Search
{
    public class SearchViewModel
    {
        public IQueryable<SotnWiki.Models.Page> Results { get; set; }
    }
}
