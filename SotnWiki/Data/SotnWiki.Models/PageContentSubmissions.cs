using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SotnWiki.Models
{
    public class PageContentSubmission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        public virtual Page PageEdit { get; set; }

        public virtual Page PageHistory { get; set; }
    }
}
