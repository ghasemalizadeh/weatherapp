// export interface forcast{
//     cityName:string;
//     countryName:string;
//     minimumTemprature:string;
//     maximumTemprature:string;
//     date:string;
//     unit: TempratureUnit;
// }

using System.Collections.Generic;

namespace WeatherApp.Dto
{
    public class FiveDaysForcastOutputDto
    {
        public FiveDaysForcastOutputDto()
        {
          DailyForecasts = new List<DailyForcastOutputDto>();

        }
        public string CityName { get; set; }
        public string CounntryName { get; set; }
        public List<DailyForcastOutputDto> DailyForecasts { get; set; }


    }

}