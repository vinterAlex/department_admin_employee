using FunnyUsers.Areas.Identity.Pages.Account;
using FunnyUsers.Data;
using FunnyUsers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FunnyUsers.Controllers
{
    public class UsersController : Controller
    {
        //UserManager<IdentityUser> _userManager;
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        ApplicationDbContext _db;
        RoleManager<IdentityRole> _roleManager;
        //ApplicationUser _appUser;


        public UsersController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext db, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _roleManager = roleManager;
        }







        public IActionResult Index()
        {
            return View(_db.ApplicationUsers.ToList()); //works fine
            //return View(_userManager.Users.ToList());
        }


        public async Task<ActionResult> Create()
        {
            return View();


        }





        public IActionResult Edit(string userID) // need to make it string due to IdentityUser<string>
        {

            var user = _db.ApplicationUsers.Where(u => u.Id == userID).FirstOrDefault();
           // var user = _db.ApplicationUsers.ToList();
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ApplicationUser userModel, string id)
        {

            return RedirectToAction("Index");
        }

        //public async Task<ActionResult> DeleteUser(string id)
        //{
        //    var user = _db.ApplicationUsers.Where(u => u.Id == id).FirstOrDefault();
        //    return RedirectToAction();
        //}

        [HttpPost]
        public async Task<ActionResult>DeleteUser(string userId)
        {
            var user = _db.ApplicationUsers.ToList().FirstOrDefault(); //works but it deletes only the first one...
            //var user = _db.ApplicationUsers.ToList().FirstOrDefault(x=>x.Id==userId);//.Where(u => u.Id == userId);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");

            }

            return View("Index");


        }

    }
}
