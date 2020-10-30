using System.Text.Json.Serialization;

namespace API.Models
{
    public class Timezone
    {
        public Timezone() { }
        public Timezone(string offset, string description)
        {
            Offset = offset;
            Description = description;
        }

        [JsonPropertyName("offset")]
        public string Offset { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
