using ApiTrainee.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTrainee.DataContext;
public class TraineeDbContext : DbContext
{
    public TraineeDbContext(DbContextOptions<TraineeDbContext> option)
            : base(option) { }
    public DbSet<Trainee> Trainees { get; set; } = null!;
}
