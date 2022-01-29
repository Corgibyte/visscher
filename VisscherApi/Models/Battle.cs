using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VisscherApi.Models;

public class Battle : IMappableEvent
{
  public int BattleId { get; set; }
  [Range(-90, 90)]
  public int Latitude { get; set; }
  [Range(-180, 180)]
  public int Longitude { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public virtual ICollection<BattleBelligerent> BattleBelligerents { get; set; }
  public string Url { get; set; }

  public Battle()
  {
    BattleBelligerents = new HashSet<BattleBelligerent>();
  }
}