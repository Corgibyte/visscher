using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using VisscherApi.Models;
using VisscherApi.Services;
using System;
using Serilog;

namespace VisscherApi;

public class Startup
{
  public Startup(IConfiguration configuration)
  {
    Configuration = configuration;
  }

  public IConfiguration Configuration { get; }

  // This method gets called by the runtime. Use this method to add services to the container.
  public void ConfigureServices(IServiceCollection services)
  {

    services.AddControllers();
    services.AddDbContext<VisscherApiContext>(opt =>
        opt.UseSqlServer(Configuration.GetConnectionString("MyDbConnection")))
      .AddMvc()
      .AddNewtonsoftJson();
    services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "Visscher API", Version = "v1" });
    });
    services.AddSingleton<HttpService>();
    services.AddCors(options =>
    {
      options.AddPolicy("CorsPolicy",
        builder => builder
          .AllowAnyMethod()
          .AllowCredentials()
          .SetIsOriginAllowed((host) => true)
          .AllowAnyHeader());
    });
  }

  // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
    }

    // app.UseHttpsRedirection();
    app.UseSerilogRequestLogging();
    app.UseRouting();

    app.UseCors("CorsPolicy");
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllers();
      endpoints.MapSwagger();
    });

    app.UseSwaggerUI(c =>
    {
      c.SwaggerEndpoint("v1/swagger.json", "Visscher API V1");
    });
  }
}
