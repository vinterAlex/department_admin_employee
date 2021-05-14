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
        //public ApplicationUser _appUser { get; set; }
        public CreateUserModel createModel { get; set; }


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
            //this uses a redirect from View to Register.cshtml from Identity area
            return View();


        }





        //public IActionResult Edit(string userID) // need to make it string due to IdentityUser<string>
        //{
        //
        //    var user = _db.ApplicationUsers.Where(u => u.Id == userID).FirstOrDefault();
        //   // var user = _db.ApplicationUsers.ToList();
        //    return View(user);
        //}


        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            var userToEdit = _db.ApplicationUsers.Where(p => p.Id == id).FirstOrDefault();
            
            var user = new ApplicationUser()
            {
                UserName = userToEdit.UserName,
                Email = userToEdit.Email,
                Department = userToEdit.Department,
                Role = userToEdit.Role
            };

            return View(user);
        } //works, leave it that way

        [HttpPost]
        public async Task<ActionResult> Edit(ApplicationUser model)
        {
            var userToEdit = _db.ApplicationUsers.Where(p => p.Id == model.Id).FirstOrDefault();

            userToEdit.UserName = model.UserName;
            userToEdit.Email = model.Email;
            userToEdit.Department = model.Department;
            userToEdit.Role = model.Role;

            var result = await _userManager.UpdateAsync(userToEdit);


            if (result.Succeeded)
            {
                return RedirectToAction("Index", _db.ApplicationUsers.ToList());
            }



            return View(model);
            //return RedirectToAction("Index", _db.ApplicationUsers.ToList());
        }

        /* WORKS FINE BUT NEED TO EDIT THE "EDIT" VIEW as it not takes the POST, it's taking it only if you INPUT it manually in URL*/

        [HttpPost]
        public async Task<ActionResult> DeleteUser(string id)
        {
            var user = _db.ApplicationUsers.Where(p => p.Id == id).FirstOrDefault();
            
            var result = await _userManager.DeleteAsync(user);

            return View("Index", _db.ApplicationUsers.ToList());


        }

    }
}
