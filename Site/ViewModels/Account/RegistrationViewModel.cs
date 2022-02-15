using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site.ViewModels.Account
{
    public class RegistrationViewModel
    {
        [Required (ErrorMessage = "Пожалуйста, введите свою электронную почту")]
        [Display(Name = "Электронная почта")]
        [DataType (DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свой пароль")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Пожалуйста, повторите свой пароль")]
        [Display(Name = "Подтвердите свой пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }

        public string ReturnUrl { get; set; }
    }
}
