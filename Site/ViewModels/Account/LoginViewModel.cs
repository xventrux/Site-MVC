using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required (ErrorMessage = "Пожалуйста, введите свой адрес электронной почты")]
        [Display (Name = "Электронная почта")]
        [DataType (DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свой пароль")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
