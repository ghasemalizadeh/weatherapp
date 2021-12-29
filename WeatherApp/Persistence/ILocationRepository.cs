using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Dto;

namespace WeatherApp.Persistence
{
    interface ILocationRepository
    {
        Task<IEnumerable<CityDto>> GetAreasByCountry(string countryCode);
        Task<IEnumerable<CountryDto>> GetAllCountriesWithAreas();
        Task<IEnumerable<RegionDto>> GetAllRegions();
        Task<IEnumerable<CountryDto>> GetRegionConutries(string regionCode);
        Task<IEnumerable<AdministrativeAreaDto>> GetCountryAdminAreas(string countryCode);
    }
}
