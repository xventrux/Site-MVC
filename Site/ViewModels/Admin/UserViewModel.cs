using Microsoft.AspNetCore.Identity;
using Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.ViewModels.Admin
{
    public class UserViewModel
    {
        public User User { get; set; }

        public string Role { get; set; }

        public static async Task<List<UserViewModel>> CreateList(List<User> users, UserManager<User> userManager)
        {
            List<UserViewModel> list = new List<UserViewModel>();

            foreach(var item in users)
            {
                string role = ((List<string>)await userManager.GetRolesAsync(item)).FirstOrDefault();
                list.Add(new UserViewModel() { User = item, Role = role });
            }

            return list;
        }
    }
}
