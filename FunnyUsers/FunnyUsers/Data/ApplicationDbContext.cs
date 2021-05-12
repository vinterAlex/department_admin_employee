using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FunnyUsers.Models;
using Microsoft.AspNetCore.Identity;

namespace FunnyUsers.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers{ get; set; } 
        public DbSet<FunnyUsers.Models.CreateUserModel> CreateUserModel { get; set; }
        //public DbSet<IdentityUser> IdentityUser { get; set; }
    }

    
}
