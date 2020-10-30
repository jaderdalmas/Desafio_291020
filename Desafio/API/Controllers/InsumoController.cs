using API.Models;
using API.Repository;
using API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsumoController : ControllerBase
    {
        private readonly ILogger<InsumoController> _logger;

        private readonly IJuntosSomosMaisService _jsm;
        private readonly IInsumoRepository _insumos;

        public InsumoController(ILogger<InsumoController> logger, IJuntosSomosMaisService jsm, IInsumoRepository insumos)
        {
            _logger = logger;

            _jsm = jsm;
            _insumos = insumos;

            Initialize();
        }

        private void Initialize()
        {
            var tasks = new List<Task<IEnumerable<InsumoInput>>>
            {
                _jsm.GetJson(),
                _jsm.GetCSV()
            };
            Task.WaitAll(tasks.ToArray());

            foreach (var input in tasks[0].Result.Concat(tasks[1].Result).AsParallel())
                _insumos.Add(input);
        }

        [HttpGet]
        public IEnumerable<InsumoOutput> Get(string region, EClassification classification)
        {
            return _insumos.GetInsumos(region, classification);
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
