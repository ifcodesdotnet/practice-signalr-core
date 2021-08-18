using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signalr_core_demo.Utilities
{
    public class UserIdService : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return string.Empty; 
        }
    }
}
