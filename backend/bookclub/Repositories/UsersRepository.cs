using Bookclub.Interfaces;
using Bookclub.Models;
using Bookclub.Data;

namespace Bookclub.Repositories;

public class UsersRepository : IUsersRepository
{
    private DataContext context;
    public UsersRepository(DataContext context)
    {
        this.context = context;
    }

    public IEnumerable<User> GetUsers()
    {
        return context.Users.ToList();
    }
    public User GetUserById(int userId)
    {
        return context.Users.Find(userId);
    }
    public void InsertUser(User user)
    {
        context.Users.Add(user);
    }
    public void DeleteUser(int userId)
    {
        User b = context.Users.Find(userId);
        context.Users.Remove(b);
    }
    public void UpdateUser(User user)
    {
        // context.Entry(user).State = EntityState.Modified;
    }
    public void Save()
    {
        context.SaveChanges();    
    }

    
}