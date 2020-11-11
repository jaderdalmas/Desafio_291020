using API.Extension;
using API.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Service
{
    public class JuntosSomosMaisService : IJuntosSomosMaisService
    {
        string Url => "https://storage.googleapis.com/juntossomosmais-code-challenge";
        HttpClient _client;

        public JuntosSomosMaisService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<UserInput>> GetJson()
        {
            var response = await _client.GetAsync($"{Url}/input-backend.json").ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                return new List<UserInput>();

            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (string.IsNullOrEmpty(result)) return new List<UserInput>();

            var insumos = JsonSerializer.Deserialize<User>(result);
            return insumos.Results;
        }

        public async Task<IEnumerable<UserInput>> GetCSV()
        {
            var response = await _client.GetAsync($"{Url}/input-backend.csv").ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                return new List<UserInput>();

            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(result)) return new List<UserInput>();

            return result.Split("\r\n").GetInputs();
        }
    }
}
