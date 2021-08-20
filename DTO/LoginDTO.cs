using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace signalr_core_demo.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Please enter an email address.")]
        public string emailAddress { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        public string password { get; set; }
    }
}
