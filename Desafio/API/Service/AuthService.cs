using API.Models;
using API.Repository;
using System.Threading.Tasks;

namespace API.Service
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepos;

        public AuthService(IAuthRepository authRepos)
        {
            _authRepos = authRepos;
        }

        public async Task<Authenticate> Authenticate(string userName, string password) => await Task.FromResult(_authRepos.Authenticate(userName, password));
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
