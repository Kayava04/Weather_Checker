using Newtonsoft.Json;

namespace Weather_Checker.Data
{
    public class TemperatureData
    {
        [JsonProperty("temp")]
        public double TemperatureInfo { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }
}