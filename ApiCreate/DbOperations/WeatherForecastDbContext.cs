using  Microsoft.EntityFrameworkCore;

namespace ApiCreate.DbOperations
{
    public class WeatherForecastDbContext:DbContext
    {
        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options) : base(options)
        {

        }
        public DbSet<WeatherForecast> Bilgiler { get; set; }

    }
}
