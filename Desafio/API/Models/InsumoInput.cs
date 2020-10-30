using System.Text.Json.Serialization;

namespace API.Models
{
    public class InsumoInput
    {
        public InsumoInput() { }

        public InsumoInput(string gender, string email, string phone, string cell)
        {
            Gender = gender;
            Email = email;
            Phone = phone;
            Cell = cell;
        }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("name")]
        public Name Name { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("dob")]
        public Dob Dob { get; set; }

        [JsonPropertyName("registered")]
        public Registered Registered { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("cell")]
        public string Cell { get; set; }

        [JsonPropertyName("picture")]
        public Picture Picture { get; set; }

        public InsumoOutput GetOutput() => new InsumoOutput(this);
    }
}
