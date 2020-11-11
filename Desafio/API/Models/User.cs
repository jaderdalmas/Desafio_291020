using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Models
{
    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        /// <summary>
        /// List of Users
        /// </summary>
        [JsonPropertyName("results")]
        public IEnumerable<UserInput> Results { get; set; }
    }
}
