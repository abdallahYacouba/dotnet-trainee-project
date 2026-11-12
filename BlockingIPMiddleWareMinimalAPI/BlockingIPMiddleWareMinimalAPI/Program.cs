

using BlockingIPMiddleWareMinimalAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<string> _blockedIPs = new List<string>
{
    "192.168.1.12",
    "192.168.1.100",
    "192.168.1.89",
    "192.168.1.23",
    "192.168.1.246",
    "74.244.12.13",
    "2c0f:2a80:8f3:b608:4d45:3bc1:4fb4:7070",
};
app.MapGet("/", () => "Hello World!");
app.UseMiddleware<IPBlockingMiddleware>(_blockedIPs);

app.Run();
