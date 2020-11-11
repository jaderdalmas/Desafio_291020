using System.Collections.Generic;
using System.Linq;

namespace API.Models
{
    /// <summary>
    /// User response object with paging data
    /// </summary>
    public class UserResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="list">list of users</param>
        /// <param name="number">page number</param>
        /// <param name="size">page size</param>
        public UserResponse(IEnumerable<UserOutput> list, int number, int size)
        {
            PageNumber = number;
            PageSize = size;
            TotalCount = list.Count();

            Users = list.Skip(number * size).Take(size);
        }

        /// <summary>
        /// Page Number
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Page Size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Amount of users
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Pagged users
        /// </summary>
        public IEnumerable<UserOutput> Users { get; set; }
    }
}