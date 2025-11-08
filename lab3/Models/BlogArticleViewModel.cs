namespace lab3.Models
{
    public class BlogArticleViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<BlogCommentViewModel> Comments { get; set; } = [];
    }
}