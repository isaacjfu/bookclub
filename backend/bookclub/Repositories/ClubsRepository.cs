using Bookclub.Interfaces;
using Bookclub.Models;
using Bookclub.Data;
using System.Threading.Tasks;
namespace Bookclub.Repositories;

public class ClubsRepository : IClubsRepository
{
    private DataContext context;
    public ClubsRepository(DataContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Club>> GetClubs()
    {
        return context.Clubs.ToList();
    }
    public async Task<Club> GetClubById(int clubId)
    {
        return context.Clubs.Find(clubId);
    }
    public async Task InsertClub(Club club)
    {
        context.Clubs.Add(club);
    }
    public async Task DeleteClub(int clubId)
    {
        Club b = context.Clubs.Find(clubId);
        context.Clubs.Remove(b);
    }
    public async Task UpdateClub(Club club)
    {
        // context.Entry(user).State = EntityState.Modified;
    }
    public async Task Save()
    {
        context.SaveChanges();    
    }

    
}