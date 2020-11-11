using API.Models;
using API.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IJuntosSomosMaisService _jsm;

        private readonly List<UserOutput> _list;

        public UserRepository(IJuntosSomosMaisService jsm)
        {
            _jsm = jsm;

            _list = new List<UserOutput>();

            Initialize();
        }

        private void Initialize()
        {
            var tasks = new List<Task<IEnumerable<UserInput>>>
            {
                _jsm.GetJson(),
                _jsm.GetCSV()
            };
            Task.WaitAll(tasks.ToArray());

            foreach (var input in tasks[0].Result.Concat(tasks[1].Result).AsParallel())
                Add(input);
        }

        public bool Add(UserInput user) => Add(user?.GetOutput());
        public bool Add(UserOutput user)
        {
            if (user == null)
                return false;

            _list.Add(user);

            return true;
        }

        public IEnumerable<UserOutput> GetUsers(string region, EClassification classification)
        {
            return _list.Where(x => x.Location?.Region == region
            && x.Type == classification.ToString());
        }
    }
}
