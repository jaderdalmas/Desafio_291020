using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Repository
{
    public class InsumoRepository : IInsumoRepository
    {
        private List<InsumoOutput> _list;

        public InsumoRepository()
        {
            _list = new List<InsumoOutput>();
        }

        public bool Add(InsumoInput insumo) => Add(insumo.GetOutput());
        public bool Add(InsumoOutput insumo)
        {
            _list.Add(insumo);

            return true;
        }

        public IEnumerable<InsumoOutput> GetInsumos(string region, EClassification classification)
        {
            return _list.Where(x => x.Location?.Region == region
            && x.Type == classification.ToString());
        }
    }
}
