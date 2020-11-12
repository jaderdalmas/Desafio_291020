using API.Extension;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Models
{
    /// <summary>
    /// User Output (interface format)
    /// </summary>
    public class UserOutput
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserOutput() { }

        /// <summary>
        /// Convert user input to output
        /// </summary>
        /// <param name="user">User input</param>
        public UserOutput(UserInput user)
        {
            if (user != null)
            {
                Type = user.Location?.Coordinates?.Classification().ToString();
                Gender = user.Gender?.UpperFirst();
                Name = user.Name;
                Location = user.Location;
                if (Location != null)
                    Location.Region = user.Location?.State?.Region();
                Email = user.Email;
                Birthday = user.Dob?.Date ?? DateTime.MinValue;
                Registered = user.Registered?.Date ?? DateTime.MinValue;
                TelephoneNumbers = new List<string>() { user.Phone.E164() };
                MobileNumbers = new List<string>() { user.Cell.E164() };
                Picture = user.Picture;
            }
        }

        /// <summary>
        /// Type
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [JsonPropertyName("name")]
        public Name Name { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        [JsonPropertyName("location")]
        public Location Location { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Birth Date
        /// </summary>
        [JsonPropertyName("birthday")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Register Date
        /// </summary>
        [JsonPropertyName("registered")]
        public DateTime Registered { get; set; }

        /// <summary>
        /// Phone Numbers
        /// </summary>
        [JsonPropertyName("telephonenumbers")]
        public IEnumerable<string> TelephoneNumbers { get; set; }

        /// <summary>
        /// Mobile Numbers
        /// </summary>
        [JsonPropertyName("mobilenumbers")]
        public IEnumerable<string> MobileNumbers { get; set; }

        /// <summary>
        /// Picture
        /// </summary>
        [JsonPropertyName("picture")]
        public Picture Picture { get; set; }

        /// <summary>
        /// Nationality (BR as default)
        /// </summary>
        [JsonPropertyName("nationality")]
        public string Nationality => "BR";
    }
}