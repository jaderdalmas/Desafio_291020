using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class User
    {
        [JsonPropertyName("results")]
        public IEnumerable<UserInput> Results { get; set; }
    }
}
