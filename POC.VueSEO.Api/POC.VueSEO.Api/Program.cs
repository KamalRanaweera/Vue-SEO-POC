using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using POC.VueSEO.Api.Interfaces;
using POC.VueSEO.Api.Mockups;
using POC.VueSEO.Api.Services;
using System.Diagnostics;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IPageDataService, MockPageDataService>();
builder.Services.AddScoped<IRequestProcessingService, RequestProcessingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
var vueAppRoot = builder.Configuration.GetSection("VueAppPublishRoot").Value;

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
    $"{vueAppRoot}\\assets"),
    RequestPath = "/assets"
});

app.MapGet("/api/seo", () =>
{
    return Results.Json(new object[] { });
});

app.MapGet("/api/seo/{id}", (Guid id) =>
{
    return Results.Json(new object { });
});

app.MapGet("/", async (IRequestProcessingService rps, string? path, HttpContext context) => Results.Text(await rps.ProcessIndex(null, context), "text/html"));
app.MapGet("/{*path:regex(^(?!assets/))}", async (IRequestProcessingService rps, string? path, HttpContext context) => Results.Text(await rps.ProcessIndex(path, context), "text/html"));

app.Run();





bool GetRequestAgent(HttpContext context)
{
    string userAgent = context.Request.Headers.UserAgent.ToString();
    return true;// RequestAgentType.Browser;
}