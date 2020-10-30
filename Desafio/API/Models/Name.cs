using System.Text.Json.Serialization;

namespace API.Models
{
    public class Name
    {
        public Name() { }
        public Name(string title, string first, string last)
        {
            Title = title;
            First = first;
            Last = last;
        }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("first")]
        public string First { get; set; }

        [JsonPropertyName("last")]
        public string Last { get; set; }
    }
}
