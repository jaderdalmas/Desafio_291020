using API.Models;
using System.Collections.Generic;

namespace API.Service
{
    /// <summary>
    /// User Service
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Get Users by region and classification
        /// </summary>
        /// <param name="region">Country Region</param>
        /// <param name="classification">Location Classification</param>
        /// <returns>List of Users</returns>
        IEnumerable<UserOutput> GetUsers(string region, EClassification classification);

        /// <summary>
        /// Add Users
        /// </summary>
        /// <param name="users">input users</param>
        /// <returns>true if ok</returns>
        bool Add(IEnumerable<UserInput> users);

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>true if ok</returns>
        bool Add(UserOutput user);
    }
}
