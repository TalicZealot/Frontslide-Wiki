using System;
using System.ComponentModel.DataAnnotations;

namespace SotnWiki.MvcClient.Models
{
    public class EditViewModel
    {
        public string Title { get; set; }

        public Guid Id { get; set; }

        [Required]
        [StringLength(35000, MinimumLength = 300, ErrorMessage = "Invalid content length.")]
        public string Content { get; set; }

        public bool Publish { get; set; }

        public Guid PageId { get; set; }
    }
}