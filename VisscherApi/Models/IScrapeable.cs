using System;
using VisscherApi.Services;

namespace VisscherApi.Models;

public interface IScrapeable
{
  public string Url { get; set; }
  public DateTime LastChecked { get; set; }

  public bool Parse(string html, VisscherApiContext db);

  public bool Update(HttpService httpService);
}