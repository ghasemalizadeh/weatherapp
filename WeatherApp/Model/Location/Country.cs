using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace WeatherApp.Model
{
    public class Country
    {
        [Key]
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }

        public Region Region { get; set; }

         public string RegionId { get; set; }
                
        public IEnumerable<City> Cities { get;set;}

        public IEnumerable<AdministrativeArea> AdministrativeAreas { get;set;}

        public Country(){
            Cities = new List<City>();
            AdministrativeAreas = new List<AdministrativeArea>();
        }

    }


}