﻿using API.Models;
using API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace API.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    [Authorize, ApiController]
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
        public IActionResult Get(
            [Required, MinLength(1)] string region,
            EClassification classification,
            [Range(0, int.MaxValue)] int pageNumber = 0,
            [Range(0, 1000)] int pageSize = 50)
        {
            return Ok(new UserResponse(_userService.GetUsers(region, classification), pageNumber, pageSize));
        }

        /// <summary>
        /// Post a list of users
        /// </summary>
        /// <param name="users"></param>
        /// <returns>false on some error</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        public IActionResult Post(IEnumerable<UserInput> users) => Ok(_userService.Add(users));
    }
}
