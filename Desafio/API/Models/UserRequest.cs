using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models
{
    /// <summary>
    /// User response object with paging data
    /// </summary>
    public class UserRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserRequest()
        {
            PageNumber = 0;
            PageSize = 50;
        }

        /// <summary>
        /// Classification
        /// </summary>
        [JsonPropertyName("classification")]
        public EClassification Classification { get; set; }

        /// <summary>
        /// Region
        /// </summary>
        [JsonPropertyName("region")]
        [Required, MinLength(1)]
        public string Region { get; set; }

        /// <summary>
        /// Page Number
        /// </summary>
        [JsonPropertyName("pagenumber")]
        [Range(0, int.MaxValue)]
        public int PageNumber { get; set; } = 0;

        /// <summary>
        /// Page Size
        /// </summary>
        [JsonPropertyName("pagesize")]
        [Range(0, 1000)]
        public int PageSize { get; set; } = 50;
    }
}