using API.Models;
using API.Service;
using System.Collections.Generic;
using System.Linq;

namespace API.Repository
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class UserRepository : IUserRepository
    {
        private readonly IJuntosSomosMaisService _jsm;

        public UserRepository(IJuntosSomosMaisService jsm)
        {
            _jsm = jsm;
        }

        public bool Add(UserOutput user)
        {
            if (user == null)
                return false;

            _jsm.Users.Add(user);

            return true;
        }

        public IEnumerable<UserOutput> GetUsers(string region, EClassification classification)
        {
            return _jsm.Users.Where(x => x.Location?.Region == region
            && x.Type == classification.ToString());
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}