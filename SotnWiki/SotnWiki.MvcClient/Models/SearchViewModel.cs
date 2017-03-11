using SotnWiki.Models;
using System.Collections.Generic;

namespace SotnWiki.MvcClient.Models
{
    public class SearchViewModel
    {
        public string searchPhrase { get; set; }
        public List<Page> Results { get; set; }
    }
}