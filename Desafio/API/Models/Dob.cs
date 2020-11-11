using System;
using System.Text.Json.Serialization;

namespace API.Models
{
    /// <summary>
    /// Date of Birth
    /// </summary>
    public class Dob
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Dob() { }

        /// <summary>
        /// Constructor with data
        /// </summary>
        /// <param name="date">date (date conversion)</param>
        /// <param name="age">age (integer conversion)</param>
        public Dob(string date, string age)
        {
            Date = DateTime.Parse(date);
            Age = int.Parse(age);
        }

        /// <summary>
        /// Birth date
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// age
        /// </summary>
        [JsonPropertyName("age")]
        public int Age { get; set; }
    }
}
