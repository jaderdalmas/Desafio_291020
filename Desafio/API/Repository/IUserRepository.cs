using API.Models;
using System.Collections.Generic;

namespace API.Repository
{
    /// <summary>
    /// User Repository Interface
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Get Users by region and classification
        /// </summary>
        /// <param name="region">Country Region</param>
        /// <param name="classification">Location Classification</param>
        /// <returns>List of Users</returns>
        IEnumerable<UserOutput> GetUsers(string region, EClassification classification);

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>true if ok</returns>
        bool Add(UserInput user);

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>true if ok</returns>
        bool Add(UserOutput user);
    }
}
