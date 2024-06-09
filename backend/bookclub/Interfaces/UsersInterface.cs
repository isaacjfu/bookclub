using Bookclub.Models;

namespace Bookclub.Interfaces;

public interface IUsersRepository
{
    IEnumerable<User> GetUsers();
    User GetUserById(int userId);
    void InsertUser(User user);
    void DeleteUser(int userId);
    void UpdateUser(User user);
    void Save();
}
