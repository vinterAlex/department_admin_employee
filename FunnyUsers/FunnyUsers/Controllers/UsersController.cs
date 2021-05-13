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


          public UsersController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager, ApplicationDbContext db,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _roleManager = roleManager;
        }
        //public UsersController(UserManager<IdentityUser> userManager,ApplicationDbContext db, RoleManager<IdentityRole> roleManager,ApplicationUser appUser)
        //{
        //    _userManager = userManager;
        //    _db = db;
        //    _roleManager = roleManager;
        //    //_appUser = appUser;
        //    
        //}

        




        public IActionResult Index()
        {
            return View(_db.ApplicationUsers.ToList());
        }

      


  


        public IActionResult Edit(string userID) // need to make it string due to IdentityUser<string>
        {
            
            var user = _db.ApplicationUsers.Where(u => u.Id == userID).FirstOrDefault();
            return View(user);
        }






        
        public async Task<ActionResult> Create()
        {
            return View();
            //return View("Identity/Account/Register");

        }

        [HttpPost]
        public IActionResult Edit(ApplicationUser userModel)
        {
            //IList<IdentityRole> listOfRoles = new List<IdentityRole>();
            
        
        
            var userToEdit = _db.ApplicationUsers.Where(us => us.Id == userModel.Id).FirstOrDefault();
        
            //foreach(var roles in _roleManager.Roles.ToList())
            //{
            //    listOfRoles.Add(roles);
            //}
        
            //var currentRole = _userManager.GetRolesAsync(userToEdit);
        
            userToEdit.UserName = userModel.UserName;
            userToEdit.Email = userModel.Email;
            userToEdit.Department = userModel.Department;
            userToEdit.Role = userModel.Role;
        
            //_userManager.RemoveFromRolesAsync(userToEdit, currentRole.Result.ToList());
            //_userManager.AddToRoleAsync(userToEdit, role.Result.Name);
            
        
            var result = _db.Update(userToEdit);
        
            ViewData["roles"] = _roleManager.Roles.ToList();
            return View(userToEdit);
        }



    }
}
