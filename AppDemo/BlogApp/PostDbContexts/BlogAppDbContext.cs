using BlogApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.PostDbContexts;

public class BlogAppDbContext : DbContext
{
    public BlogAppDbContext(DbContextOptions<BlogAppDbContext> options)
        : base(options) {}
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<Voiture> Voitures { get; set; } = null!;
}
