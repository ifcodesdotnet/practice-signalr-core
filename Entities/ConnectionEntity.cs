﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signalr_core_demo.Entities
{
    public class ConnectionEntity
    {
        public string ConnectionID { get; set; }

        public string UserAgent { get; set; }

        public bool Connected { get; set; }

        public DateTime? InitiatedTimestamp { get; set; }

        public DateTime? DisconnectedTimestamp { get; set; }

        public UserEntity User { get; set; }
    }
}
