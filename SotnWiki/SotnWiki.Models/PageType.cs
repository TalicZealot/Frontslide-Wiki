using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SotnWiki.Models
{
    public class PageType
    {
        private ICollection<Page> pages;

        public PageType()
        {
            this.pages = new HashSet<Page>();
        }

        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        public virtual ICollection<Page> Pages
        {
            get { return this.pages; }
            set { this.pages = value; }
        }
    }
}
