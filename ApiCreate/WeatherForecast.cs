using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCreate
{
    public class WeatherForecast
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }    
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }
    }
}
