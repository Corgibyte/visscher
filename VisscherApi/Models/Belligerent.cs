using System.Collections.Generic;

namespace VisscherApi.Models;

public class Belligerent
{
  public int BelligerentId { get; set; }
  public virtual ICollection<BattleBelligerent> BattleBelligerents { get; set; }
  public string Name { get; set; }
  public string Url { get; set; }

  public Belligerent()
  {
    BattleBelligerents = new HashSet<BattleBelligerent>();
  }
}