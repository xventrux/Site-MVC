using Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.ViewModels.Admin
{
    public class UsersTableViewModel
    {
        public List<UserViewModel> ListOfUsers { get; set; }

        public List<string> ListOfRoles { get; set; }
    }
}
