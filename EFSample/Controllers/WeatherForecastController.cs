using Microsoft.AspNetCore.Mvc;

namespace EFSample.Controllers;

using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ApplicationDbContext _context;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ApplicationDbContext context, ILogger<WeatherForecastController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get()
    {
        var result = await _context.WeatherForecast.ToListAsync();
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(WeatherForecast forecast)
    {
        _context.WeatherForecast.Update(forecast);
        await _context.SaveChangesAsync();
        
        return Ok();
    }
}