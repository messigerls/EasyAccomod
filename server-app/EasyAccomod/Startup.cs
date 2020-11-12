﻿using System;
using System.Collections.Generic;
using System.Linq;
using EasyAccomod.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(EasyAccomod.Startup))]

namespace EasyAccomod
{
    public partial class Startup
    {
        private ApplicationDbContext _context;

        public Startup()
        {
            _context = new ApplicationDbContext();
        }

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        public void CreateRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole("Admin");
                roleManager.Create(role);

                var user = new ApplicationUser
                {
                    Email = "admin@admin.com",
                    UserName = "Admin"
                };

                string userPassword = "Admin1234.";

                var result = userManager.Create(user, userPassword);

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Owner"))
            {
                var role = new IdentityRole("Owner");
                roleManager.Create(role);
            }
        }
    }
}