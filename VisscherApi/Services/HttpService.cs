using VisscherApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace VisscherApi.Services;

public class HttpService
{
  private readonly VisscherApiContext _db;
  private System.Threading.Timer _timer = null;
  private Queue<IScrapeable> _queue;
  private readonly HttpClient _client;
  private readonly ILogger<HttpService> _log;

  public HttpService(IServiceProvider provider, ILogger<HttpService> log)
  {
    _log = log;
    _queue = new Queue<IScrapeable>();
    _db = provider.GetRequiredService<VisscherApiContext>();
    _client = new HttpClient();
#pragma warning disable 4014
    StartAsync();
  }

  private async Task StartAsync()
  {
    _timer = new Timer(IncrementQueue, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
    await Task.CompletedTask;
  }

  private async void IncrementQueue(object state)
  {
    if (_queue.Count != 0)
    {
      IScrapeable thisScrapeable = _queue.Dequeue();
      string htmlResponse = await _client.GetStringAsync(thisScrapeable.Url);
      ParseResult result = thisScrapeable.Parse(htmlResponse, _db);
      _db.ChangeTracker.Clear();
      if (result.Result)
      {
        _log.Log(LogLevel.Information, result.Message, null);
      }
      else
      {
        _log.Log(LogLevel.Error, result.Message, null);
      }
    }
  }

  public void AddToQueue(IScrapeable scrapeable)
  {
    _queue.Enqueue(scrapeable);
  }
}