using System;

namespace VisscherApi.Models;

public abstract class WikiList : IScrapeable
{
  public string Url { get; set; }
  public DateTime LastChecked { get; set; }
  public int CategoryId { get; set; }

  public abstract bool Scrape(string url);

  public abstract bool Update();
}