using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lab3;
using lab3.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace lab3.Pages.Blog
{
    public class TestModel : PageModel
    {
        public BlogArticle? Article { get; set; }

        public async Task OnGetAsync()
        {
            using var db = new BlogContext();

           
            Article = await db.Articles
                .Include(a => a.Comments)
                .FirstOrDefaultAsync();

            if (Article == null)
            {
          
                var article = new BlogArticle
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Przyk³ad",
                    Description = "Opis przyk³adowego posta",
                    Content = "Logowanie do SQL."
                };
                db.Articles.Add(article);
                await db.SaveChangesAsync();

              
                var comments = new[]
                {
                    new BlogComment { ArticleId = article.Id, Author = "Viktor", Content = "Super!", CreatedAt = DateTime.UtcNow },
                    new BlogComment { ArticleId = article.Id, Author = "Maksym", Content = "Super!", CreatedAt = DateTime.UtcNow }
                };
                db.AddRange(comments);
                await db.SaveChangesAsync();

                
                Article = await db.Articles
                    .Include(a => a.Comments)
                    .FirstOrDefaultAsync(a => a.Id == article.Id);
            }
        }
    }
}
