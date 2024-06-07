using Bookclub.Models;

namespace Bookclub.Interfaces;

public interface IBooksRepository
{
    IEnumerable<Book> GetBooks();
    Book GetBookById(int bookId);
    void InsertBook(Book book);
    void DeleteBook(int bookId);
    void UpdateBook(Book book);
    void Save();
}
