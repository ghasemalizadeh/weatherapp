using System;

namespace WeatherApp.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Headline
    {
        public int? Id { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int? EffectiveEpochDate { get; set; }
        public int? Severity { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public DateTime? EndDate { get; set; }
        public int? EndEpochDate { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }


}
