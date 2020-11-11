using System.Text.Json.Serialization;

namespace API.Models
{
    /// <summary>
    /// Location
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Location() { }

        /// <summary>
        /// Constructor with data
        /// </summary>
        /// <param name="region">region</param>
        /// <param name="street">street</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="postcode">post code (integer conversion)</param>
        public Location(string region, string street, string city, string state, string postcode)
        {
            Region = region;
            Street = street;
            City = city;
            State = state;
            Postcode = int.Parse(postcode);
        }

        /// <summary>
        /// Region from coordinates
        /// </summary>
        [JsonPropertyName("region")]
        public string Region { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        [JsonPropertyName("street")]
        public string Street { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// State
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// Post Code
        /// </summary>
        [JsonPropertyName("postcode")]
        public int Postcode { get; set; }

        /// <summary>
        /// Coordinates
        /// </summary>
        [JsonPropertyName("coordinates")]
        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// Time Zone
        /// </summary>
        [JsonPropertyName("timezone")]
        public Timezone Timezone { get; set; }
    }
}
