using Newtonsoft.Json;

namespace ProcessingJSON.Models
{
    public class Video
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("yt:videoId")]
        public string VideoId { get; set; }

        [JsonProperty("link")]
        public VideoLink Link { get; set; }
    }
}