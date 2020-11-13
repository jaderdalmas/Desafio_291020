using API.Models;
using API.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService">User Service</param>
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get filtered users with pagination
        /// Response data is on object, not on headers
        /// </summary>
        /// <param name="region">region</param>
        /// <param name="classification">classification</param>
        /// <param name="pageNumber">page Number</param>
        /// <param name="pageSize">page Size</param>
        /// <returns>List of Users</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserResponse))]
        public UserResponse Get(
            [Required, MinLength(1)] string region,
            EClassification classification,
            [Range(0, int.MaxValue)] int pageNumber = 0,
            [Range(0, 1000)] int pageSize = 50)
        {
            return new UserResponse(_userService.GetUsers(region, classification), pageNumber, pageSize);
        }

        /// <summary>
        /// Post a list of users
        /// </summary>
        /// <param name="users"></param>
        /// <returns>false on some error</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        public bool Post(IEnumerable<UserInput> users) => _userService.Add(users);
    }
}
