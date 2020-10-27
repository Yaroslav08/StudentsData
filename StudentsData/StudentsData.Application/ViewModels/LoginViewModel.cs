using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace StudentsData.Application.ViewModels
{
    public class LoginViewModel
    {
        [Required, MinLength(5), MaxLength(100), DisplayName("Логін")]
        public string Login { get; set; }
        [Required, MinLength(8), MaxLength(100), DisplayName("Пароль")]
        public string Password { get; set; }
    }
}