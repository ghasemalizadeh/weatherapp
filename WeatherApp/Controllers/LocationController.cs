using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Dto;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("/api/location")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;

        }

        [HttpGet("allCountries")]
        public async Task<IEnumerable<CountryDto>> GetAllCountries() {

            return await _locationService.GetAllCountriesWithAreas();
        }

        [HttpGet("GetAllRegions")]
        public async Task<IEnumerable<RegionDto>> GetAllRegions() {

             return await _locationService.GetAllRegions();
            
        }

        [HttpGet("GetRegionCountries/{regionCode}")]
        public async Task<IEnumerable<CountryDto>> GetRegionCountries(string regionCode) {

             return await _locationService.GetRegionConutries(regionCode);
            
        }

        [HttpGet("GetCountryAdminAreas/{countryCode}")]
        public async Task<IEnumerable<AdministrativeAreaDto>> GetAdminAreas(string countryCode) {

             return await _locationService.GetCountryAdminAreas(countryCode);
            
        }

        [HttpGet("search/{country}/{adminArea}/{city}")]
        public async Task<IEnumerable<CityDto>> SearchForCity(string city,string country,string adminArea) {

            return await _locationService.Search(city,country,adminArea);
        }

       


    }
}