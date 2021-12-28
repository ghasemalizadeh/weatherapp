using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Dto;

namespace WeatherApp.Services
{
    public interface ILocationService
    {
          Task<IEnumerable<CityDto>> Search(string city,string? countrycode,string? adminCode);
          Task<IEnumerable<CityDto>> GetAreasByCountry(string countryCode);
          Task<IEnumerable<CountryDto>> GetAllCountriesWithAreas();
         Task<IEnumerable<RegionDto>> GetAllRegions();
         Task<IEnumerable<CountryDto>> GetRegionConutries(string regionCode);
         Task<IEnumerable<AdministrativeAreaDto>> GetCountryAdminAreas(string countryCode);
    }
}