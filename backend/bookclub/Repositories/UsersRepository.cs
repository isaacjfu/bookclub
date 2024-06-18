using Bookclub.Interfaces;
using Bookclub.Models;
using Bookclub.Data;
using System.Threading.Tasks;
namespace Bookclub.Repositories;

public class UsersRepository : IUsersRepository
{
    private DataContext context;
    public UsersRepository(DataContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return context.Users.ToList();
    }
    public async Task<User> GetUserById(int userId)
    {
        return context.Users.Find(userId);
    }
    public async Task InsertUser(User user)
    {
        context.Users.Add(user);
    }
    public async Task DeleteUser(int userId)
    {
        User b = context.Users.Find(userId);
        context.Users.Remove(b);
    }
    public async Task UpdateUser(User user)
    {
        // context.Entry(user).State = EntityState.Modified;
    }
    public async Task Save()
    {
        context.SaveChanges();    
    }

    
}