using System.ComponentModel.DataAnnotations;
using System;
using VisscherApi.Services;
using System.ComponentModel.DataAnnotations.Schema;

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
  public int Year { get; set; }

  public string Url { get; set; }

  public DateTime LastChecked { get; set; }

  [ForeignKey("Categories")]
  public int CategoryId { get; set; }
  public virtual Category Category { get; set; }

  [Key]
  public int EventId { get; set; }

  public abstract ParseResult Parse(string html, VisscherApiContext db);

  public abstract bool Update(HttpService httpService);

  public float ParseLatOrLongString(string latOrLong)
  {
    string[] workingArray = latOrLong.Split('°');
    float degrees = float.Parse(workingArray[0]);
    workingArray = workingArray[1].Split('′');
    float minutes = float.Parse(workingArray[0]);
    workingArray = workingArray[1].Split('″');
    float seconds = float.Parse(workingArray[0]);
    float value = degrees + (minutes / 60) + (seconds / 3600);
    return workingArray[1] == "N" || workingArray[1] == "W" ? value : value * -1;
  }

  public int ParseDateForYear(string date)
  {
    string[] words = date.Split(" ");
    foreach (string word in words)
    {
      int year;
      if (word.Length >= 3 && int.TryParse(word, out year))
      {
        return year;
      }
    }
    return -1;
  }
}