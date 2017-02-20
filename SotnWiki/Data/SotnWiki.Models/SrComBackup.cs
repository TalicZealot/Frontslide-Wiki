using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SotnWiki.Models
{
    public class SrComBackup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4)]
        public string CategoryName { get; set; }

        [Required]
        public string Runs { get; set; }
    }
}
