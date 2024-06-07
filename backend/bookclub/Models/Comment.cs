namespace Bookclub.Models;
public class Comment
{
    public int Id { get; set; }
    
    public BookClub BookClub { get; set; }
}