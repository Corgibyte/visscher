using System;

namespace VisscherApi.Models;

public class BattlesByDate : WikiList
{
  public int BattlesByDateId { get; set; }

  public override bool Scrape()
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