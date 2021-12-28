
namespace WeatherApp.Dto
{
    public class CityDto
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public string PrimaryPostalCode { get; set; }
        public RegionDto Region { get; set; }
        public CountryDto Country { get; set; }
        public AdministrativeAreaDto AdministrativeArea { get; set; }
        public TimeZoneDto TimeZone { get; set; }
        public GeoPositionDto GeoPosition { get; set; }
        public bool IsAlias { get; set; }
        public ParentCityDto ParentCity { get; set; }
      
    }


}