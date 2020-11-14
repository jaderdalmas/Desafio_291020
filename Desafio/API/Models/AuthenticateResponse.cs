using System;

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
        public Guid Id { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; set; }
    }
}
