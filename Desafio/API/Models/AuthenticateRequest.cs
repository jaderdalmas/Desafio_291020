using System.Text.Json.Serialization;

namespace API.Models
{
    /// <summary>
    /// Authenticate
    /// </summary>
    public class AuthenticateRequest
    {
        /// <summary>
        /// Name
        /// </summary>
        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
