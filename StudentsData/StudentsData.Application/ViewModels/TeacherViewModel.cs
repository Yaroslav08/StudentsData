using System;
using System.Collections.Generic;
using System.Text;
namespace StudentsData.Application.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Login { get; set; }
        public string Avatar { get; set; }
    }
}