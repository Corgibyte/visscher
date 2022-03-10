using HtmlAgilityPack;
using System;
using System.Linq;
using System.Collections.Generic;

namespace VisscherApi.Models;

public class EarthquakesMasterList : WikiList
{
  public override ParseResult Parse(string html, VisscherApiContext db)
  {
    int count = 0;
    HtmlDocument htmlDoc = new HtmlDocument();
    htmlDoc.LoadHtml(html);
    IEnumerable<HtmlNode> tables = htmlDoc.DocumentNode.Descendants("table")
      .Where(table => table.InnerHtml.Contains("Event"));
    foreach (HtmlNode table in tables)
    {
      IEnumerable<HtmlNode> rows = table.Descendants("tr");
      foreach (HtmlNode row in rows)
      {
        HtmlNode cell = row.Descendants("td")
          .Where(node => node.FirstChild.GetAttributeValue("href", "").Contains("/wiki/"))
          .FirstOrDefault();
        if (cell != null)
        {
          string url = "https://en.wikipedia.org" + cell.FirstChild.GetAttributeValue("href", "");
          Earthquake earthquake = db.Earthquakes.FirstOrDefault(earthquake => earthquake.Url == url);
          if (earthquake == null)
          {
            earthquake = new Earthquake
            {
              Url = url,
              CategoryId = 2,
              Name = "Not parsed",
              LastChecked = DateTime.MinValue,
              Latitude = 0,
              Longitude = 0
            };
            db.Add(earthquake);
            db.SaveChanges();
            count++;
          }
        }
      }
    }
    return new ParseResult { Result = true, Message = $"Added {count} earthquakes" };
  }
}