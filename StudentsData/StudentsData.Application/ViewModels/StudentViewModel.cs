using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
namespace StudentsData.Application.ViewModels
{
    public class StudentViewModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Дата створення")]
        public DateTime CreatedAt { get; set; }
        [DisplayName("Ім'я")]
        public string Firstname { get; set; }
        [DisplayName("По-батькові")]
        public string Middlename { get; set; }
        [DisplayName("Прізвище")]
        public string Lastname { get; set; }
        [DisplayName("Фото")]
        public string Photo { get; set; }
        [DisplayName("Адреса")]
        public string Address { get; set; }
        [DisplayName("Мобільний телефон")]
        public string MobilePhone { get; set; }
        [DisplayName("Електронна адреса")]
        public string EmailAddress { get; set; }
        [DisplayName("Паспортні дані")]
        public string Passport { get; set; }
        public GroupViewModel Group { get; set; }
    }
}