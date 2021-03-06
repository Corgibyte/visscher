using System.ComponentModel.DataAnnotations;
using System;
using Newtonsoft.Json;

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

  [JsonIgnore]
  [ForeignKey("Categories")]
  public int CategoryId { get; set; }
  [JsonIgnore]
  public virtual Category Category { get; set; }

  [Key]
  public int EventId { get; set; }

  public abstract ParseResult Parse(string html, VisscherApiContext db);

  public bool NeedsUpdate()
  {
    TimeSpan timeSinceUpdate = DateTime.Now - LastChecked;
    return timeSinceUpdate.Days > 30;
  }

  public float ParseLatOrLongString(string latOrLong)
  {
    string[] workingArray = latOrLong.Split('°');
    float degrees = float.Parse(workingArray[0]);
    float minutes = 0;
    if (workingArray[1].Contains("′"))
    {
      workingArray = workingArray[1].Split('′');
      minutes = float.Parse(workingArray[0]);
    }
    float seconds = 0;
    if (workingArray[1].Contains("″"))
    {
      workingArray = workingArray[1].Split('″');
      seconds = float.Parse(workingArray[0]);
    }
    float value = degrees + (minutes / 60) + (seconds / 3600);
    return latOrLong.Contains("N") || latOrLong.Contains("E") ? value : value * -1;
  }

  public ParseResult ParseDateForYear(string date)
  {
    string[] words = date.Split(" ");
    foreach (string word in words)
    {
      int year;
      if (word.Length >= 3 && int.TryParse(word, out year) || (word.Length > 4 && int.TryParse(word.Substring(0, 4), out year)))
      {
        if (date.Contains(" BC"))
        {
          year *= -1;
        }
        return new ParseResult { Result = true, Message = year.ToString() };
      }
    }
    return new ParseResult { Result = false, Message = date };
  }
}