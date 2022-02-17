using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site.ViewModels.Account
{
    public class CabinetViewModel
    {
        public string Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свой старый пароль")]
        [Display(Name = "Старый пароль")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свой новый пароль")]
        [Display(Name = "Новый пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Пожалуйста, повторите свой новый пароль")]
        [Display(Name = "Подтвердите свой новый пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
    }
}
