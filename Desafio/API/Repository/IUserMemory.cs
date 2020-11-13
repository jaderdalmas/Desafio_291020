using Microsoft.Extensions.Hosting;

namespace API.Repository
{
    /// <summary>
    /// User Memmory Interface
    /// </summary>
    public interface IUserMemory : IUserRepository, IHostedService { }
}
