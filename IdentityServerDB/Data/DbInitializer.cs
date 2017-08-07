using IdentityServerDB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerDB.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //This example just creates an Administrator role and one Admin users
        public async void Initialize()
        {
            //create database schema if none exists
            _context.Database.EnsureCreated();

            //If there is already an Administrator role, abort
            if (_context.Roles.Any(r => r.Name == UserRolesEnum.Administrator.ToString())) return;

            //Create the Administartor Role
            await _roleManager.CreateAsync(new IdentityRole(UserRolesEnum.Administrator.ToString()));

            //super user
            string user = "superuser@hotmail.com";
            string password = "Password123)";
            await _userManager.CreateAsync(new ApplicationUser { UserName = user, Email = user, EmailConfirmed = true }, password);
            await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(user), UserRolesEnum.Administrator.ToString());

            //add all the roles
            await _roleManager.CreateAsync(new IdentityRole(UserRolesEnum.Director.ToString()));
            await _roleManager.CreateAsync(new IdentityRole(UserRolesEnum.Doctor.ToString()));
            await _roleManager.CreateAsync(new IdentityRole(UserRolesEnum.Manager.ToString()));
            await _roleManager.CreateAsync(new IdentityRole(UserRolesEnum.Technician.ToString()));
        }
    }
}
