using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SotnWiki.Models
{
    public class Page
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Title { get; set; }

        [Required]
        [MinLength(4)]
        public string Character { get; set; }

        [Required]
        [MinLength(4)]
        public string Category { get; set; }

        [Required]
        [MinLength(20)]
        public string Description { get; set; }

        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public bool IsPublished { get; set; }
    }
}
