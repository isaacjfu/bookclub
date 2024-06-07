using Microsoft.EntityFrameworkCore;
using Bookclub.Models;
namespace Bookclub.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
            
    }

    public DbSet<Book> Books {get; set;}
    public DbSet<Club> Clubs {get; set;}
    public DbSet<Comment> Comments {get; set;}
    public DbSet<User> Users {get; set;}
    public DbSet<BookClub> BookClubs {get; set;}
    public DbSet<UserClub> UserClubs {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}