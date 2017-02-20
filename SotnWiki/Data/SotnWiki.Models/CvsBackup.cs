using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SotnWiki.Models
{
    public class CvsBackup
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
