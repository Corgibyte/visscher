using Microsoft.EntityFrameworkCore;
using System;

namespace VisscherApi.Models;

public class VisscherApiContext : DbContext
{
  public DbSet<Battle> Battles { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<BattlesByDate> BattlesByDateList { get; set; }
  public DbSet<BattlesAlphabetical> BattlesAlphabetical { get; set; }
  public DbSet<Earthquake> Earthquakes { get; set; }
  public DbSet<EarthquakesMasterList> EarthquakesMasterList { get; set; }

  public VisscherApiContext(DbContextOptions<VisscherApiContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<Category>()
      .HasData(
        new Category
        {
          CategoryId = 1
        },
        new Category
        {
          CategoryId = 2
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
    builder.Entity<Earthquake>()
      .HasData(
        new Earthquake
        {
          Url = "https://en.wikipedia.org/wiki/2000_Enggano_earthquake",
          Name = "Not parsed",
          LastChecked = DateTime.MinValue,
          CategoryId = 2,
          EventId = 5001
        }
      );
    builder.Entity<EarthquakesMasterList>()
      .HasData(
        new EarthquakesMasterList
        {
          WikiListId = 2,
          CategoryId = 2,
          Url = "https://en.wikipedia.org/wiki/Lists_of_earthquakes",
          LastChecked = DateTime.MinValue
        }
      );
  }
}
