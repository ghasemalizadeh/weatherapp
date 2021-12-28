using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Dto
{
    public class AdministrativeAreaDto
    {
        [Key]
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public int Level { get; set; }
        public string LocalizedType { get; set; }
        public string EnglishType { get; set; }
        public string CountryID { get; set; }
        public IEnumerable<CityDto> Cities { get; set; }
    }


}