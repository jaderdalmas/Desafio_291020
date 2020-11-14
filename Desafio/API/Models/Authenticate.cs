using System;

namespace API.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class Authenticate
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
