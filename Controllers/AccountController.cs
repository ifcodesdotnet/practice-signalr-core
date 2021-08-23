using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class AccountController : Controller
    {
        private readonly IHubContext<ChatHub> _chatHubContext;

        public AccountController(IHubContext<ChatHub> chatHubContext)
        {
            _chatHubContext = chatHubContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();

            try
            {
                using (ChatContext dbContext = new ChatContext())
                {
                    loginViewModel.UserEntityList = dbContext.Users.ToList();
                }
            }
            catch
            {
                loginViewModel = null;
            }

            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync([Bind(Prefix = "LoginDTO")] LoginDTO dtoModel)
        {
            if (ModelState.IsValid)
            {
                UserEntity userEntity = new UserEntity();

                using (ChatContext dbContext = new ChatContext())
                {
                    userEntity = dbContext.Users
                        .Where(x => x.EmailAddress == dtoModel.emailAddress)
                        .SingleOrDefault();
                }

                if (userEntity != null)
                {
                    Claim[] claims = new[] {
                                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(userEntity.Id), ClaimValueTypes.Integer32),
                                new Claim(ClaimTypes.Name, userEntity.FirstName + " " + userEntity.LastName, ClaimValueTypes.String),
                    };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, 
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(identity)); 

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    LoginViewModel loginViewModel = new LoginViewModel();

                    using (ChatContext dbContext = new ChatContext())
                    {
                        loginViewModel.UserEntityList = dbContext.Users.ToList();
                    }

                    loginViewModel.LoginDTO = dtoModel;

                    ModelState.AddModelError("emailAddress", "Email Address not found");

                    return View(loginViewModel); 
                }
            }
            else
            {
                LoginViewModel loginViewModel = new LoginViewModel();

                using (ChatContext dbContext = new ChatContext())
                {
                    loginViewModel.UserEntityList = dbContext.Users.ToList(); 
                }

                return View(dtoModel); 
            }
        }
    }
}
