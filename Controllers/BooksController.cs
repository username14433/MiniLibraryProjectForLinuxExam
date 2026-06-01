using LinuxAdminExamApi.Data;
using LinuxAdminExamApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinuxAdminExamApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly InMemoryStore _store;

    public BooksController(InMemoryStore store)
    {
        _store = store;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetAll()
    {
        return Ok(_store.Books);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Book> GetById(int id)
    {
        var book = _store.Books.FirstOrDefault(item => item.Id == id);

        if (book is null)
        {
            return NotFound(new { message = $"Book with id={id} was not found" });
        }

        return Ok(book);
    }

    [HttpPost]
    public ActionResult<Book> Create(Book book)
    {
        book.Id = _store.GetNextBookId();
        _store.Books.Add(book);

        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Book updatedBook)
    {
        var book = _store.Books.FirstOrDefault(item => item.Id == id);

        if (book is null)
        {
            return NotFound(new { message = $"Book with id={id} was not found" });
        }

        book.Title = updatedBook.Title;
        book.Author = updatedBook.Author;
        book.Year = updatedBook.Year;
        book.IsAvailable = updatedBook.IsAvailable;

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var book = _store.Books.FirstOrDefault(item => item.Id == id);

        if (book is null)
        {
            return NotFound(new { message = $"Book with id={id} was not found" });
        }

        _store.Books.Remove(book);
        return NoContent();
    }
}
