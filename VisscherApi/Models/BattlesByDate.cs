using VisscherApi.Services;

namespace VisscherApi.Models;

public class BattlesByDate : WikiList
{
  public int BattlesByDateId { get; set; }

  public override ParseResult Parse(string html, VisscherApiContext db)
  {
    //TODO
    return new ParseResult { Result = false, Message = "TODO" };
  }

  public override bool Update(HttpService httpService)
  {
    //TODO
    return false;
  }
}