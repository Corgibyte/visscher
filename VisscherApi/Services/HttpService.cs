using VisscherApi.Models;
using Microsoft.Extensions.DependencyInjection;
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

  public HttpService(IServiceProvider provider)
  {
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
      thisScrapeable.Parse(htmlResponse, _db);
      _db.ChangeTracker.Clear();
    }
  }

  public void AddToQueue(IScrapeable scrapeable)
  {
    _queue.Enqueue(scrapeable);
  }
}