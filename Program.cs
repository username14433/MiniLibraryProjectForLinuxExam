using LinuxAdminExamApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:5050");

builder.Services.AddControllers();
builder.Services.AddSingleton<InMemoryStore>();

var app = builder.Build();

app.MapControllers();

app.Run();
