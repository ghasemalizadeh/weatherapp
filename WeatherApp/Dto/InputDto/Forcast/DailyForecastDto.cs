using System;
using System.Collections.Generic;

namespace WeatherApp.Dto
{
    public class DailyForecastDto
    {
        public int Id { get; set; }
       
        
        public DateTime Date { get; set; }
        public int EpochDate { get; set; }
        public TemperatureDto Temperature { get; set; }
        public DayDto Day { get; set; }
        public NightDto Night { get; set; }
        //public string Sources { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }


}
