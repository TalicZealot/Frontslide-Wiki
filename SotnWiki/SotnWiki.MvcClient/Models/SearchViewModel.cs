using SotnWiki.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SotnWiki.MvcClient.Models
{
    public class SearchViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 4)]
        public string searchPhrase { get; set; }

        public List<Page> Results { get; set; }
    }
}