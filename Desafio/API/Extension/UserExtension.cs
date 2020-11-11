using API.Models;
using System.Collections.Generic;
using System.Linq;

namespace API.Extension
{
    /// <summary>
    /// User Extension
    /// </summary>
    public static class UserExtension
    {
        /// <summary>
        /// Get User Inputs as List
        /// </summary>
        /// <param name="list">list of strings (users)</param>
        /// <returns>List of Users</returns>
        public static IEnumerable<UserInput> GetInputs(this IEnumerable<string> list)
        {
            IList<UserInput> result = new List<UserInput>();
            list = list?.Where(x => !string.IsNullOrWhiteSpace(x));
            if (list?.Any() != true)
                return result;

            var header = list.ElementAt(0).Split("\",").Select(x => x.Replace("\"", string.Empty));
            for (int i = 1; i < list.Count(); i++)
            {
                AddInput(ref result, header, list.ElementAt(i));
            }

            return result;
        }

        /// <summary>
        /// Add user into the list
        /// </summary>
        /// <param name="list">List of users</param>
        /// <param name="headers">headers</param>
        /// <param name="item">string user</param>
        private static void AddInput(ref IList<UserInput> list, IEnumerable<string> headers, string item)
        {
            var itens = item.Split("\",").Select(x => x.Replace("\"", string.Empty));

            var dic = new Dictionary<string, string>();
            for (int i = 0; i < headers.Count(); i++)
                dic.Add(headers.ElementAt(i), itens.ElementAt(i));

            var input = new UserInput(dic["gender"], dic["email"], dic["phone"], dic["cell"])
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
