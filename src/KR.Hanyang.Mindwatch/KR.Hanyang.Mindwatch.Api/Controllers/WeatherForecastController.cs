using KR.Hanyang.Mindwatch.Application.Contracts;
using KR.Hanyang.Mindwatch.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KR.Hanyang.Mindwatch.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IMindwatchRepository _repository;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMindwatchRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}


        [HttpGet(Name = "GetBingus")]
        public async Task<IEnumerable<Employee>> GetBingus()
        {
            return await _repository.FindAllAsync<Employee>();
        }
    }
}
