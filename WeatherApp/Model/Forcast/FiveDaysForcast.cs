using System.Collections.Generic;

namespace WeatherApp.Model
{
    public class FiveDaysForcast
    {
        public int Id { get; set; }
        public City Location { get; set; }
        public string LocationId { get; set; }
        public Headline Headline { get; set; }
        public List<DailyForecast> DailyForecasts { get; set; }
    }


}
