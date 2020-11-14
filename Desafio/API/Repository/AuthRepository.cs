using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Repository
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class AuthRepository : IAuthRepository
    {
        private List<Authenticate> _users = new List<Authenticate>
        {
            new Authenticate { Id = Guid.NewGuid(), UserName = "test", Password = "test" }
        };

        public Authenticate Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.UserName == username && x.Password == password);

            if (user == null)
                return null;

            return user;
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
