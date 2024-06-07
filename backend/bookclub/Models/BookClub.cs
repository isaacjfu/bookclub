namespace Bookclub.Models;

public class BookClub
{
    public int Id {get; set;}
    public int BookId { get; set; }
    public int ClubId { get; set; }
    public Book Book { get; set; }
    public Club Club { get; set; }
    public ICollection<Comment> Comments {get; set;}
}