using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ApiCreate.DbOperations
{
    public class DataGenerator 
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WeatherForecastDbContext(serviceProvider.GetRequiredService<DbContextOptions<WeatherForecastDbContext>>()))
            {
                if (context.Bilgiler.Any())
                {
                    return;
                }
                context.Bilgiler.AddRange(
                    new WeatherForecast
                    {
                        name = "Adana",
                        Date = DateTime.Now,
                        TemperatureC = 34,
                        Summary = "hot"
                    },
                    new WeatherForecast
                    {
                        name = "Adıyaman",
                        Date = DateTime.Now,
                        TemperatureC = 30,
                        Summary = "warm"
                    },
                    new WeatherForecast
                    {
                        name = "Afyon",
                        Date = DateTime.Now,
                        TemperatureC = 20,
                        Summary = "cold"
                    });
                
            context.SaveChanges();
            }

        }
        
        


    }
}
