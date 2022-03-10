using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace VisscherApi.Models;

public class Earthquake : MappableEvent
{
  public override ParseResult Parse(string html, VisscherApiContext db)
  {
    HtmlDocument htmlDoc = new HtmlDocument();
    htmlDoc.LoadHtml(html);
    string name = htmlDoc.DocumentNode.Descendants()
      .Where(node => node.GetAttributeValue("class", "").Contains("firstHeading"))
      .FirstOrDefault()
      .InnerText;
    HtmlNode workingNode = htmlDoc.DocumentNode.Descendants()
      .Where(node => node.GetAttributeValue("class", "").Contains("latitude"))
      .FirstOrDefault();
    if (workingNode == null)
    {
      return new ParseResult { Result = false, Message = $"Unable to parse {name}: no latitude found" };
    }
    string latitude = workingNode.InnerText;
    workingNode = htmlDoc.DocumentNode.Descendants()
      .Where(node => node.GetAttributeValue("class", "").Contains("longitude"))
      .FirstOrDefault();
    if (workingNode == null)
    {
      return new ParseResult { Result = false, Message = $"Unable to parse {name}: no longitude found" };
    }
    string longitude = workingNode.InnerText;
    workingNode = htmlDoc.DocumentNode.Descendants("tr")
      .Where(node => node.FirstChild.InnerText.Contains("UTC"))
      .FirstOrDefault();
    if (workingNode == null)
    {
      return new ParseResult { Result = false, Message = $"Unable to parse {name}: no date found" };
    }
    ParseResult dateParse = ParseDateForYear(workingNode.Descendants("td").FirstOrDefault().InnerText);
    int year = -1;
    if (dateParse.Result)
    {
      year = int.Parse(dateParse.Message);
    }
    //* Only save entity to database if it has found a lat, long, and year
    if (latitude != "" && longitude != "" && name != "" && year != -1)
    {
      Earthquake newEarthquake = new Earthquake()
      {
        Latitude = ParseLatOrLongString(latitude),
        Longitude = ParseLatOrLongString(longitude),
        Name = name,
        Year = year,
        CategoryId = CategoryId,
        Url = Url,
        LastChecked = DateTime.Now,
        EventId = EventId
      };
      db.Entry(newEarthquake).State = EntityState.Modified;
      db.SaveChanges();
      db.ChangeTracker.Clear();
      db.SaveChanges();
      return new ParseResult { Result = true, Message = $"{name} parsed" };
    }
    return new ParseResult { Result = false, Message = $"Unable to parse {name}. Lat: {latitude}. Long: {longitude}. Date: {dateParse.Message}." };
  }
}