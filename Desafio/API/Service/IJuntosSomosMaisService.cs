using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Service
{
    /// <summary>
    /// Juntos Somos Mais Integration Service
    /// </summary>
    public interface IJuntosSomosMaisService
    {
        /// <summary>
        /// Users list
        /// </summary>
        List<UserOutput> Users { get; set; }

        /// <summary>
        /// Get Insumos from JSM as Json
        /// </summary>
        /// <returns>List of Insumos</returns>
        Task<IEnumerable<UserInput>> GetJson();

        /// <summary>
        /// Get Insumos from JSM as Csv
        /// </summary>
        /// <returns>List of Insumos</returns>
        Task<IEnumerable<UserInput>> GetCSV();
    }
}
