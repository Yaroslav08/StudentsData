using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace StudentsData.Application.ViewModels.Edit
{
    public class TeacherConfirmViewModel
    {
        [Required(ErrorMessage = "Обов'язкове до заповнення"), MinLength(28, ErrorMessage = "Мінімальна довжина 28 символи"), MaxLength(40, ErrorMessage = "Максимальна довжина 40 символи")]
        public string Token { get; set; }
    }
}