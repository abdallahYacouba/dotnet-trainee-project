
using Microsoft.EntityFrameworkCore;

namespace BlogApp;

public class BlogAppDb : DbContext
{
    public BlogAppDb(DbContextOptions<BlogAppDb> option)
            : base(option) { }
    public DbSet<Blog> Blogs { get; set; } = null!;
}
