namespace VisscherApi.Models;

public class BattlesAlphabetical : WikiList
{
  public int BattlesAlphabeticalId { get; set; }

  public override ParseResult Parse(string html, VisscherApiContext db)
  {
    //TODO
    return new ParseResult { Result = false, Message = "TODO" };
  }
}