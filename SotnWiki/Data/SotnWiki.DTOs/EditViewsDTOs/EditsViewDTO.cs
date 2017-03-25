using System;

namespace SotnWiki.DTOs.EditViewsDTOs
{
    public class EditsViewDTO
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public Guid PageId { get; set; }
    }
}
