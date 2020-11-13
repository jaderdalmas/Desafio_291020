using API.Models;
using API.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Repository
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class UserRepository : IUserRepository
    {
        private readonly ILogger _logger;
        private readonly IJuntosSomosMaisService _jsm;

        public UserRepository(ILogger<UserRepository> logger, IJuntosSomosMaisService jsm)
        {
            _logger = logger;

            _jsm = jsm;
        }

        public bool Add(UserOutput user)
        {
            if (user == null)
                return false;

            try
            {
                _jsm.Add(user);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Cannot add user on JSM", user);
            }

            return false;
        }

        public IEnumerable<UserOutput> GetUsers(string region, EClassification classification)
        {
            IEnumerable<UserOutput> result = new List<UserOutput>();
            try
            {
                result = _jsm.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Cannot get user on JSM");
            }

            return result.Where(x => x.Location?.Region == region && x.Type == classification.ToString());
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}