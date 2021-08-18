﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signalr_core_demo.Entities
{
    public class UserActivityStatusEntity
    {
        public int id { get; set; }

        public string userDeviceIpAddress { get; set; }

        public DateTime lastOnlineTimestamp { get; set; }
    }
}
