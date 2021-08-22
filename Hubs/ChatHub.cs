using Microsoft.AspNetCore.SignalR;
using signalr_core_demo.Data;
using signalr_core_demo.Entities;
using System.Threading.Tasks;
using System.Linq; 

namespace signalr_core_demo.Hubs
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
    }
}