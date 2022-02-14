using Microsoft.AspNetCore.Mvc;
using Site.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration(string returnUrl = null)
        {
            return View(new RegistrationViewModel() { ReturnUrl = returnUrl });
        }
    }
}
