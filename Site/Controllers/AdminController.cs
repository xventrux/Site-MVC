using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public AdminController(RoleManager<IdentityRole> roleManager, 
            UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Роли
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

        public async Task<IActionResult> RemoveRole(string name)
        {
            var role = _roleManager.Roles.Where(r => r.Name == name).FirstOrDefault();

            if(role != null)
                await _roleManager.DeleteAsync(role);

            return Ok();
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            List<User> list = _userManager.Users.ToList();

            return new JsonResult(list);
        }
    }
}
