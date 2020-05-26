using System.Threading.Tasks;
using Al_Delal.Api.Models;

namespace Al_Delal.Api.Repositories.Auth
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);
    }
}