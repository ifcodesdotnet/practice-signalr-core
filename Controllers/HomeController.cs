using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using signalr_core_demo.Data;
using signalr_core_demo.DTO;
using signalr_core_demo.Entities;
using signalr_core_demo.Hubs;
using signalr_core_demo.Models;

namespace signalr_core_demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHubContext<ChatHub> _chatHubContext;


        public HomeController(ILogger<HomeController> logger, IHubContext<ChatHub> chatHubContext)
        {
            chatHubContext = _chatHubContext; 
            _logger = logger;
        }

        public async Task<ActionResult> LoginAsync(LoginDTO dtoModel)
        {
            Claim[] claims = new[] { 
                new Claim("emailAddress", dtoModel.emailAddress) 
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            await _chatHubContext.Clients.All.SendAsync("UserOnline"); 
            return View(); 
        }
        




        public IActionResult Index()
        {
            List<UserEntity> userEntityList = new List<UserEntity>(); 
            
            using ChatContext dbContext = new ChatContext();
            {
                userEntityList = dbContext.Users.ToList(); 
            }

            return View(userEntityList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
