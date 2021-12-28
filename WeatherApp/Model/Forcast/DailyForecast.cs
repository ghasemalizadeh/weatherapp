using System;
using System.Collections.Generic;

namespace WeatherApp.Model
{
    public class DailyForecast
    {
        public int Id { get; set; }
       
        public DateTime Date { get; set; }
        public int EpochDate { get; set; }
        public Temperature Temperature { get; set; }
        public Day Day { get; set; }
        public Night Night { get; set; }
        //public string Sources { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }


}
