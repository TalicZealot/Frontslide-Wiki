using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SotnWiki.Models
{
    public class Character
    {
        private ICollection<Page> general;
        private ICollection<Page> categories;
        private ICollection<Page> glitches;

        public Character()
        {
            this.general = new HashSet<Page>();
            this.categories = new HashSet<Page>();
            this.glitches = new HashSet<Page>();
        }

        public Guid Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        public virtual ICollection<Page> General
        {
            get { return this.general; }
            set { this.general = value; }
        }

        public virtual ICollection<Page> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

        public virtual ICollection<Page> Glitches
        {
            get { return this.glitches; }
            set { this.glitches = value; }
        }
    }
}
