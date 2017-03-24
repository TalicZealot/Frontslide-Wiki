using SotnWiki.DTOs.PageViewsDTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SotnWiki.MvcClient.Models
{
    public class SearchViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 4)]
        [RegularExpression("^[a-zA-Z0-9_ %-]*$", ErrorMessage = "phrase can only contain letters, spaces and %")]
        public string searchPhrase { get; set; }

        public IEnumerable<PageSearchDTO> Results { get; set; }
    }
}