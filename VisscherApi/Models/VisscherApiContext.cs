using Microsoft.EntityFrameworkCore;

namespace VisscherApi.Models;

public class VisscherApiContext : DbContext
{
  //TODO

  public VisscherApiContext(DbContextOptions<VisscherApiContext> options) : base(options) { }
}
