using HtmlAgilityPack;
using System;
using System.Linq;
using System.Collections.Generic;

namespace VisscherApi.Models;

public class BattlesAlphabetical : WikiList
{
  public override ParseResult Parse(string html, VisscherApiContext db)
  {
    int count = 0;
    HtmlDocument htmlDoc = new HtmlDocument();
    htmlDoc.LoadHtml(html);
    IQueryable<HtmlNode> nodes = htmlDoc.DocumentNode.Descendants("li")
      .Where(node => node.FirstChild.GetAttributeValue("href", "").Contains("/wiki/"))
      .AsQueryable();
    nodes = nodes.Where(node => !node.GetAttributeValue("id", "").Contains("footer"));
    nodes = nodes.Where(node => !node.GetAttributeValue("class", "").Contains("mw-list-item"));
    nodes = nodes.Where(node => !node.FirstChild.GetAttributeValue("href", "").Contains("/wiki/Category"));
    nodes = nodes.Where(node => !node.FirstChild.GetAttributeValue("href", "").Contains("#"));
    foreach (HtmlNode node in nodes)
    {
      string url = "https://en.wikipedia.org" + node.FirstChild.GetAttributeValue("href", "");
      Battle battle = db.Battles.FirstOrDefault(battle => battle.Url == url);
      if (battle == null)
      {
        battle = new Battle
        {
          Url = url,
          CategoryId = 1,
          Name = "Not parsed",
          LastChecked = DateTime.MinValue,
          Latitude = 0,
          Longitude = 0
        };
        db.Add(battle);
        db.SaveChanges();
        count++;
      }
    }
    return new ParseResult { Result = true, Message = $"Added {count} battles" };
  }
}