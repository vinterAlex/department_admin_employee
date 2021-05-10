using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyUsers.Controllers
{

        public class RoleController : Controller
        {
            RoleManager<IdentityRole> roleManager;


            public RoleController(RoleManager<IdentityRole> roleManager)
            {
                this.roleManager = roleManager;
            }

            //[Authorize(Policy ="writepolicy")] --working fine as well.
            [Authorize(Roles = "Manager,Administrator")]
            public IActionResult Index()
            {
                var roles = roleManager.Roles.ToList();
                return View(roles);
            }

            [Authorize(Roles = "Manager,Administrator")]
            //[Authorize(Policy ="readpolicy")]
            public IActionResult Create()
            {
                return View(new IdentityRole());
            }


            [HttpPost]
            public async Task<IActionResult> Create(IdentityRole role)
            {
                await roleManager.CreateAsync(role);
                return RedirectToAction("Index");
            }
        }
    
}
