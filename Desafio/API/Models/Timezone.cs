using System.Text.Json.Serialization;

namespace API.Models
{
    /// <summary>
    /// Time Zone
    /// </summary>
    public class Timezone
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Timezone() { }

        /// <summary>
        /// Constructor with data
        /// </summary>
        /// <param name="offset">offset</param>
        /// <param name="description">description</param>
        public Timezone(string offset, string description)
        {
            Offset = offset;
            Description = description;
        }

        /// <summary>
        /// OffSet
        /// </summary>
        [JsonPropertyName("offset")]
        public string Offset { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
