using FunnyUsers.Areas.Identity.Pages.Account;
using FunnyUsers.Data;
using FunnyUsers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyUsers.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _application;



        public HomeController(ApplicationDbContext application) 
        {
            _application = application;
        }

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Privacy()
        {
            

           return View(_application.Users.ToList());
           

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
