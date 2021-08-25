using signalr_core_demo.DTO;
using signalr_core_demo.Entities;
using System.Collections.Generic;

namespace signalr_core_demo.ViewModels
{
    public class LoginViewModel
    {
        public List<UserEntity> UserEntityList { get; set; }
        
        public LoginDTO LoginDTO { get; set; }
    }
}
