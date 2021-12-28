using System.ComponentModel.DataAnnotations;
namespace WeatherApp.Dto
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class RegionDto
    {
        [Key]
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
    }


}