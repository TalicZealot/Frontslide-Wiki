using System.ComponentModel.DataAnnotations;

namespace SotnWiki.MvcClient.Models
{
    public class NewPageModel
    {
        [Required]
        [EnumDataType(typeof(SotnWiki.Models.CharacterIdEnum))]
        public string Character { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 4)]
        public string Title { get; set; }

        [Required]
        [StringLength(35000, MinimumLength = 300, ErrorMessage = "Invalid content length.")]
        public string Content { get; set; }
    }
}