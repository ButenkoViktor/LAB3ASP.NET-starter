using System.ComponentModel.DataAnnotations;

namespace lab3.Models
{
    public class CreateBlogCommentModel
    {
        [Required]
        public string ArticleId { get; set; } = string.Empty;

        [Required]
        [StringLength(64)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Content { get; set; } = string.Empty;
    }
}
