using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using VisscherApi.Models;
using VisscherApi.Services;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VisscherApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BattlesController : ControllerBase
{
  private readonly VisscherApiContext _db;
  private readonly HttpService _httpService;
  private readonly ILogger<BattlesController> _log;

  public BattlesController(VisscherApiContext db, HttpService httpService, ILogger<BattlesController> log)
  {
    _db = db;
    _httpService = httpService;
    _log = log;
  }

  //GET api/battles
  [HttpGet]
  public ActionResult Get(int startYear = 9999, int endYear = 9999)
  {
    IQueryable<Battle> battles = _db.Battles.AsQueryable();
    battles = battles.Where(battle => battle.LastChecked != DateTime.MinValue);
    if (startYear != 9999 || endYear != 9999)
    {
      startYear = startYear == 9999 ? startYear = -1000 : startYear;
      endYear = endYear == 9999 ? endYear = 2030 : endYear;
      battles = battles.Where(battle => battle.Year >= startYear && battle.Year <= endYear);
    }
    return new JsonResult(battles);
  }

  [HttpPost("update")]
  public async Task<ActionResult> Update()
  {
    BattlesAlphabetical list = await _db.BattlesAlphabetical.FirstOrDefaultAsync(list => list.WikiListId == 1);
    _httpService.AddToQueue(list);
    bool inList = _httpService.QueueContains(list);
    while (inList)
    {
      Thread.Sleep(1000);
      inList = _httpService.QueueContains(list);
    }
    foreach (Battle battle in _db.Battles)
    {
      if (battle.NeedsUpdate())
      {
        _httpService.AddToQueue(battle);
      }
    }
    return Ok();
  }
}