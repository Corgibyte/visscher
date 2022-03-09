using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Linq;
using VisscherApi.Models;
using VisscherApi.Services;

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
    return new ContentResult()
    {
      StatusCode = (int)HttpStatusCode.OK,
      ContentType = "applications/json",
      Content = JsonConvert.SerializeObject(battles, new BattleJsonConverter())
    };
  }

  [HttpPost("update")]
  public async Task<ActionResult> Update(int id = 0)
  {
    if (id == 0)
    {
      // BattlesAlphabetical list = await _db.BattlesAlphabetical.FirstOrDefaultAsync(list => list.WikiListId == 1);
      // _httpService.AddToQueue(list);
      // bool inList = _httpService.QueueContains(list);
      // while (inList)
      // {
      //   Thread.Sleep(1000);
      //   inList = _httpService.QueueContains(list);
      // }
      foreach (Battle battle in _db.Battles)
      {
        if (battle.NeedsUpdate())
        {
          _httpService.AddToQueue(battle);
        }
      }
    }
    else
    {
      Battle selectedBattle = _db.Battles.FirstOrDefault(battle => battle.EventId == id);
      _httpService.AddToQueue(selectedBattle);
    }
    return Ok();
  }
}