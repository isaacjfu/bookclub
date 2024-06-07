namespace Bookclub.Models;

public class UserClub
{
    public int Id {get; set;}
    public int UserId { get; set; } 
    public int ClubId { get; set; }
    public User User { get; set; }  
    public Club Club { get; set; }
    
}