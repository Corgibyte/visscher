using Microsoft.EntityFrameworkCore;
using System;

namespace VisscherApi.Models;

public class VisscherApiContext : DbContext
{
  public DbSet<Battle> Battles { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<BattlesByDate> BattlesByDateList { get; set; }
  public DbSet<BattlesAlphabetical> BattlesAlphabetical { get; set; }

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
    builder.Entity<BattlesAlphabetical>()
      .HasData(
        new BattlesAlphabetical
        {
          WikiListId = 1,
          CategoryId = 1,
          Url = "https://en.wikipedia.org/wiki/List_of_battles_(alphabetical)",
          LastChecked = DateTime.MinValue
        }
      );
  }
}
