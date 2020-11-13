using API.Models;
using API.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Repository
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class UserMemory : IUserMemory
    {
        private readonly IJuntosSomosMaisService _jsm;

        private readonly List<UserOutput> _users;

        public UserMemory(IJuntosSomosMaisService jsm)
        {
            _jsm = jsm;

            _users = new List<UserOutput>();
        }

        public bool Add(UserOutput user)
        {
            if (user == null || _users == null)
                return false;

            _users.Add(user);
            return true;
        }

        public IEnumerable<UserOutput> GetUsers(string region, EClassification classification)
        {
            return _users?.Where(x => x.Location?.Region == region && x.Type == classification.ToString()) ?? new List<UserOutput>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var tasks = new List<Task<IEnumerable<UserInput>>>
            {
                _jsm.GetJson(),
                _jsm.GetCSV()
            };
            Task.WaitAll(tasks.ToArray(), cancellationToken);

            foreach (var input in tasks[0].Result.Concat(tasks[1].Result).AsParallel())
                Add(input.GetOutput());

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _users.Clear();
            return Task.CompletedTask;
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}