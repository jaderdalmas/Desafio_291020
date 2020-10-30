using System.Text.Json.Serialization;

namespace API.Models
{
    public class Picture
    {
        public Picture() { }
        public Picture(string large, string medium, string thumbnail)
        {
            Large = large;
            Medium = medium;
            Thumbnail = thumbnail;
        }

        [JsonPropertyName("large")]
        public string Large { get; set; }

        [JsonPropertyName("medium")]
        public string Medium { get; set; }

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
