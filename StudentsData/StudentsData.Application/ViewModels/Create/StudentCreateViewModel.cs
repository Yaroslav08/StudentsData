using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace StudentsData.Application.ViewModels.Create
{
    public class StudentCreateViewModel
    {
        [Required(ErrorMessage = "Обов'язкове до заповнення"), MinLength(2, ErrorMessage = "Мінімальна довжина 2 символи"), MaxLength(25, ErrorMessage = "Максимальна довжина 25 символи"), DisplayName("Ім'я")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Обов'язкове до заповнення"), MinLength(2, ErrorMessage = "Мінімальна довжина 2 символи"), MaxLength(25, ErrorMessage = "Максимальна довжина 25 символи"), DisplayName("По-батькові")]
        public string Middlename { get; set; }
        [Required(ErrorMessage = "Обов'язкове до заповнення"), MinLength(2, ErrorMessage = "Мінімальна довжина 2 символи"), MaxLength(25, ErrorMessage = "Максимальна довжина 25 символи"), DisplayName("Прізвище")]
        public string Lastname { get; set; }
        [MinLength(5, ErrorMessage = "Мінімальна довжина 5 символи"), MaxLength(250, ErrorMessage = "Максимальна довжина 250 символи"), DisplayName("Фото")]
        public string Photo { get; set; }
        [Required(ErrorMessage = "Обов'язкове до заповнення"), MinLength(5, ErrorMessage = "Мінімальна довжина 5 символи"), MaxLength(150, ErrorMessage = "Максимальна довжина 150 символи"), DisplayName("Адреса")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Обов'язкове до заповнення"), MinLength(5, ErrorMessage = "Мінімальна довжина 5 символи"), MaxLength(100, ErrorMessage = "Максимальна довжина 100 символи"), Phone(ErrorMessage = "Має бути мобільний телефон"), DisplayName("Мобільний телефон")]
        public string MobilePhone { get; set; }
        [Required(ErrorMessage = "Обов'язкове до заповнення"), EmailAddress(ErrorMessage = "Має бути електронна адреса"), MaxLength(100, ErrorMessage = "Максимальна довжина 100 символи"), DisplayName("Поштова адреса")]
        public string EmailAddress { get; set; }
        [MinLength(5, ErrorMessage = "Мінімальна довжина 5 символи"), MaxLength(250), DisplayName("Дані паспорта")]
        public string Passport { get; set; }
        [DisplayName("Група")]
        public int GroupId { get; set; }
    }
}