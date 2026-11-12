namespace BlockingIPMiddleWareMinimalAPI;
public class IPBlockingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HashSet<string> _blockedIPs;

    public IPBlockingMiddleware(
        RequestDelegate next,
        IEnumerable<string> blockedIPs)
    {
        
        _next = next;
        _blockedIPs = new HashSet<string>(blockedIPs);
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var requestIP = context.Connection.RemoteIpAddress?.ToString();
        if (_blockedIPs.Contains(requestIP)) 
        {
            context.Response.StatusCode = 403;
            Console.WriteLine($"IP {requestIP} is blocked.");
            await context.Response.WriteAsync("Your IP is blocked.");
            return;
        }
        Console.WriteLine($"IP {requestIP} is allowed.");
        await _next(context);
    }
}
