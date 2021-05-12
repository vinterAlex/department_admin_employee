using FunnyUsers.Data;
using FunnyUsers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FunnyUsers.Controllers
{
    public class UsersController : Controller
    {
        UserManager<IdentityUser> _userManager;
        ApplicationDbContext _db;
        RoleManager<IdentityRole> _roleManager;
        

        public UsersController(UserManager<IdentityUser> userManager,ApplicationDbContext db, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _db = db;
            _roleManager = roleManager;
            
        }

        

        //public async Task<ActionResult> ListUser()
        //{
        //    
        // 
        //}


        public IActionResult Index()
        {
            return View(_db.ApplicationUsers.ToList());
        }

      
        public IActionResult Create()
        {
        
        
        
            return View();
        }

  


        public IActionResult Edit(string userID) // need to make it string due to IdentityUser<string>
        {
            
            var user = _db.ApplicationUsers.Where(u => u.Id == userID).FirstOrDefault();
            return View(user);
        }




        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser() { UserName = model.Name };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                    
                   // await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var allRoles = _roleManager.Roles.ToList();

                    ViewBag.Roles = allRoles;
                    
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
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

        public async Task<IActionResult> Delete(string userId)
        {


            return View();
        }
    }
}
