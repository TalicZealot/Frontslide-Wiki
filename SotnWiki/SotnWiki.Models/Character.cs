using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SotnWiki.Models
{
    public class Character
    {
        private ICollection<PageType> pageTypes;

        public Character()
        {
            this.pageTypes = new HashSet<PageType>();
        }

        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        public virtual ICollection<PageType> PageTypes
        {
            get { return this.pageTypes; }
            set { this.pageTypes = value; }
        }
    }
}
