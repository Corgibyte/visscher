using Microsoft.EntityFrameworkCore;
using System;

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
    builder.Entity<Battle>()
      .HasData(
        new Battle
        {
          EventId = 1,
          CategoryId = 1,
          Name = "Battle of Ad Decimum",
          Url = "https://en.wikipedia.org/wiki/Battle_of_Ad_Decimum",
          LastChecked = DateTime.MinValue,
          Latitude = 0,
          Longitude = 0
        }
      );
  }
}
