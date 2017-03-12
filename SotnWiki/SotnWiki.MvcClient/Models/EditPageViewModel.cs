using System.ComponentModel.DataAnnotations;

namespace SotnWiki.MvcClient.Models
{
    public class EditPageViewModel
    {
        [Required]
        [StringLength(35000, MinimumLength = 300, ErrorMessage = "Invalid content length.")]
        public string Content { get; set; }
    }
}