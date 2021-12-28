using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Model
{
    public class City
    {
        public int Version { get; set; }
        [Key]
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public string PrimaryPostalCode { get; set; }
        public Region Region { get; set; }
        public string RegionId { get; set; }
        public Country Country { get; set; }

        public AdministrativeArea AdministrativeArea { get; set; }

         public string AdministrativeAreaId { get; set; }

        public string CountryId { get; set; }
        public TimeZone TimeZone { get; set; }

         public string TimeZoneId { get; set; }
        public bool IsAlias { get; set; }
        public string ParentCityKey { get; set; }
    }
}