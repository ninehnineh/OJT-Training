using SuperHeroAPI.Models;
using SuperHeroAPI.Services;

namespace SuperHeroAPI.Repository
{
    public interface IAuthServices
    {
        Task<ServiceResponses<int>> Register(User user, string password);
        Task<ServiceResponses<string>> Login(string username, string password);
        Task<bool> UserExists(string username);

    }
}
