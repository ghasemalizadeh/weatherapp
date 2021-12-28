using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Model
{
    public class TimeZone
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public double GmtOffset { get; set; }
        public bool IsDaylightSaving { get; set; }
       
    }
}