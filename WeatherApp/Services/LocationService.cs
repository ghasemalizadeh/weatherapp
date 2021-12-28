using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using WeatherApp.ApiServices;
using WeatherApp.Dto;
using WeatherApp.Model;
using WeatherApp.Persistence;
using System;

namespace WeatherApp.Services
{
    public class LocationService : ILocationService
    {
        private readonly WeatherContext _context;
        private readonly IWeatherApiService _weatherService;
        private readonly IMapper _mapper;

        public LocationService(WeatherContext context, IWeatherApiService weatherService, IMapper mapper)
        {
            _mapper = mapper;
            _weatherService = weatherService;
            _context = context;

        }


        public async Task<IEnumerable<CityDto>> GetAllAreas()
        {

            return _mapper.Map<List<City>, List<CityDto>>(await _context.Cities.ToListAsync());
        }

        public async Task<IEnumerable<CityDto>> GetAreasByCountry(string countryCode)
        {
            return _mapper.Map<List<City>, List<CityDto>>(await _context.Cities
            .Where(ar => ar.CountryId == countryCode).ToListAsync());
        }

        public async Task<IEnumerable<CountryDto>> GetAllCountriesWithAreas()
        {
            var co = await _context.Countries.Include(c => c.Cities).ToListAsync();
            return _mapper.Map<List<Country>, List<CountryDto>>(co);
        }


        public async Task<IEnumerable<RegionDto>> GetAllRegions()
        {
            var regions = await _context.Regions.ToListAsync();
            if (regions.Count == 0)
            {
                var regionsDto = await _weatherService.GetRegions();

                foreach (RegionDto rd in regionsDto)
                {
                    Region r = _mapper.Map<RegionDto, Region>(rd);
                    _context.Regions.Add(r);

                }
                await _context.SaveChangesAsync();

                regions = await _context.Regions.ToListAsync();
            }

            return _mapper.Map<List<Region>, List<RegionDto>>(regions);
        }

        public async Task<IEnumerable<CountryDto>> GetRegionConutries(string regionCode)
        {
            var countries = await _context.Countries.Where(c => c.RegionId == regionCode).ToListAsync();
            if (countries.Count() > 0)
                return _mapper.Map<List<Country>, List<CountryDto>>(countries);

            var countriesDto = await _weatherService.GetCountriesByRegion(regionCode);
            if (countriesDto.Count() > 0)
            {
                foreach (CountryDto cd in countriesDto)
                {
                    Country c = _mapper.Map<CountryDto, Country>(cd);
                    c.RegionId = regionCode;
                    if (_context.Regions.Find(c.ID) == null)
                    {
                        try
                        {
                            _context.Countries.Add(c);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(c.ID);
                            Console.WriteLine(ex);
                        }
                    }
                }

                await _context.SaveChangesAsync();


            }
            countries = await _context.Countries.Where(c => c.RegionId == regionCode).ToListAsync();
            return _mapper.Map<List<Country>, List<CountryDto>>(countries);
        }



        public async Task<IEnumerable<CityDto>> Search(string city, string countrycode, string? adminCode)
        {
            var result = await _weatherService.Search(city, countrycode, adminCode);
            foreach (var area in result)
            {
                var country = _mapper.Map<CountryDto, Country>(area.Country);
                var region = _mapper.Map<RegionDto, Region>(area.Region);
                var adminArea = _mapper.Map<AdministrativeAreaDto, AdministrativeArea>(area.AdministrativeArea);
                var timeZone = _mapper.Map<TimeZoneDto, WeatherApp.Model.TimeZone>(area.TimeZone);
                var areaModel = _mapper.Map<CityDto, City>(area);
                if (_context.Cities.Find(area.Key) == null)
                {
                    if (_context.AdministrativeAreas.Find(adminArea.ID) != null)
                    {
                        areaModel.AdministrativeArea = null;
                        areaModel.AdministrativeAreaId = adminArea.ID;
                    }
                    if (_context.Countries.Find(country.ID) != null)
                    {
                        areaModel.Country = null;
                        areaModel.CountryId = country.ID;
                    }

                    if (_context.Regions.Find(region.ID) != null)
                    {
                        areaModel.Region = null;
                        areaModel.RegionId = region.ID;
                    }

                    if (_context.TimeZones.Find(timeZone.Code) != null)
                    {
                        areaModel.TimeZone = null;
                        areaModel.TimeZoneId = timeZone.Code;
                    }
                    _context.Cities.Add(areaModel);
                }
            }
            _context.SaveChanges();
            return result;
        }

        public async Task<IEnumerable<AdministrativeAreaDto>> GetCountryAdminAreas(string countryCode)
        {
            var areas = await _context.AdministrativeAreas.Include(ar => ar.Cities).Where(ar => ar.CountryId == countryCode).ToListAsync();
            if (areas.Count == 0)
            {
                var areasDto = await _weatherService.GetAdministrativeAreasByCountry(countryCode);

                foreach (AdministrativeAreaDto ad in areasDto)
                {
                    AdministrativeArea a = _mapper.Map<AdministrativeAreaDto, AdministrativeArea>(ad);
                    a.CountryId = countryCode;
                    _context.AdministrativeAreas.Add(a);

                }
                await _context.SaveChangesAsync();

                areas = await _context.AdministrativeAreas.Include(ar => ar.Cities).Where(ar => ar.CountryId == countryCode).ToListAsync();
            }

            return _mapper.Map<List<AdministrativeArea>, List<AdministrativeAreaDto>>(areas);

        }
    }
}