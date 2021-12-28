using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace WeatherApp.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Region
    {
        
        public Region()
        {
           this.Countries = new List<Country>();
        }
        
        [Key]
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }

        public IEnumerable<Country> Countries { get; set; }
    }


}