using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Site.Models.Entities;
using Site.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

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

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email };

                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);

                    if(!String.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return RedirectToRoute(model.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
