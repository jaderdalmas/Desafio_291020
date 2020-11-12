using API.Extension;
using API.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Service
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class JuntosSomosMaisService : IJuntosSomosMaisService
    {
        private string Url => _config["JSM:JsonCsv_Repos"];

        private readonly IConfiguration _config;
        private readonly HttpClient _client;

        public List<UserOutput> Users { get; set; }

        public JuntosSomosMaisService(IConfiguration configuration, HttpClient client)
        {
            _config = configuration;
            _client = client;

            Initialize();
        }

        private void Initialize()
        {
            var tasks = new List<Task<IEnumerable<UserInput>>>
            {
                GetJson(),
                GetCSV()
            };
            Task.WaitAll(tasks.ToArray());

            foreach (var input in tasks[0].Result.Concat(tasks[1].Result).AsParallel())
                Users.Add(input.GetOutput());
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
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
