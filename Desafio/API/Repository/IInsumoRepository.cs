using API.Models;
using System.Collections.Generic;

namespace API.Repository
{
    public interface IInsumoRepository
    {
        /// <summary>
        /// Get Insumos by region and classification
        /// </summary>
        /// <param name="region">Country Region</param>
        /// <param name="classification">Location Classification</param>
        /// <returns>List of Insumos</returns>
        IEnumerable<InsumoOutput> GetInsumos(string region, EClassification classification);

        /// <summary>
        /// Add Insumo
        /// </summary>
        /// <param name="insumo">insumo</param>
        /// <returns>true if ok</returns>
        bool Add(InsumoInput insumo);

        /// <summary>
        /// Add Insumo
        /// </summary>
        /// <param name="insumo">insumo</param>
        /// <returns>true if ok</returns>
        bool Add(InsumoOutput insumo);
    }
}
