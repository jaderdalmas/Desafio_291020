using System.Text.Json.Serialization;

namespace API.Models
{
    public class Location
    {
        public Location() { }
        public Location(string region, string street, string city, string state, string postcode)
        {
            Region = region;
            Street = street;
            City = city;
            State = state;
            Postcode = int.Parse(postcode);
        }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("postcode")]
        public int Postcode { get; set; }

        [JsonPropertyName("coordinates")]
        public Coordinates Coordinates { get; set; }

        [JsonPropertyName("timezone")]
        public Timezone Timezone { get; set; }
    }
}
