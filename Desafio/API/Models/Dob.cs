using System;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class Dob
    {
        public Dob() { }
        public Dob(string date, string age)
        {
            Date = DateTime.Parse(date);
            Age = int.Parse(age);
        }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }
    }
}
