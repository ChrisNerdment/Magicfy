using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    return new { message = "Hello World", version = "1.0", timestamp = DateTime.UtcNow };
});
app.MapGet("/status", () =>
{
    return new
    {
        version = "1.0",
        timestamp = DateTime.UtcNow,
        appId = Environment.GetEnvironmentVariable("BUNNYNET_MC_APPID"),
        podId = Environment.GetEnvironmentVariable("BUNNYNET_MC_PODID"),
        region = Environment.GetEnvironmentVariable("BUNNYNET_MC_REGION"),
        publicEndpoint = Environment.GetEnvironmentVariable("BUNNYNET_MC_PUBLIC_ENDPOINTS"),
        podip = Environment.GetEnvironmentVariable("BUNNYNET_MC_PODIP"),
        hostId = Environment.GetEnvironmentVariable("BUNNYNET_MC_HOSTIP"),
        zone = Environment.GetEnvironmentVariable("BUNNYNET_MC_ZONE")

    };
});


app.Run();
