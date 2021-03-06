﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace StudentsData.Application.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Обов'язкове до заповнення"), MinLength(5, ErrorMessage = "Мінімальна довжина 5 символи"), MaxLength(100, ErrorMessage = "Максимальна довжина 100 символи"), EmailAddress, DisplayName("Логін")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Обов'язкове до заповнення"), MinLength(8, ErrorMessage = "Мінімальна довжина 8 символи"), MaxLength(100, ErrorMessage = "Максимальна довжина 100 символи"), DisplayName("Пароль"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}