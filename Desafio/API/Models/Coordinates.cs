using System.Text.Json.Serialization;

namespace API.Models
{
    /// <summary>
    /// Coordinates
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Coordinates() { }

        /// <summary>
        /// Constructor with data
        /// </summary>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        public Coordinates(string latitude, string longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Latitude
        /// </summary>
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
    }
}
