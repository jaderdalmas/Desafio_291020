using API.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;
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
        /// Get Users
        /// </summary>
        IEnumerable<UserOutput> GetAll();

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="user">User to be added</param>
        void Add(UserOutput user);

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
