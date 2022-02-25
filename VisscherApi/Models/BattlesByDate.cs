using System;

namespace VisscherApi.Models;

public class BattlesByDate : WikiList
{
  public int BattlesByDateId { get; set; }

  public override bool Scrape(string url)
  {
    //TODO
    return false;
  }

  public override bool Update()
  {
    //TODO
    return false;
  }
}