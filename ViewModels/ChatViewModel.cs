using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signalr_core_demo.ViewModels
{
    public class ChatViewModel
    {
        public MessageViewModel Message { get; set; }

        public UserViewModel User { get; set; }
    }
}
