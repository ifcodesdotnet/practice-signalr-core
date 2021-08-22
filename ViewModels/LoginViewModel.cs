using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using signalr_core_demo.DTO;
using signalr_core_demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signalr_core_demo.ViewModels
{
    public class LoginViewModel
    {
        public List<UserEntity> UserEntityList { get; set; }
        
        public LoginDTO LoginDTO { get; set; }
    }
}
