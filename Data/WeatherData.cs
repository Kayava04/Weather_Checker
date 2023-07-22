using Newtonsoft.Json;

namespace Weather_Checker.Data
{
    public class WeatherData
    {
        [JsonProperty("name")]
        public string City { get; set; }

        [JsonProperty("main")]
        public TemperatureData Temperature { get; set; }

        [JsonProperty("weather")]
        public DescriptionData[] Description { get; set; }

        [JsonProperty("sys")]
        public SysData Data { get; set; }

        [JsonProperty("wind")]
        public WindData Wind { get; set; }
    }
}