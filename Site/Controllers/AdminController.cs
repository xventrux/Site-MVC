using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRoleAsync(string name)
        {
            await _roleManager.CreateAsync(new IdentityRole(name.ToLower()));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            List<string> roles = new List<string>();

            var list = _roleManager.Roles;

            foreach(var item in list)
            {
                roles.Add(item.Name);
            }

            return new JsonResult(roles);
        }
    }
}
