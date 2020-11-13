using API.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Service
{
    /// <summary>
    /// Juntos Somos Mais Integration Service
    /// </summary>
    public interface IJuntosSomosMaisService : IHealthCheck
    {
        /// <summary>
        /// Get Users from JSM as Json
        /// </summary>
        /// <returns>List of Users</returns>
        Task<IEnumerable<UserInput>> GetJson();

        /// <summary>
        /// Get Users from JSM as Csv
        /// </summary>
        /// <returns>List of Users</returns>
        Task<IEnumerable<UserInput>> GetCSV();
    }
}
