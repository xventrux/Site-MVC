using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Site.Models.Entities;
using Site.ViewModels.Admin;
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
        public async Task<IActionResult> GetUsers(string search, string[] _roles)
        {
            List<User> users = await SearchUsers(_userManager.Users, search, _roles);

            List<string> roles = new List<string>();

            var list = _roleManager.Roles;

            foreach (var item in list)
            {
                roles.Add(item.Name);
            }


            return new JsonResult(new UsersTableViewModel { ListOfUsers = users, ListOfRoles = roles });
        }

        public async Task<List<User>> SearchUsers(IQueryable<User> users, string str, string[] roles)
        {
            List<User> list = new List<User>();

            if (String.IsNullOrEmpty(str))
            {
                list = users.ToList();
            }

            else
            {
                list = users.Where(u => u.Email.ToLower().Contains(str.ToLower()) || str.ToLower().Contains(u.Email.ToLower())).ToList();
            }

            for(int i = 0; i < list.Count; i++)
            {
                bool cond = false;

                foreach (string item in roles)
                {
                    if(await _userManager.IsInRoleAsync(list[i], item))
                    {
                        cond = true;
                        break;
                    }
                }

                if(!cond)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
            
            

            return list;
        }

        public async Task<IActionResult> ChangeRole(string id, string name)
        {
            User user = _userManager.Users.Where(u => u.Id == id).FirstOrDefault();

            if(user == null)
            {
                return new JsonResult("Пользователя не существует");
            }

            IdentityRole selectedRole = _roleManager.Roles.Where(r => r.Name == name).FirstOrDefault();

            if (selectedRole == null)
            {
                return new JsonResult("Роли не существует");
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);

            await _userManager.AddToRoleAsync(user, selectedRole.Name);

            return new JsonResult($"Роль пользователя {user.Email} успешно изменена на {name}");
        }
    }
}
