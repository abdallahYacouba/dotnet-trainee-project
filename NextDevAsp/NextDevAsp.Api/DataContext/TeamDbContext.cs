using Microsoft.EntityFrameworkCore;
using NextDevAsp.Api.Models;

namespace NextDevAsp.Api.DataContext
{
    public class TeamDbContext : DbContext
    {
        public TeamDbContext(DbContextOptions<TeamDbContext> options)
            : base(options)
        {
        }
        public DbSet<TeamMember> TeamMembers { get; set; }
    }
}
