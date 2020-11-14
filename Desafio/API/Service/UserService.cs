using API.Models;
using API.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class UserService : IUserService
    {
        private readonly IAuthRepository _authRepos;
        private readonly IUserRepository _userRepos;

        public UserService(IAuthRepository authRepos, IUserRepository userRepos)
        {
            _authRepos = authRepos;
            _userRepos = userRepos;
        }

        public bool Add(IEnumerable<UserInput> users)
        {
            if (users?.Any() != true)
                return false;

            var result = new List<bool>();
            foreach (var user in users.AsParallel())
                result.Add(Add(user?.GetOutput()));

            return result.All(x => x);
        }

        public async Task<Authenticate> Authenticate(string userName, string password) => await Task.FromResult(_authRepos.Authenticate(userName, password));

        public bool Add(UserOutput user) => _userRepos.Add(user);

        public IEnumerable<UserOutput> GetUsers(string region, EClassification classification) => _userRepos.GetUsers(region, classification);
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
