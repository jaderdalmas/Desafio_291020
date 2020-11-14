using API.Models;

namespace API.Repository
{
    /// <summary>
    /// Authentication Repository Interface
    /// </summary>
    public interface IAuthRepository
    {
        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="username">User Name</param>
        /// <param name="password">Password</param>
        /// <returns>Authenticated User</returns>
        Authenticate Authenticate(string username, string password);
    }
}
