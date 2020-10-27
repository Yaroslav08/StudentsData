using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace StudentsData.Application.ViewModels.Create
{
    public class StudentCreateViewModel
    {
        [Required, MinLength(2), MaxLength(25), DisplayName("Ім'я")]
        public string Firstname { get; set; }
        [Required, MinLength(2), MaxLength(25), DisplayName("По-батькові")]
        public string Middlename { get; set; }
        [Required, MinLength(2), MaxLength(25), DisplayName("Прізвище")]
        public string Lastname { get; set; }
        [MinLength(5), MaxLength(250), DisplayName("Фото")]
        public string Photo { get; set; }
        [Required, MinLength(5), MaxLength(25), DisplayName("Адреса")]
        public string Address { get; set; }
        [Required, MinLength(5), MaxLength(100), Phone, DisplayName("Мобільний телефон")]
        public string MobilePhone { get; set; }
        [Required, EmailAddress, MaxLength(100), DisplayName("Поштова адреса")]
        public string EmailAddress { get; set; }
        [MinLength(5), MaxLength(250), DisplayName("Дані паспорта")]
        public string Passport { get; set; }
        [DisplayName("Група")]
        public int GroupId { get; set; }
    }
}