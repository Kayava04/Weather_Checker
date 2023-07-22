using Newtonsoft.Json;

namespace Weather_Checker.Data
{
    public class SysData
    {
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}