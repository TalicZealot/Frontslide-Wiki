using System;

namespace SotnWiki.DTOs.PageViewsDTOs
{
    public class PageSearchDTO
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? LastEdit { get; set; }

        public string Type { get; set; }
    }
}
