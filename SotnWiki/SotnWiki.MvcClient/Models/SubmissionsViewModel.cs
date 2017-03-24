using SotnWiki.DTOs.PageViewsDTOs;
using System.Collections.Generic;

namespace SotnWiki.MvcClient.Models
{
    public class SubmissionsViewModel
    {
        public IEnumerable<SubmissionsDTO> Results { get; set; }
    }
}