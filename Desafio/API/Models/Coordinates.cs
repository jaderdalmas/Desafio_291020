using System.Text.Json.Serialization;

namespace API.Models
{
    public class Coordinates
    {
        public Coordinates() { }
        public Coordinates(string latitude, string longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
    }
}
