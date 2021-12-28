

using AutoMapper;
using WeatherApp.Dto;
using WeatherApp.Model;

namespace WeatherApp.MappingProfile{

public class LocationMappingProfile : Profile {
     public LocationMappingProfile() {
         // Add as many of these lines as you need to map your objects
        CreateMap<CityDto,City>();
        CreateMap<RegionDto,Region>();
        CreateMap<CountryDto,Country>();
        CreateMap<AdministrativeAreaDto,AdministrativeArea>();
        CreateMap<TimeZoneDto,TimeZone>();

        CreateMap<City,CityDto>().ForMember(c=>c.Country,opt=>opt.Ignore())
        .ForMember(c=>c.AdministrativeArea,opt=>opt.Ignore());
        CreateMap<Region,RegionDto>();
        CreateMap<Country,CountryDto>();
        CreateMap<TimeZone,TimeZoneDto>();
        CreateMap<AdministrativeArea,AdministrativeAreaDto>();

        
     }
 }
}