using System.Text.Json.Serialization;

namespace API.Models
{
    /// <summary>
    /// Picture
    /// </summary>
    public class Picture
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Picture() { }

        /// <summary>
        /// Constructor with data
        /// </summary>
        /// <param name="large">large</param>
        /// <param name="medium">medium</param>
        /// <param name="thumbnail">thumbnail</param>
        public Picture(string large, string medium, string thumbnail)
        {
            Large = large;
            Medium = medium;
            Thumbnail = thumbnail;
        }

        /// <summary>
        /// Large
        /// </summary>
        [JsonPropertyName("large")]
        public string Large { get; set; }

        /// <summary>
        /// Medium
        /// </summary>
        [JsonPropertyName("medium")]
        public string Medium { get; set; }

        /// <summary>
        /// Thumbnail
        /// </summary>
        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
