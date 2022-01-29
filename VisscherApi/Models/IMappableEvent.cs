using System.ComponentModel.DataAnnotations;

namespace VisscherApi.Models;

public interface IMappableEvent
{
  [Range(-90, 90)]
  public int Latitude { get; set; }
  [Range(-180, 180)]
  public int Longitude { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Url { get; set; }
}