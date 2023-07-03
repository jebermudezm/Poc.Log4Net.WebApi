using log4net;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Poc.Log4Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ILog _log;
        //private static readonly ILog log = LogManager.GetLogger(typeof(WeatherForecastController));

        public WeatherForecastController()
        {
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        [HttpPost]
        public IActionResult WeatherForecast(WeatherForecast entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("the model is'valid.");
            }
            else
            {
                return Ok("the model is valid, test aproved.");
            }
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            try
            {
                _log.Info("Action start");
                var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                    TestYN = "S"
                })
                .ToArray();
                return result;
            }
            catch (Exception ex)
            {
                _log.Error($"Error has ocurred: {ex}");
                return null;
            }
           
        }
    }
}