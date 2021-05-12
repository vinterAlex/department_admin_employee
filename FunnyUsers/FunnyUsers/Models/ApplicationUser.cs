using FunnyUsers.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static FunnyUsers.Areas.Identity.Pages.Account.RegisterModel;

namespace FunnyUsers.Models
{
    public class ApplicationUser : IdentityUser
    {
        

        // new column in AspNetusers table - migration
        public string Department { get; set; }

        public string Role { get; set; }

        

        //public IEnumerable<SelectListItem> rolesList { get; set; }
        
        



        
    }
}
