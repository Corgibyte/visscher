using System;

namespace VisscherApi.Models;

public interface IScrapeable
{
  public string Url { get; set; }
  public DateTime LastChecked { get; set; }

  public bool Scrape(string html);

  public bool Update();
}