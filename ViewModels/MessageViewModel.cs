using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace signalr_core_demo.ViewModels
{
    public class MessageViewModel
    {
        [DisplayName("Message Content")]
        public string Content { get; set; }

        public DateTime? SentTimestamp { get; set; }
    }
}
