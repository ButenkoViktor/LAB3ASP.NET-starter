using lab3.Models.Entities;

namespace lab3.Models.Mappings
{
    public static class BlogMappings
    {
        public static BlogArticleViewModel ToViewModel(this BlogArticle blogArticle) => new() {
            Id = blogArticle.Id,
            Title = blogArticle.Title,
            Description = blogArticle.Description,
            Content = blogArticle.Content
        };

        public static BlogArticle ToEntity(this CreateBlogArticleModel blogArticle) => new() {
            Id = blogArticle.Id,
            Title = blogArticle.Title,
            Description = blogArticle.Description ?? string.Empty,
            Content = blogArticle.Content
        };
    }
}