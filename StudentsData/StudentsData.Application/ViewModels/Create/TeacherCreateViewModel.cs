using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace StudentsData.Application.ViewModels.Create
{
    public class TeacherCreateViewModel
    {
        [Required, MinLength(5), MaxLength(50), DisplayName("Повне ім'я")]
        public string Fullname { get; set; }
        [Required, MinLength(5), MaxLength(100), EmailAddress, DisplayName("Логін")]
        public string Login { get; set; }
        [Required, MinLength(10), MaxLength(1000), DisplayName("Пароль")]
        public string Password { get; set; }
    }
}