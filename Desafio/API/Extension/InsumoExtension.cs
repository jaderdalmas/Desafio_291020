using API.Models;
using System.Collections.Generic;
using System.Linq;

namespace API.Extension
{
    public static class InsumoExtension
    {
        public static IEnumerable<InsumoInput> GetInputs(this IEnumerable<string> list)
        {
            IList<InsumoInput> result = new List<InsumoInput>();
            if (!list.Any())
                return result;

            list = list.Where(x => !string.IsNullOrWhiteSpace(x));
            for (int i = 1; i < list.Count(); i++)
            {
                AddInput(ref result, list.ElementAt(0), list.ElementAt(i));
            }

            return result;
        }

        private static void AddInput(ref IList<InsumoInput> list, string header, string item)
        {
            var headers = header.Split("\",").Select(x => x.Replace("\"", string.Empty));
            var itens = item.Split("\",").Select(x => x.Replace("\"", string.Empty));

            var dic = new Dictionary<string, string>();
            for (int i = 0; i < headers.Count(); i++)
                dic.Add(headers.ElementAt(i), itens.ElementAt(i));

            var input = new InsumoInput(dic["gender"], dic["email"], dic["phone"], dic["cell"])
            {
                Name = new Name(dic["name__title"], dic["name__first"], dic["name__last"]),
                Location = new Location(string.Empty, dic["location__street"], dic["location__city"], dic["location__state"], dic["location__postcode"])
                {
                    Coordinates = new Coordinates(dic["location__coordinates__latitude"], dic["location__coordinates__longitude"]),
                    Timezone = new Timezone(dic["location__timezone__offset"], dic["location__timezone__description"])
                },
                Dob = new Dob(dic["dob__date"], dic["dob__age"]),
                Registered = new Registered(dic["registered__date"], dic["registered__age"]),
                Picture = new Picture(dic["picture__large"], dic["picture__medium"], dic["picture__thumbnail"])
            };

            list.Add(input);
        }
    }
}
