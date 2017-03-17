using System.ComponentModel.DataAnnotations;

namespace SotnWiki.MvcClient.Models
{
    public class EditViewModel
    {
        [Required]
        [StringLength(25, MinimumLength = 4)]
        public string Title { get; set; }

        [Required]
        [StringLength(35000, MinimumLength = 300, ErrorMessage = "Invalid content length.")]
        public string Content { get; set; }

        public bool Publish { get; set; }
    }
}