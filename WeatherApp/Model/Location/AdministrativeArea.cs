using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Model
{
    public class AdministrativeArea
    {

        public AdministrativeArea(){
            Cities = new List<City>();

        }

        [Key]
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public int Level { get; set; }
        public string LocalizedType { get; set; }
        public string EnglishType { get; set; }
        public string CountryId { get; set; }
        public Country Country { get; set; }

         public IEnumerable<City> Cities { get; set; }
        
        

    }
}