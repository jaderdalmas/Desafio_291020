using API.Models;
using System.Threading.Tasks;

namespace API.Service
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="password">password</param>
        /// <returns>Authenticated user</returns>
        Task<Authenticate> Authenticate(string name, string password);
    }
}
