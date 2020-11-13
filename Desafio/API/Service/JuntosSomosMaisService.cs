using API.Extension;
using API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ILogger _logger;
        private readonly HttpClient _client;

        private List<UserOutput> _users;

        public JuntosSomosMaisService(IConfiguration configuration, ILogger<JuntosSomosMaisService> logger, HttpClient client)
        {
            _logger = logger;
            _config = configuration;
            _client = client;

            Initialize();
        }

        private void Initialize()
        {
            _users = new List<UserOutput>();

            var tasks = new List<Task<IEnumerable<UserInput>>>
            {
                GetJson(),
                GetCSV()
            };
            Task.WaitAll(tasks.ToArray());

            foreach (var input in tasks[0].Result.Concat(tasks[1].Result).AsParallel())
                _users.Add(input.GetOutput());
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

        public IEnumerable<UserOutput> GetAll() => _users;
        public void Add(UserOutput user) => _users.Add(user);

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
            HttpResponseMessage response;
            try
            {
                response = await _client.GetAsync($"{Url}/{url}").ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Cannot access JSM");
                return string.Empty;
            }

            if (!response.IsSuccessStatusCode)
                return string.Empty;

            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (string.IsNullOrEmpty(result)) return string.Empty;

            return result;
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
