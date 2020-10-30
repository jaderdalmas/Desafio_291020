using System;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class Registered
    {
        public Registered() { }
        public Registered(string date, string age)
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
