using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace StudentsData.Application.ViewModels.Edit
{
    public class TeacherConfirmViewModel
    {
        [Required, MinLength(28), MaxLength(40)]
        public string Token { get; set; }
    }
}