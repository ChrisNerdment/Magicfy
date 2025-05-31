using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    Debug.WriteLine("Hello World from Magicfy.Web Version 2!");
    Console.WriteLine("Hello World Console from Magicfy.Web Version 2!");
    return "Hello World from Magicfy.Web Version 2!";
});

app.MapGet("/api/hello", () => new { Message = "Hello World!", Application = "Magicfy.Web", Timestamp = DateTime.Now });

app.Run();
