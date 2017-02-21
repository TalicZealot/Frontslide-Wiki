using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SotnWiki.Models
{
    public class Page
    {
        private ICollection<PageContentSubmission> history;
        private ICollection<PageContentSubmission> pending;

        public Page()
        {
            this.history = new HashSet<PageContentSubmission>();
            this.pending = new HashSet<PageContentSubmission>();
            CreatedOn = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(4)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MinLength(250)]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? LastEdit { get; set; }

        [Required]
        public bool IsPublished { get; set; }

        public virtual Character GeneralCharacter { get; set; }

        public virtual Character CategoryCharacter { get; set; }

        public virtual Character GlitchCharacter { get; set; }

        [InverseProperty("PageHistory")]
        public virtual ICollection<PageContentSubmission> History
        {
            get { return this.history; }
            set { this.history = value; }
        }

        [InverseProperty("PageEdit")]
        public virtual ICollection<PageContentSubmission> Pending
        {
            get { return this.pending; }
            set { this.pending = value; }
        }
    }
}
