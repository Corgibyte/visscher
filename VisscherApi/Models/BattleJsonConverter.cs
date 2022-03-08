using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace VisscherApi.Models;

public class BattleJsonConverter : JsonConverter<Battle>
{
  private readonly Type[] _types;

  public BattleJsonConverter(params Type[] types)
  {
    _types = types;
  }

  public override void WriteJson(JsonWriter writer, Battle battle, JsonSerializer serializer)
  {
    JToken token = JToken.FromObject(battle);
    if (token.Type != JTokenType.Object)
    {
      token.WriteTo(writer);
    }
    else
    {
      JObject o = (JObject)token;
      o.AddFirst(new JProperty("coordinates", new[] { battle.Longitude, battle.Latitude }));
      o.AddFirst(new JProperty("type", "Point"));
      o.WriteTo(writer);
    }
  }

  public override Battle ReadJson(JsonReader reader, Type objectType, Battle battle, bool hasExistingValue, JsonSerializer serializer)
  {
    throw new NotImplementedException("Unnecessary because CanRead is false.");
  }

  public override bool CanRead
  {
    get { return false; }
  }
}