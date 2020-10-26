using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
namespace StudentsData.Application.ViewModels
{
    public class TeacherViewModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Дата створення")]
        public DateTime CreatedAt { get; set; }
        [DisplayName("Повне ім'я")]
        public string Fullname { get; set; }
        [DisplayName("Нікнейм")]
        public string Username { get; set; }
        [DisplayName("Логін")]
        public string Login { get; set; }
        [DisplayName("Фото")]
        public string Avatar { get; set; }
    }
}