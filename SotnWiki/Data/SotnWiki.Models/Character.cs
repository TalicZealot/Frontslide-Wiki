using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(4)]
        [MaxLength(10)]
        public string Name { get; set; }

        [InverseProperty("GeneralCharacter")]
        public virtual ICollection<Page> General
        {
            get { return this.general; }
            set { this.general = value; }
        }

        [InverseProperty("CategoryCharacter")]
        public virtual ICollection<Page> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

        [InverseProperty("GlitchCharacter")]
        public virtual ICollection<Page> Glitches
        {
            get { return this.glitches; }
            set { this.glitches = value; }
        }
    }
}
