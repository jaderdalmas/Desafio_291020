using System.Text.Json.Serialization;

namespace IntegrationTest.Model
{
    public class BadRequestMessage
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
