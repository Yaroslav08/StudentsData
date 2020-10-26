using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace StudentsData.Application.ViewModels.Create
{
    public class GroupCreateViewModel
    {
        [Required, MinLength(2), MaxLength(20)]
        public string Name { get; set; }
    }
}