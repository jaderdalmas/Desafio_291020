using System.Text.Json.Serialization;

namespace API.Models
{
    /// <summary>
    /// Name
    /// </summary>
    public class Name
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Name() { }

        /// <summary>
        /// Constructor with data
        /// </summary>
        /// <param name="title">title</param>
        /// <param name="first">first</param>
        /// <param name="last">last</param>
        public Name(string title, string first, string last)
        {
            Title = title;
            First = first;
            Last = last;
        }

        /// <summary>
        /// Title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// First
        /// </summary>
        [JsonPropertyName("first")]
        public string First { get; set; }

        /// <summary>
        /// Last
        /// </summary>
        [JsonPropertyName("last")]
        public string Last { get; set; }
    }
}
