using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
namespace StudentsData.Application.ViewModels
{
    public class GroupViewModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Дата створення")]
        public DateTime CreatedAt { get; set; }
        [DisplayName("Назва групи")]
        public string Name { get; set; }
        [DisplayName("Початку навчання")]
        public DateTime DateStartEdu { get; set; }
        [DisplayName("Кінця навчання")]
        public DateTime DateEndEdu { get; set; }
        [DisplayName("Студенти")]
        public List<StudentViewModel> Students { get; set; }
    }
}