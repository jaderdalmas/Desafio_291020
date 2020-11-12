﻿using API.Extension;
using API.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Service
{
    /// <summary>
    /// Juntos Somos Mais Integration Service
    /// </summary>
    public class JuntosSomosMaisService : IJuntosSomosMaisService
    {
        private string Url => _config["JSM:JsonCsv_Repos"];
        private readonly IConfiguration _config;
        private readonly HttpClient _client;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">App configuration</param>
        /// <param name="client">Client to make integration calls</param>
        public JuntosSomosMaisService(IConfiguration configuration, HttpClient client)
        {
            _config = configuration;
            _client = client;
        }

        /// <summary>
        /// Get Json Data
        /// </summary>
        /// <returns>list of users</returns>
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

        /// <summary>
        /// Get Csv Data
        /// </summary>
        /// <returns>list of users</returns>
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
