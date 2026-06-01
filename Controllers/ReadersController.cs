using LinuxAdminExamApi.Data;
using LinuxAdminExamApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinuxAdminExamApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReadersController : ControllerBase
{
    private readonly InMemoryStore _store;

    public ReadersController(InMemoryStore store)
    {
        _store = store;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Reader>> GetAll()
    {
        return Ok(_store.Readers);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Reader> GetById(int id)
    {
        var reader = _store.Readers.FirstOrDefault(item => item.Id == id);

        if (reader is null)
        {
            return NotFound(new { message = $"Reader with id={id} was not found" });
        }

        return Ok(reader);
    }

    [HttpPost]
    public ActionResult<Reader> Create(Reader reader)
    {
        reader.Id = _store.GetNextReaderId();
        _store.Readers.Add(reader);

        return CreatedAtAction(nameof(GetById), new { id = reader.Id }, reader);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Reader updatedReader)
    {
        var reader = _store.Readers.FirstOrDefault(item => item.Id == id);

        if (reader is null)
        {
            return NotFound(new { message = $"Reader with id={id} was not found" });
        }

        reader.FullName = updatedReader.FullName;
        reader.GroupName = updatedReader.GroupName;
        reader.Email = updatedReader.Email;

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var reader = _store.Readers.FirstOrDefault(item => item.Id == id);

        if (reader is null)
        {
            return NotFound(new { message = $"Reader with id={id} was not found" });
        }

        _store.Readers.Remove(reader);
        return NoContent();
    }
}
