using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace API.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserRepository _insumos;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Log</param>
        /// <param name="users">User Repository</param>
        public UsersController(ILogger<UsersController> logger, IUserRepository users)
        {
            _logger = logger;

            _insumos = users;
        }

        /// <summary>
        /// Get filtered users with pagination
        /// Data is on object, not on headers
        /// </summary>
        /// <param name="region">Region Filter</param>
        /// <param name="classification">Classification Filter</param>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>List of Users</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserResponse))]
        public UserResponse Get(string region, EClassification classification, int pageNumber = 0, int pageSize = 50)
        {
            return new UserResponse(_insumos.GetUsers(region, classification), pageNumber, pageSize);
        }

        /// <summary>
        /// Post a list of users
        /// Data is on object, not on headers
        /// </summary>
        /// <param name="insumos"></param>
        /// <returns>false on some error</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        public bool Post(IEnumerable<UserInput> insumos)
        {
            var result = new List<bool>();
            foreach (var insumo in insumos.AsParallel())
                result.Add(_insumos.Add(insumo));

            return result.All(x => x);
        }
    }
}
