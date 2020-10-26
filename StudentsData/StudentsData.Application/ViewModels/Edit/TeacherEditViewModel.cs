using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace StudentsData.Application.ViewModels.Edit
{
    public class TeacherEditViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string Fullname { get; set; }
        [MinLength(4), MaxLength(25)]
        public string Username { get; set; }
        [MinLength(10), MaxLength(100)]
        public string Avatar { get; set; }
    }
}