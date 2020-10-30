using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsumoController : ControllerBase
    {
        private readonly ILogger<InsumoController> _logger;
        private readonly IInsumoRepository _insumos;

        public InsumoController(ILogger<InsumoController> logger, IInsumoRepository insumos)
        {
            _logger = logger;

            _insumos = insumos;
        }

        [HttpGet]
        public InsumoResponse Get(string region, EClassification classification, int pageNumber = 0, int pageSize = 50)
        {
            return new InsumoResponse(_insumos.GetInsumos(region, classification), pageNumber, pageSize);
        }

        [HttpPost]
        public bool Post(IEnumerable<InsumoInput> insumos)
        {
            var result = new List<bool>();
            foreach (var insumo in insumos.AsParallel())
                result.Add(_insumos.Add(insumo));

            return result.All(x => x);
        }
    }
}
