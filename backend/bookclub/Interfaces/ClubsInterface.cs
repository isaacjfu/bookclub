using Bookclub.Models;
using System.Threading.Tasks;
namespace Bookclub.Interfaces;

public interface IClubsRepository
{
    Task<IEnumerable<Club>> GetClubs();
    Task<Club> GetClubById(int clubId);
    Task InsertClub(Club club);
    Task DeleteClub(int clubId);
    Task UpdateClub(Club club);
    Task Save();
}
