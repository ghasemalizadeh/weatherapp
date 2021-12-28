using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Dto;

namespace WeatherApp.ApiServices
{
    public interface IWeatherApiService
    {
        Task<FiveDaysForcastDto> GetFiveDaysForcast(string locationCode);
        Task<IEnumerable<CityDto>> Search(string city,string countrycode,string adminCode);

        Task<IEnumerable<RegionDto>> GetRegions();
        Task<IEnumerable<CountryDto>> GetCountriesByRegion(string regionCode);

        Task<IEnumerable<AdministrativeAreaDto>> GetAdministrativeAreasByCountry(string countryCode);
         
    }
}