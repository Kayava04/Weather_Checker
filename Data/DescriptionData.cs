using Newtonsoft.Json;

namespace Weather_Checker.Data
{
    public class DescriptionData
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}