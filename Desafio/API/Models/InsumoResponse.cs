using System.Collections.Generic;
using System.Linq;

namespace API.Models
{
    public class InsumoResponse
    {
        public InsumoResponse(IEnumerable<InsumoOutput> list, int number, int size)
        {
            PageNumber = number;
            PageSize = size;
            TotalCount = list.Count();

            Users = list.Skip(number * size).Take(size);
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<InsumoOutput> Users { get; set; }
    }
}