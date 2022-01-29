namespace VisscherApi.Models;

public class BattleBelligerent
{
  public int BattleBelligerentId { get; set; }
  public int BattleId { get; set; }
  public int BelligerentId { get; set; }
  public virtual Belligerent Belligerent { get; set; }
  public virtual Battle Battle { get; set; }
}
