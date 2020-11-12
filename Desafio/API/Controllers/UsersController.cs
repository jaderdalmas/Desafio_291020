using API.Models;
using API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Log</param>
        /// <param name="userService">User Service</param>
        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;

            _userService = userService;
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
        public UserResponse Get(string region, EClassification classification, int pageNumber = 0, int pageSize = 50) => new UserResponse(_userService.GetUsers(region, classification), pageNumber, pageSize);

        /// <summary>
        /// Post a list of users
        /// Data is on object, not on headers
        /// </summary>
        /// <param name="users"></param>
        /// <returns>false on some error</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        public bool Post(IEnumerable<UserInput> users) => _userService.Add(users);
    }
}
