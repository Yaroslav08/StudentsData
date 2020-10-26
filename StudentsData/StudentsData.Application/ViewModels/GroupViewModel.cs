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
        public List<StudentViewModel> Students { get; set; }
    }
}