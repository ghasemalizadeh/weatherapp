using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Dto;

namespace WeatherApp.Services
{
    public interface IForecastService
    {
        Task<FiveDaysForcastOutputDto> GetFiveDaysForecast(string locationCode);

      
       
    }
}