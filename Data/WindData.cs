using Newtonsoft.Json;

namespace Weather_Checker.Data
{
    public class WindData
    {
        [JsonProperty("speed")]
        public double WindSpeed { get; set; }
    }
}