using Bookclub.Interfaces;
using Bookclub.Models;
using Bookclub.Data;

namespace Bookclub.Repositories;

public class BooksRepository : IBooksRepository
{
    private DataContext context;
    public BooksRepository(DataContext context)
    {
        this.context = context;
    }

    public IEnumerable<Book> GetBooks()
    {
        return context.Books.ToList();
    }
    public Book GetBookById(int bookId)
    {
        return context.Books.Find(bookId);
    }
    public void InsertBook(Book book)
    {
        context.Books.Add(book);
    }
    public void DeleteBook(int bookId)
    {
        Book b = context.Books.Find(bookId);
        context.Books.Remove(b);
    }
    public void UpdateBook(Book book)
    {
        // context.Entry(book).State = EntityState.Modified;
    }
    public void Save()
    {
        context.SaveChanges();    
    }

    
}