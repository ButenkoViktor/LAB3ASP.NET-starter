using System.ComponentModel.DataAnnotations;

namespace lab3.Models
{
    public class CreateBlogArticleModel
    {
        [Required]
        [RegularExpression("^[a-z0-9-]+$")]
        [StringLength(64)]
        public string Id { get; set; } = string.Empty;

        [Required]
        [StringLength(120)]
        public string Title { get; set; } = string.Empty;

        [StringLength(240)]
        public string? Description { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;
    }
}
