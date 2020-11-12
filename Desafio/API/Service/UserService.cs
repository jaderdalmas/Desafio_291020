using API.Models;
using API.Repository;
using System.Collections.Generic;
using System.Linq;

namespace API.Service
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepos;

        public UserService(IUserRepository userRepos)
        {
            _userRepos = userRepos;
        }

        public bool Add(IEnumerable<UserInput> users)
        {
            var result = new List<bool>();
            foreach (var user in users.AsParallel())
                result.Add(Add(user?.GetOutput()));

            return result.All(x => x);
        }

        public bool Add(UserOutput user) => _userRepos.Add(user);

        public IEnumerable<UserOutput> GetUsers(string region, EClassification classification) => _userRepos.GetUsers(region, classification);
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
