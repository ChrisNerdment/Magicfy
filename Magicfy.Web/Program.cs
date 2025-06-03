using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    return new { message = "Hello World", version = "1.0", timestamp = DateTime.UtcNow };
});

app.MapGet("/health", () =>
{
    return new
    {
        status = "Healthy",
        timestamp = DateTime.UtcNow,
        uptime = TimeSpan.FromMilliseconds(Environment.TickCount64),
        version = "1.0",
        environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"
    };
});



app.MapGet("/status", () =>
{
    var id = Ulid.NewUlid().ToString();
    return new
    {
        version = "1.0",
        timestamp = DateTime.UtcNow,
        id = id,
        partition = id[^1..],
        status = "OK",
        uptime = TimeSpan.FromMilliseconds(Environment.TickCount64),
        processId = Process.GetCurrentProcess().Id,
        processName = Process.GetCurrentProcess().ProcessName,
        machineName = Environment.MachineName,
        osVersion = Environment.OSVersion.ToString(),
        architecture = Environment.Is64BitOperatingSystem ? "x64" : "x86",
        environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production",
        dotnetVersion = Environment.Version.ToString(),
        frameworkDescription = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription,
        runtimeIdentifier = System.Runtime.InteropServices.RuntimeInformation.RuntimeIdentifier,
        memoryUsage = new
        {
            totalMemory = GC.GetTotalMemory(false) / 1024 / 1024, // in MB

            workingSet = Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024, // in MB
            privateMemory = Process.GetCurrentProcess().PrivateMemorySize64 / 1024 / 1024, // in MB
            virtualMemory = Process.GetCurrentProcess().VirtualMemorySize64 / 1024 / 1024 // in MB
        },
        cpuUsage = new
        {
            totalProcessorTime = Process.GetCurrentProcess().TotalProcessorTime.TotalMilliseconds, // in ms
            userProcessorTime = Process.GetCurrentProcess().UserProcessorTime.TotalMilliseconds, // in ms
            privilegedProcessorTime = Process.GetCurrentProcess().PrivilegedProcessorTime.TotalMilliseconds // in ms
        },
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
