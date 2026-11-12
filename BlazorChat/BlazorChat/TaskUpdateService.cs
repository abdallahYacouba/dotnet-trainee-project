namespace BlazorChat;

using BlazorChat.Hubs;
//using global::RealTimeBlazorApp.Hubs;
using Microsoft.AspNetCore.SignalR;


public class TaskUpdateService
{
    private readonly IHubContext<NotificationHub> _hubContext;

    public TaskUpdateService(IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task NotifyTaskUpdatedAsync(string taskName, string status)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveChange", "Task Updated", $"{taskName} is now {status}");
    }
}
