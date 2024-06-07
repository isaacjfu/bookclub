namespace Bookclub.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<UserClub> UserClubs { get; set; }
}