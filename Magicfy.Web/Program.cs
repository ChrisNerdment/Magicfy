var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World from Magicfy.Web Version 2!");

app.MapGet("/api/hello", () => new { Message = "Hello World!", Application = "Magicfy.Web", Timestamp = DateTime.Now });

app.Run();
