using System.Collections.Generic;
using System.Threading.Tasks;
using Al_Delal.Api.Models;

namespace Al_Delal.Api.Repositories.Users
{
    public interface IUsersRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}