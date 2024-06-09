using Bookclub.Models;

namespace Bookclub.Interfaces;

public interface IClubsRepository
{
    IEnumerable<Club> GetClubs();
    Club GetClubById(int clubId);
    void InsertClub(Club club);
    void DeleteClub(int clubId);
    void UpdateClub(Club club);
    void Save();
}
