using System.Text.Json.Serialization;

namespace API.Models
{
    /// <summary>
    /// User Input (from external sources)
    /// </summary>
    public class UserInput
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserInput() { }

        /// <summary>
        /// Constructor with data
        /// </summary>
        /// <param name="gender">gender</param>
        /// <param name="email">email</param>
        /// <param name="phone">phone</param>
        /// <param name="cell">cell</param>
        public UserInput(string gender, string email, string phone, string cell)
        {
            Gender = gender;
            Email = email;
            Phone = phone;
            Cell = cell;
        }

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
        /// Date of Birth
        /// </summary>
        [JsonPropertyName("dob")]
        public Dob Dob { get; set; }

        /// <summary>
        /// Registered
        /// </summary>
        [JsonPropertyName("registered")]
        public Registered Registered { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Cell
        /// </summary>
        [JsonPropertyName("cell")]
        public string Cell { get; set; }

        /// <summary>
        /// Picture
        /// </summary>
        [JsonPropertyName("picture")]
        public Picture Picture { get; set; }

        /// <summary>
        /// Get in output format
        /// </summary>
        /// <returns></returns>
        public UserOutput GetOutput() => new UserOutput(this);
    }
}
