using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using signalr_core_demo.Data;
using signalr_core_demo.DTO;
using signalr_core_demo.Entities;
using signalr_core_demo.Hubs;
using signalr_core_demo.Models;
using signalr_core_demo.ViewModels;

namespace signalr_core_demo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            UserEntity userEntity = new UserEntity(); 

            Claim nameIdentifierClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            using (ChatContext dbContext = new ChatContext())
            {
                userEntity = dbContext.Users
                    .Find(Convert.ToInt32(nameIdentifierClaim.Value)); 
            }

            ChatViewModel chatViewModel = new ChatViewModel() {
                User = new UserViewModel ()
                {
                    FirstName = userEntity.FirstName, 
                    LastName = userEntity.LastName, 
                    EmailAddress = userEntity.EmailAddress, 
                }, 
                Message = new MessageViewModel()
                {

                }
            };  

            return View(chatViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
