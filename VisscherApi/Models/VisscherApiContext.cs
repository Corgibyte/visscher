using Microsoft.EntityFrameworkCore;

namespace VisscherApi.Models;

public class VisscherApiContext : DbContext
{
  public DbSet<Battle> Battles { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<BattlesByDate> BattlesByDateList { get; set; }

  public VisscherApiContext(DbContextOptions<VisscherApiContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<Category>()
      .HasData(
        new Category
        {
          CategoryId = 1
        }
      );
  }
}
