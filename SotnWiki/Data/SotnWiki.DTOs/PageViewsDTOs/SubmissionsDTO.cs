using System;

namespace SotnWiki.DTOs.PageViewsDTOs
{
    public class SubmissionsDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Type { get; set; }
    }
}
