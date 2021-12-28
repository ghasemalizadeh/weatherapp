using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace WeatherApp.Dto
{
    public class CountryDto
    {
        [Key]
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public IEnumerable<CityDto> Cities { get;set;}

        public CountryDto(){
            Cities = new List<CityDto>();
        }
      
    }


}