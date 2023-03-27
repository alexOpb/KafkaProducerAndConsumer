using Microsoft.AspNetCore.Mvc;

namespace KafkaProducerAndConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherProducer _producer;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherProducer producer)
    {
        _logger = logger;
        _producer = producer;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        foreach (var weatherForecast in weatherForecasts)
        {
            _producer.Publish(weatherForecast);
        }
        
        return weatherForecasts;
    }
}