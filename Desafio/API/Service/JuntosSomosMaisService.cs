using API.Extension;
using API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace API.Service
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class JuntosSomosMaisService : IJuntosSomosMaisService
    {
        private string Url => _config["JSM:JsonCsv_Repos"];

        private readonly IConfiguration _config;
        private readonly HttpClient _client;

        public JuntosSomosMaisService(IConfiguration configuration, HttpClient client)
        {
            _config = configuration;
            _client = client;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            if (_config == null)
                return HealthCheckResult.Unhealthy("No Config");
            if (_client == null)
                return HealthCheckResult.Unhealthy("No Client");

            var response = await _client.GetAsync(Url).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                return HealthCheckResult.Unhealthy("JSM is not available");

            return HealthCheckResult.Healthy(nameof(JuntosSomosMaisService));
        }

        public async Task<IEnumerable<UserInput>> GetJson()
        {
            var result = await Get("input-backend.json").ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(result))
                return new List<UserInput>();

            var users = JsonSerializer.Deserialize<User>(result);
            return users.Results;
        }

        public async Task<IEnumerable<UserInput>> GetCSV()
        {
            var result = await Get("input-backend.csv").ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(result))
                return new List<UserInput>();

            return result.Split("\r\n").GetInputs();
        }

        private async Task<string> Get(string url)
        {
            var response = await _client.GetAsync($"{Url}/{url}").ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                return string.Empty;

            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (string.IsNullOrEmpty(result)) return string.Empty;

            return result;
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
