using System;
using VisscherApi.Services;

namespace VisscherApi.Models;

public class BattlesByDate : WikiList
{
  public int BattlesByDateId { get; set; }

  public override bool Parse(string url)
  {
    //TODO
    return false;
  }

  public override bool Update(HttpService httpService)
  {
    //TODO
    return false;
  }
}