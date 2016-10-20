using Newtonsoft.Json;

namespace ProcessingJSON.Models
{
    public class VideoLink
    {
        [JsonProperty("@rel")]
        public string Rel { get; set; }

        [JsonProperty("@href")]
        public string Href { get; set; }
    }
}