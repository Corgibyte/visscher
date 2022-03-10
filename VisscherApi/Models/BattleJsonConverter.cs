using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace VisscherApi.Models;

public class MappableEventJsonConverter : JsonConverter<MappableEvent>
{
  private readonly Type[] _types;

  public MappableEventJsonConverter(params Type[] types)
  {
    _types = types;
  }

  public override void WriteJson(JsonWriter writer, MappableEvent mapEvent, JsonSerializer serializer)
  {
    JToken token = JToken.FromObject(mapEvent);
    if (token.Type != JTokenType.Object)
    {
      token.WriteTo(writer);
    }
    else
    {
      JObject o = (JObject)token;
      o.AddFirst(new JProperty("coordinates", new[] { mapEvent.Longitude, mapEvent.Latitude }));
      o.AddFirst(new JProperty("type", "Point"));
      o.WriteTo(writer);
    }
  }

  public override MappableEvent ReadJson(JsonReader reader, Type objectType, MappableEvent mapEvent, bool hasExistingValue, JsonSerializer serializer)
  {
    throw new NotImplementedException("Unnecessary because CanRead is false.");
  }

  public override bool CanRead
  {
    get { return false; }
  }
}