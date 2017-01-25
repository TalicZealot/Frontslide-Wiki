using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SotnWiki.Models
{
    public class Submit
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Title { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        [MinLength(20)]
        public string Description { get; set; }

        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int AuthorId { get; set; }
    }
}
