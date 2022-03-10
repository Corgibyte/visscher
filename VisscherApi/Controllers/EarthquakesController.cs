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
public class EarthquakesController : ControllerBase
{
  private readonly VisscherApiContext _db;
  private readonly HttpService _httpService;
  private readonly ILogger<EarthquakesController> _log;

  public EarthquakesController(VisscherApiContext db, HttpService httpService, ILogger<EarthquakesController> log)
  {
    _db = db;
    _httpService = httpService;
    _log = log;
  }

  //GET api/battles
  [HttpGet]
  public ActionResult Get(int startYear = 9999, int endYear = 9999)
  {
    IQueryable<Earthquake> earthquakes = _db.Earthquakes.AsQueryable();
    earthquakes = earthquakes.Where(earthquake => earthquake.LastChecked != DateTime.MinValue);
    if (startYear != 9999 || endYear != 9999)
    {
      startYear = startYear == 9999 ? startYear = -1000 : startYear;
      endYear = endYear == 9999 ? endYear = 2030 : endYear;
      earthquakes = earthquakes.Where(earthquake => earthquake.Year >= startYear && earthquake.Year <= endYear);
    }
    return new ContentResult()
    {
      StatusCode = (int)HttpStatusCode.OK,
      ContentType = "applications/json",
      Content = JsonConvert.SerializeObject(earthquakes, new BattleJsonConverter())
    };
  }

  [HttpPost("update")]
  public async Task<ActionResult> Update(int id = 0)
  {
    if (id == 0)
    {
      EarthquakesMasterList list = await _db.EarthquakesMasterList.FirstOrDefaultAsync(list => list.WikiListId == 2);
      _httpService.AddToQueue(list);
      bool inList = _httpService.QueueContains(list);
      while (inList)
      {
        Thread.Sleep(1000);
        inList = _httpService.QueueContains(list);
      }
      Thread.Sleep(30000);
      _db.ChangeTracker.Clear();
      await _db.SaveChangesAsync();
      foreach (Earthquake earthquake in _db.Earthquakes)
      {
        if (earthquake.NeedsUpdate())
        {
          _httpService.AddToQueue(earthquake);
        }
      }
    }
    else
    {
      Earthquake selectedEarthquake = await _db.Earthquakes.FirstOrDefaultAsync(earthquake => earthquake.EventId == id);
      _httpService.AddToQueue(selectedEarthquake);
    }
    return Ok();
  }
}