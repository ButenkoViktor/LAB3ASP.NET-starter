namespace lab3.Models.Entities
{
    public class BlogComment
    {
        public int Id { get; set; }
        public string ArticleId { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public BlogArticle? Article { get; set; }
    }
}
