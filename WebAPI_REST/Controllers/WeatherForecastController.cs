using Microsoft.AspNetCore.Mvc;

namespace WebAPI_REST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // Declaració de les variables 'Summaries' i '_logger'
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        // Constructor
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // Los 'IEnumerable' pueden ser recorridos con el 'foreach'
        // IEnumerable  - Quan les dades que hi ha a la col·lecció son solament de lectura
        // ICollection  - Quan es necessari modificar les dades de la col·lecció i la seva mida
        // IList        - Quan es necessari modificar les dades de la col·lecció, que aquestes estiguin ordenades i saber la seva posició
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

    }
}