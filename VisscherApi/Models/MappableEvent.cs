using System.ComponentModel.DataAnnotations;
using System;
using VisscherApi.Services;

namespace VisscherApi.Models;

public abstract class MappableEvent : IScrapeable
{

  [Required, Range(-90, 90)]
  public float Latitude { get; set; }

  [Required, Range(-180, 180)]
  public float Longitude { get; set; }

  [Required]
  public string Name { get; set; }

  [Required]
  public string Description { get; set; }

  [Required]
  public DateTime Date { get; set; }

  public string Url { get; set; }

  public DateTime LastChecked { get; set; }

  public abstract bool Parse(string url);

  public abstract bool Update(HttpService httpService);

  public int CategoryId { get; set; }

  [Key]
  public int EventId { get; set; }
}