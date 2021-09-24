using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
namespace MediClinic.SignalRHub
{
    public class NotificationsHub : Hub
    {
        public async Task SendMessage(int userId, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",userId, message);
        }
    }
}
