using System.Collections.Generic;

namespace API.Extension
{
    public static class RegionExtension
    {
        private static readonly Dictionary<string, string> regions = new Dictionary<string, string>()
        {
            {  "acre", "Norte" },
            {  "amapá", "Norte"  },
            {  "amazonas", "Norte"  },
            {  "pará", "Norte"  },
            {  "rondônia", "Norte"  },
            {  "roraima", "Norte"  },
            {  "tocantins", "Norte"  },

            {  "alagoas", "Nordeste"  },
            {  "bahia", "Nordeste"  },
            {  "ceará", "Nordeste"  },
            {  "maranhão", "Nordeste"  },
            {  "paraíba", "Nordeste"  },
            {  "pernambuco", "Nordeste"  },
            {  "piauí", "Nordeste"  },
            {  "rio grande do norte", "Nordeste"  },
            {  "sergipe", "Nordeste"  },

            {  "goiás", "Centro-Oeste"  },
            {  "mato grosso", "Centro-Oeste"  },
            {  "mato grosso do sul", "Centro-Oeste"  },
            {  "distrito federal", "Centro-Oeste"  },

            {  "espírito santo", "Sudeste"  },
            {  "minas gerais", "Sudeste"  },
            {  "são paulo", "Sudeste"  },
            {  "rio de janeiro", "Sudeste"  },

            {  "paraná", "Sul"  },
            {  "rio grande do sul", "Sul"  },
            {  "santa catarina", "Sul"  }
        };

        public static string Region(this string state)
        {
            if (string.IsNullOrWhiteSpace(state) || !regions.ContainsKey(state.ToLower()))
                return string.Empty;

            return regions[state.ToLower()];
        }
    }
}
