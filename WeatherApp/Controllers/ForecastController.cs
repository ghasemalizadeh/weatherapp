using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.ApiServices;
using WeatherApp.Dto;
using WeatherApp.Persistence;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("/api/forcast")]
    public class ForecastController : ControllerBase
    {
        private readonly ILogger<ForecastController> _logger;
        private readonly IForecastService _forcastService;

        public ForecastController(ILogger<ForecastController> logger, IForecastService forcastService)
        {
            _forcastService = forcastService;
            _logger = logger;
        }

             

        [HttpGet("5Days/{locationCode}")]
        public async Task<FiveDaysForcastOutputDto> GetFiveDaysForcast(string locationCode)
        {
            var result = await _forcastService.GetFiveDaysForecast(locationCode);

            return result;

        }

       


       

        
    }
}
