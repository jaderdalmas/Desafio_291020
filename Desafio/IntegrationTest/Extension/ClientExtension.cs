using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace API.Extension
{
    /// <summary>
    /// Object Extension
    /// </summary>
    public static class ClientExtension
    {
        /// <summary>
        /// Add Authorization Header
        /// </summary>
        /// <param name="client">Client</param>
        /// <returns>Client</returns>
        public static HttpClient AddAuthHeader(this HttpClient client)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthenticationSchemes.Basic.ToString(), Convert.ToBase64String(Encoding.UTF8.GetBytes($"test:test")));

            return client;
        }

    }
}
