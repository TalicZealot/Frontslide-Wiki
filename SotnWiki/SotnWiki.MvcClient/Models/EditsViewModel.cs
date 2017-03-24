using SotnWiki.DTOs.EditViewsDTOs;
using System.Collections.Generic;

namespace SotnWiki.MvcClient.Models
{
    public class EditsViewModel
    {
        public IEnumerable<EditsViewDTO> Results { get; set; }
    }
}