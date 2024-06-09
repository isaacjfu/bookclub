using Bookclub.Interfaces;
using Bookclub.Models;
using Bookclub.Data;

namespace Bookclub.Repositories;

public class ClubsRepository : IClubsRepository
{
    private DataContext context;
    public ClubsRepository(DataContext context)
    {
        this.context = context;
    }

    public IEnumerable<Club> GetClubs()
    {
        return context.Clubs.ToList();
    }
    public Club GetClubById(int clubId)
    {
        return context.Clubs.Find(clubId);
    }
    public void InsertClub(Club club)
    {
        context.Clubs.Add(club);
    }
    public void DeleteClub(int clubId)
    {
        Club b = context.Clubs.Find(clubId);
        context.Clubs.Remove(b);
    }
    public void UpdateClub(Club club)
    {
        // context.Entry(user).State = EntityState.Modified;
    }
    public void Save()
    {
        context.SaveChanges();    
    }

    
}