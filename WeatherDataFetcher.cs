using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Weather_Checker.Data;

namespace Weather_Checker
{
    public class WeatherDataFetcher
    {
        private const string API_KEY = "9e8b1a98cbf2a8ae8c401735746cf798";
        private const string URL = "https://api.openweathermap.org/data/2.5/weather";

        public async Task<WeatherData> GetWeatherDataAsync(string cityName)
        {
            string apiUrl = $"{URL}?q={cityName}&appid={API_KEY}";
            WebRequest request = WebRequest.Create(apiUrl);
            request.Method = "GET";
            request.ContentType = "application/x-www-urlencoded";
            string answer = string.Empty;
            try
            {
                using (WebResponse response = await request.GetResponseAsync())
                using (Stream s = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(s))
                    answer = await reader.ReadToEndAsync();
                WeatherData WD = JsonConvert.DeserializeObject<WeatherData>(answer);
                return WD;
            }
            catch (WebException)
            {
                return null;
            }
        }
    }
}