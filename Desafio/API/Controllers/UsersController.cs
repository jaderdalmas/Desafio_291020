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
        /// <param name="r">user request Filter</param>
        /// <returns>List of Users</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserResponse))]
        public UserResponse Post(UserRequest r) => new UserResponse(_userService.GetUsers(r.Region, r.Classification), r.PageNumber, r.PageSize);

        /// <summary>
        /// Post a list of users
        /// Data is on object, not on headers
        /// </summary>
        /// <param name="users"></param>
        /// <returns>false on some error</returns>
        [HttpPost("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        public bool Add(IEnumerable<UserInput> users) => _userService.Add(users);
    }
}
