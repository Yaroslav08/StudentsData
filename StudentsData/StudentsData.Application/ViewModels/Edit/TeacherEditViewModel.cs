using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace StudentsData.Application.ViewModels.Edit
{
    public class TeacherEditViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required, MinLength(5), MaxLength(50), DisplayName("Повне ім'я")]
        public string Fullname { get; set; }
        [MinLength(4), MaxLength(25), DisplayName("Нікнейм")]
        public string Username { get; set; }
        [MinLength(10), MaxLength(100), DisplayName("Фото")]
        public string Avatar { get; set; }
    }
}