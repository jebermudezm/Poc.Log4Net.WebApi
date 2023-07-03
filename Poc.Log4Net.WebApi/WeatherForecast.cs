using System.ComponentModel.DataAnnotations;

namespace Poc.Log4Net.WebApi
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
        [RegularExpression("([YN])", ErrorMessage ="The field is't valid, only use Y or N")]
        [MaxLength(1)]
        public string TestYN { get; set; }
    }
}