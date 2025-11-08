using lab3.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace lab3
{
    public class BlogContext : DbContext
    {
        public DbSet<BlogArticle> Articles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=blog.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogArticle>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<BlogArticle>()
                .HasMany(a => a.Comments)
                .WithOne(c => c.Article!)
                .HasForeignKey(c => c.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BlogComment>()
                .HasKey(c => c.Id);
        }
    }
}
