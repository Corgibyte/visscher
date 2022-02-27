using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using VisscherApi.Services;

namespace VisscherApi.Models;

public class Battle : MappableEvent
{
  public override ParseResult Parse(string html, VisscherApiContext db)
  {
    HtmlDocument htmlDoc = new HtmlDocument();
    htmlDoc.LoadHtml(html);
    string latitude = htmlDoc.DocumentNode.Descendants()
      .Where(node => node.GetAttributeValue("class", "").Contains("latitude"))
      .FirstOrDefault()
      .InnerText;
    string longitude = htmlDoc.DocumentNode.Descendants()
      .Where(node => node.GetAttributeValue("class", "").Contains("longitude"))
      .FirstOrDefault()
      .InnerText;
    string name = htmlDoc.DocumentNode.Descendants()
      .Where(node => node.GetAttributeValue("class", "").Contains("firstHeading"))
      .FirstOrDefault()
      .InnerText;
    int year = ParseDateForYear(htmlDoc.DocumentNode.Descendants("tr")
      .Where(node => node.FirstChild.InnerText == "Date")
      .FirstOrDefault().Descendants("td")
      .FirstOrDefault().InnerText);
    //* Only save entity to database if it has found a lat, long, and year
    if (latitude != "" && longitude != "" && name != "" && year != -1)
    {
      Battle newBattle = new Battle()
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
      db.Entry(newBattle).State = EntityState.Modified;
      db.SaveChanges();
      return new ParseResult { Result = true, Message = $"{name} parsed" };
    }
    return new ParseResult { Result = false, Message = $"Unable to parse {name}. Lat: {latitude}. Long: {longitude}. Year: {year}." };
  }

  public override bool NeedsUpdate()
  {
    //TODO
    return false;
  }
}