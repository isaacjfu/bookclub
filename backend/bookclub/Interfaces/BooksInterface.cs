using Bookclub.Models;
using System.Threading.Tasks;
namespace Bookclub.Interfaces;

public interface IBooksRepository
{
    Task<IEnumerable<Book>> GetBooks();
    Task<Book> GetBookById(int bookId);
    Task InsertBook(Book book);
    Task DeleteBook(int bookId);
    Task UpdateBook(Book book);
    Task Save();
}
