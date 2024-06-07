using Microsoft.AspNetCore.Mvc;
using Bookclub.Repositories;
using Bookclub.Interfaces;
using Bookclub.Models;

namespace Bookclub.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class BooksController: ControllerBase 
{
    private IBooksRepository booksRepository;
    public BooksController(IBooksRepository booksRepository)
    {
        this.booksRepository = booksRepository;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        var books = booksRepository.GetBooks();
        return Ok(books);
    }
    [HttpGet("{Id}")]
    public IActionResult GetBookById(int Id)
    {
        var book = booksRepository.GetBookById(Id);
        return Ok(book);
    }
    [HttpPost]
    public IActionResult CreateBook(Book book)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        booksRepository.InsertBook(book);
        return CreatedAtAction(nameof(GetBookById), new { id = book.Id}, book);
    }
    [HttpDelete("{Id}")]
    public IActionResult DeleteBook(int Id)
    {
        var book = booksRepository.GetBookById(Id);
        if( book == null)
        {
            return NotFound();
        }
        booksRepository.DeleteBook(Id);
        return NoContent();
    }
    [HttpPut("{Id}")]
    public IActionResult UpdateBook(int Id, Book book)
    {
        if( Id != book.Id)
        {
            return BadRequest();
        }
        if( !ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        booksRepository.UpdateBook(book);
        return NoContent();
    }
}