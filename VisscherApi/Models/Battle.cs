using VisscherApi.Services;

namespace VisscherApi.Models;

public class Battle : MappableEvent
{
  public override bool Parse(string html, VisscherApiContext db)
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