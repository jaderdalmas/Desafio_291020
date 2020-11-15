using System;
using System.Text.Json.Serialization;

namespace API.Models
{
    /// <summary>
    /// Authenticate
    /// </summary>
    public class AuthenticateResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AuthenticateResponse() { }

        /// <summary>
        /// Constructor by Repos
        /// </summary>
        public AuthenticateResponse(Authenticate auth)
        {
            Id = auth.Id;
            UserName = auth.UserName;
        }

        /// <summary>
        /// Id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        [JsonPropertyName("userName")]
        public string UserName { get; set; }
    }
}
