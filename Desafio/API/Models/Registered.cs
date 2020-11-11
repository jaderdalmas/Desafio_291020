using System;
using System.Text.Json.Serialization;

namespace API.Models
{
    /// <summary>
    /// Registered
    /// </summary>
    public class Registered
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Registered() { }

        /// <summary>
        /// Constructor with data
        /// </summary>
        /// <param name="date">date (date conversion)</param>
        /// <param name="age">age (integer conversion)</param>
        public Registered(string date, string age)
        {
            Date = DateTime.Parse(date);
            Age = int.Parse(age);
        }

        /// <summary>
        /// Registration Date
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Registration Age
        /// </summary>
        [JsonPropertyName("age")]
        public int Age { get; set; }
    }
}
