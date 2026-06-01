using LinuxAdminExamApi.Models;

namespace LinuxAdminExamApi.Data;

public class InMemoryStore
{
    private int _nextBookId = 4;
    private int _nextReaderId = 4;

    public List<Book> Books { get; } = new()
    {
        new Book { Id = 1, Title = "Linux Basics", Author = "Admin Manual", Year = 2021, IsAvailable = true },
        new Book { Id = 2, Title = "ASP.NET Core API", Author = "Microsoft Guide", Year = 2022, IsAvailable = true },
        new Book { Id = 3, Title = "Nginx Reverse Proxy", Author = "DevOps Notes", Year = 2020, IsAvailable = false }
    };

    public List<Reader> Readers { get; } = new()
    {
        new Reader { Id = 1, FullName = "Ivan Petrov", GroupName = "IS-21", Email = "ivan@example.com" },
        new Reader { Id = 2, FullName = "Anna Smirnova", GroupName = "IS-22", Email = "anna@example.com" },
        new Reader { Id = 3, FullName = "Pavel Sokolov", GroupName = "IS-21", Email = "pavel@example.com" }
    };

    public int GetNextBookId()
    {
        return _nextBookId++;
    }

    public int GetNextReaderId()
    {
        return _nextReaderId++;
    }
}
