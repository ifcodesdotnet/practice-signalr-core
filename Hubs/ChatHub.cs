using Microsoft.AspNetCore.SignalR;
using signalr_core_demo.Data;
using signalr_core_demo.Entities;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using signalr_core_demo.ViewModels;
using System.Collections.Generic;

namespace signalr_core_demo.Hubs
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            UserViewModel userViewModel = new UserViewModel(); 

            using (ChatContext dbContext = new ChatContext())
            {
                try
                {
                    UserEntity userEntity = await dbContext.Users
                        .Include(x => x.Connections)
                        .SingleOrDefaultAsync(x => x.Id == Convert.ToInt32(Context.UserIdentifier));

                    userEntity.Connections.Add(new ConnectionEntity {
                        ConnectionID = Context.ConnectionId,
                        UserAgent = Context.GetHttpContext().Request.Headers["User-Agent"],
                        InitiatedTimestamp = DateTime.Now,
                        Connected = true
                    });

                    #region Mapping ViewModel to Entity
                    userViewModel.EmailAddress = userEntity.EmailAddress; 
                    userViewModel.FirstName = userEntity.FirstName; 
                    userViewModel.LastName = userEntity.LastName; 
                    userViewModel.Id = userEntity.Id;
                    #endregion

                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            await Clients.All.SendAsync("UserOnline", userViewModel);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            UserViewModel userViewModel = new UserViewModel();

            using (ChatContext dbContext = new ChatContext())
            {
                ConnectionEntity connectionEntity = dbContext.Connections
                    .Find(Context.ConnectionId);

                dbContext.Entry(connectionEntity)
                    .Reference(x => x.User).Load();

                UserEntity userEntity = connectionEntity
                    .User; 

                connectionEntity.Connected = false;
                connectionEntity.DisconnectedTimestamp = DateTime.Now;

                #region Mapping ViewModel to Entity
                userViewModel.EmailAddress = userEntity.EmailAddress;
                userViewModel.FirstName = userEntity.FirstName;
                userViewModel.LastName = userEntity.LastName;
                userViewModel.Id = userEntity.Id;
                #endregion

                dbContext.SaveChanges();
            }

            await Clients.All.SendAsync("UserOffline", userViewModel);
            await base.OnDisconnectedAsync(exception);
        }
        
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", Context.User.Identity.Name, message);
        }
    }
}