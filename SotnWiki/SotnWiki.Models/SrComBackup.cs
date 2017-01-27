using System.ComponentModel.DataAnnotations;

namespace SotnWiki.Models
{
    public class SrComBackup
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        public string CategoryName { get; set; }

        [Required]
        public string Runs { get; set; }
    }
}
