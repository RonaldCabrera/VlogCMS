using Microsoft.EntityFrameworkCore;
using VlogCMS.Api.Models;

namespace VlogCMS.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Category> Categories {  get; set; } 
        public DbSet<State> States {  get; set; } 
        public DbSet<Page> Pages {  get; set; } 
        public DbSet<Blog> Blogs {  get; set; } 
        public DbSet<Comment> Comments {  get; set; } 
        public DbSet<Image> Images {  get; set; } 
    }
}
