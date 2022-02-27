using System;
using System.ComponentModel.DataAnnotations;

namespace VisscherApi.Models;

public abstract class WikiList : IScrapeable
{
  public string Url { get; set; }
  public DateTime LastChecked { get; set; }
  public int CategoryId { get; set; }
  public virtual Category Category { get; set; }
  [Key]
  public int WikiListId { get; set; }

  public abstract ParseResult Parse(string html, VisscherApiContext db);

  public bool NeedsUpdate()
  {
    TimeSpan timeSinceUpdate = DateTime.Now - LastChecked;
    return timeSinceUpdate.Days > 3;
  }
}