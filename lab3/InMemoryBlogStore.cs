using lab3.Models.Entities;

namespace lab3
{
    public static class InMemoryBlogStore
    {
        private static readonly List<BlogArticle> Articles = [
            new() {
                Id = "welcome", Title = "Welcome to My Blog", Description = "Intro post about the blog.",
                Content = "<p>This is the first post welcoming users to the blog demo.</p>"
            },
            new() {
                Id = "aspnet-mvc", Title = "Learning ASP.NET MVC", Description = "Basics of ASP.NET MVC.",
                Content = "<p>In this post we explore controllers, views, and models.</p>"
            },
            new() {
                Id = "routing", Title = "Understanding Routing", Description = "How routing works.",
                Content =
                    "<p>Routing maps URLs to controller actions. You can use attribute routing or conventional routing.</p>"
            }
        ];

        public static IEnumerable<BlogArticle> GetAll() => Articles;

        public static BlogArticle? GetById(string id) =>
            Articles.FirstOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

        public static void Add(BlogArticle article)
        {
            Articles.Add(article);
        }

        public static bool Exists(string id) =>
            Articles.Any(a => a.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
    }
}
