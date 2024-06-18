using Bookclub.Models;
using System.Threading.Tasks;
namespace Bookclub.Interfaces;

public interface IUsersRepository
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUserById(int userId);
    Task InsertUser(User user);
    Task DeleteUser(int userId);
    Task UpdateUser(User user);
    Task Save();
}
