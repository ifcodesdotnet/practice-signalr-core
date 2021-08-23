using Microsoft.AspNetCore.SignalR;
using signalr_core_demo.Data;
using signalr_core_demo.Entities;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace signalr_core_demo.Hubs
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            using (ChatContext dbContext = new ChatContext())
            {
                try
                {
                    UserEntity userEntity = dbContext.Users
                        .Include(x => x.Connections)
                        .SingleOrDefault(x => x.Id == Convert.ToInt32(Context.UserIdentifier));

                    userEntity.Connections.Add(new ConnectionEntity
                    {
                        ConnectionID = Context.ConnectionId,
                        UserAgent = Context.GetHttpContext().Request.Headers["User-Agent"],
                        Connected = true
                    });

                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            await Clients.All.SendAsync("UserOnline", Context.User.Identity.Name);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var omg = Context.ConnectionId; 
            using (ChatContext dbContext = new ChatContext())
            {
                ConnectionEntity connectionEntity = dbContext.Connections
                    .Find(Context.ConnectionId);

                connectionEntity.Connected = false;
                dbContext.SaveChanges();
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}