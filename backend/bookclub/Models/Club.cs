namespace Bookclub.Models;

public class Club
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<BookClub> BookClubs { get; set; }

    public ICollection<UserClub> UserClubs { get; set; }
}