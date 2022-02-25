using System;
using VisscherApi.Services;

namespace VisscherApi.Models;

public abstract class WikiList : IScrapeable
{
  public string Url { get; set; }
  public DateTime LastChecked { get; set; }
  public int CategoryId { get; set; }

  public abstract bool Parse(string html, VisscherApiContext db);

  public abstract bool Update(HttpService httpService);
}