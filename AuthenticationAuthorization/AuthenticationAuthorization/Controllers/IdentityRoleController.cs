using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAuthorization.Controllers
{
    public class IdentityRoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;

        public IdentityRoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var result = _roleManager.CreateAsync(new IdentityRole("Admin")).Result;
            if (result.Succeeded)
            {

            }
            return Json(_roleManager.Roles.ToList());
        }

        public async Task<IActionResult> CreateAsync(string roleName)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
            //var result = _roleManager.CreateAsync(new IdentityRole("Admin")).Result;
            //if (result.Succeeded)
            //{

            //}
            return Json(_roleManager.Roles.ToList());
        }
    }
}