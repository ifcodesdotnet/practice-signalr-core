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
            //using ChatContext dbContext = new ChatContext();
            //{
            //    UserEntity userEntity = dbContext.Users
            //                                     .Where(x => x.firstName == firstName)
            //                                     .FirstOrDefault(); 
            //}
            
            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}