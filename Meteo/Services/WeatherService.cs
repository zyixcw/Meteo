using Meteo.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Meteo.Services
{
    public class WeatherService
    {
        public async Task<WeatherData> GetWeatherDataAsync(string city)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync($"https://www.prevision-meteo.ch/services/json/{city}");
                var weatherData = JsonConvert.DeserializeObject<WeatherData>(response);
                return weatherData;
            }
        }
    }
}
