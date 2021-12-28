using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Dto
{

    public class FiveDaysForcastDto
    {
        public int Id { get; set; }

        public string LocationId { get; set; }
        
        public HeadlineDto Headline { get; set; }
        public List<DailyForecastDto> DailyForecasts { get; set; }
    }


}
