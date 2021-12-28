
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using AutoMapper;

using WeatherApp.Persistence;
using WeatherApp.ApiServices;
using WeatherApp.Dto;
using WeatherApp.Model;
using System.Collections.Generic;

namespace WeatherApp.Services
{
    public class ForecastService : IForecastService
    {
        private readonly WeatherContext _context;
        private readonly IWeatherApiService _weatherService;
        private readonly IMapper _mapper;
        private readonly ILocationService _locationService;

        public ForecastService(WeatherContext context, IWeatherApiService weatherService, IMapper mapper, ILocationService locationService)
        {
            _locationService = locationService;
            _mapper = mapper;
            _weatherService = weatherService;
            _context = context;

        }
        public async Task<FiveDaysForcastOutputDto> GetFiveDaysForecast(string locationCode)
        {
            //Search for the result in database
            var res = GetFiveDaysForecastFromDb(locationCode);
            if (res.Count() > 0 ){
                for(int i=0; i < res.Count ; i++){

                if(res[i].DailyForecasts[0].Date.DayOfYear == DateTime.Now.Date.DayOfYear )
                return _mapper.Map<FiveDaysForcast, FiveDaysForcastOutputDto>(res[i]);
                }
            }

            //Get the forcast from WeatherApi Service and store it in database
            var result = await _weatherService.GetFiveDaysForcast(locationCode);
            result.LocationId = locationCode;
            _context.FiveDaysForcasts.Add(_mapper.Map<FiveDaysForcastDto, FiveDaysForcast>(result));
            _context.SaveChanges();

            //Get the result from database
            res = GetFiveDaysForecastFromDb(locationCode);
            return _mapper.Map<FiveDaysForcast, FiveDaysForcastOutputDto>(res.Last());
        }


        private List<FiveDaysForcast> GetFiveDaysForecastFromDb(string locationCode)
        {
           
            var res = _context.FiveDaysForcasts.Include(f=>f.Location).ThenInclude(l=>l.Country)
            .Include(f => f.Headline).Include(f => f.DailyForecasts)
            .ThenInclude(d => d.Temperature).ThenInclude(temp => temp.Minimum)
            .Include(f => f.DailyForecasts).ThenInclude(d => d.Temperature)
            .ThenInclude(temp => temp.Maximum)
            .Where(f => f.LocationId == locationCode)
            .ToList<FiveDaysForcast>();
           
            return res;
        }



    }
}