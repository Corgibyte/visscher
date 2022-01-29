using Microsoft.EntityFrameworkCore;

namespace VisscherApi.Models;

public class VisscherApiContext : DbContext
{
  public virtual DbSet<Battle> Battles { get; set; }
  public virtual DbSet<Belligerent> Belligerents { get; set; }
  public virtual DbSet<BattleBelligerent> BattleBelligerents { get; set; }

  public VisscherApiContext(DbContextOptions<VisscherApiContext> options) : base(options) { }
}
