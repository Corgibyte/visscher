using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using VisscherApi.Models;
using VisscherApi.Services;
using System.Threading;
using Serilog;

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
  public async Task<ActionResult> Get()
  {
    foreach (Battle battle in _db.Battles)
    {
      _httpService.AddToQueue(battle);
    }
    await Task.CompletedTask;
    return Ok();
  }
}