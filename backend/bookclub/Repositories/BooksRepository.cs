using Bookclub.Interfaces;
using Bookclub.Models;
using Bookclub.Data;
using System.Threading.Tasks;

namespace Bookclub.Repositories;

public class BooksRepository : IBooksRepository
{
    private DataContext context;
    public BooksRepository(DataContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Book>> GetBooks()
    {
        return context.Books.ToList();
    }
    public async Task<Book> GetBookById(int bookId)
    {
        return context.Books.Find(bookId);
    }
    public async Task InsertBook(Book book)
    {
        context.Books.Add(book);
    }
    public async Task DeleteBook(int bookId)
    {
        Book b = context.Books.Find(bookId);
        context.Books.Remove(b);
    }
    public async Task UpdateBook(Book book)
    {
        // context.Entry(book).State = EntityState.Modified;
    }
    public async Task Save()
    {
        context.SaveChanges();    
    }

    
}