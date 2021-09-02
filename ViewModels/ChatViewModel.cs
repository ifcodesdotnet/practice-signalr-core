using signalr_core_demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signalr_core_demo.ViewModels
{
    public class ChatViewModel
    {
        public UserViewModel CurrentUser { get; set; }

        public List<UserViewModel> UserList { get; set; }

        public MessageViewModel Message { get; set; }
    }
}
