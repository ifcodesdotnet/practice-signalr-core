using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using signalr_core_demo.Data;
using signalr_core_demo.Entities;
using signalr_core_demo.Models;

namespace signalr_core_demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            User ismael = new User();
            ismael.firstName = "Ismael"; 

            using ChatContext dbContext = new ChatContext(); 
            {
                dbContext.Add(ismael);
                dbContext.SaveChanges(); 
            }

            List<User> list = new List<User>(); 
            using ChatContext dbContext2 = new ChatContext();
            {
                list = dbContext2.User.ToList(); 
            }

            return View();
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
