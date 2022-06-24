using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCreate.DbOperations;

namespace ApiCreate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherConditionInTurkeyController : ControllerBase
    {
        private readonly WeatherForecastDbContext _context;

        public WeatherConditionInTurkeyController(WeatherForecastDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public IActionResult GetCities()
        {
            var result = _context.Bilgiler.OrderBy(x=>x.id).ToList<WeatherForecast>();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetCityById(int id)
        {
            var result = _context.Bilgiler.Where(x => x.id == id).SingleOrDefault();
            if(result is null)
            {
                string message = new InvalidOperationException("Girilen id bilgisine ait şehir bulunamadı!").ToString();
                return BadRequest(message);

            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id,[FromBody] WeatherForecast updatedCity)
        {
            var city = _context.Bilgiler.SingleOrDefault(x => x.id == id);
            if(city is null)
            {
                string message = new InvalidOperationException("Girilen id bilgisine ait şehir bulunamadı!").ToString();
                return BadRequest(message);
            }
     
            city.name = updatedCity.name != default ? updatedCity.name : city.name;
            city.Date = updatedCity.Date !=default ? updatedCity.Date : city.Date;
            city.Summary = updatedCity.Summary !=default ? updatedCity.Summary : city.Summary;
            city.TemperatureC = updatedCity.TemperatureC != default ? updatedCity.TemperatureC : city.TemperatureC;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var result = _context.Bilgiler.SingleOrDefault(x => x.id == id);
            if(result is null)
            {
                string message = new InvalidOperationException("Girilen id bilgisine ait şehir bulunamadı!").ToString();
                return BadRequest(message);
            }

            _context.Bilgiler.Remove(result);
            _context.SaveChanges();
            return Ok();
        }
    }
}
