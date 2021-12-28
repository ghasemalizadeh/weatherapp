using AutoMapper;

using WeatherApp.Model;
using WeatherApp.Dto;

namespace WeatherApp.MappingProfile
{
    public class ForcastMappingProfile:Profile
    {
        public ForcastMappingProfile(){

            CreateMap<HeadlineDto,Headline>();
            CreateMap<DailyForecastDto,DailyForecast>();
            CreateMap<FiveDaysForcastDto,FiveDaysForcast>();
            CreateMap<DayDto,Day>();
            CreateMap<ImperialDto,Imperial>();
            CreateMap<MetricDto,Metric>();
            CreateMap<MaximumDto,Maximum>();
            CreateMap<MinimumDto,Minimum>();
            CreateMap<NightDto,Night>();
            CreateMap<TemperatureDto,Temperature>();


            CreateMap<Headline,HeadlineDto>();
            CreateMap<DailyForecast,DailyForecastDto>();
            CreateMap<FiveDaysForcast,FiveDaysForcastDto>();
            CreateMap<Day,DayDto>();
            CreateMap<Imperial,ImperialDto>();
            CreateMap<Metric,MetricDto>();
            CreateMap<Maximum,MaximumDto>();
            CreateMap<Minimum,MinimumDto>();
            CreateMap<Night,NightDto>();
            CreateMap<Temperature,TemperatureDto>();

            CreateMap<FiveDaysForcast,FiveDaysForcastOutputDto>()
            .ForMember(fdo=>fdo.CityName,opt=>opt.MapFrom(fd=>fd.Location.EnglishName))
            .ForMember(fdo=>fdo.CounntryName,opt=>opt.MapFrom(fd=>fd.Location.Country.EnglishName));

            CreateMap<DailyForecast,DailyForcastOutputDto>()
            .ForMember(dfo=>dfo.Date,opt=>opt.MapFrom(df=>df.Date.ToShortDateString()))
            .ForMember(dfo=>dfo.MinmumTemprature,opt=>opt.MapFrom(df=>df.Temperature.Minimum.Value.ToString()))
            .ForMember(dfo=>dfo.MaximumTemprature,opt=>opt.MapFrom(df=>df.Temperature.Maximum.Value.ToString()))
            .ForMember(dfo=>dfo.TempratureUnit,opt=>opt.MapFrom(df=>df.Temperature.Minimum.Unit));

            



        }
        
    }
}