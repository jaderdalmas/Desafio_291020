using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class Insumos
    {
        [JsonPropertyName("results")]
        public IEnumerable<InsumoInput> Results { get; set; }
    }
}
