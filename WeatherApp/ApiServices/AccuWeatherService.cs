using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Dto;

namespace WeatherApp.ApiServices
{
    public class AccuWeatherService : IWeatherApiService
    {

        private const string apiKey = "2FHxt9yE5d03PbyAYmBAA5MaaSCOgnaJ";
        //private const string apiKey ="Brzuz113dua0ZSvnxVkcGyLa8kKaVwA8";

          
        private const string baseUrl = "http://dataservice.accuweather.com/";

        
        public async Task<IEnumerable<AdministrativeAreaDto>> GetAdministrativeAreasByCountry(string countryCode)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{baseUrl}locations/v1/adminareas/{countryCode}?apikey={apiKey}"))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<AdministrativeAreaDto>>(apiResponse);
                    return result;
                }
            }
        }

        public async Task<IEnumerable<CountryDto>> GetCountriesByRegion(string regionCode)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{baseUrl}locations/v1/countries/{regionCode}?apikey={apiKey}"))
                {
                    if(response.IsSuccessStatusCode){
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<CountryDto>>(apiResponse);
                    return result;
                    }
                    else
                    return null;
                }
            }
        }

        public async Task<FiveDaysForcastDto> GetFiveDaysForcast(string locationCode)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{baseUrl}forecasts/v1/daily/5day/{locationCode}?apikey={apiKey}&metric=true"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<FiveDaysForcastDto>(apiResponse);
                    return result;
                }
            }
        }

        public async Task<IEnumerable<RegionDto>> GetRegions()
        {
           using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{baseUrl}locations/v1/regions?apikey={apiKey}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<RegionDto>>(apiResponse);
                    return result;
                }
            }
        }

        public async Task<IEnumerable<CityDto>> Search(string city,string countrycode,string adminCode)
        {
             using (var httpClient = new HttpClient())
            {
                string query = $"{baseUrl}locations/v1/cities/{countrycode}/{adminCode}/search?q={city}&apikey={apiKey}";
                using (var response = await httpClient.GetAsync(query))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<CityDto>>(apiResponse);
                    return result;
                }
            }
        }
    }
}