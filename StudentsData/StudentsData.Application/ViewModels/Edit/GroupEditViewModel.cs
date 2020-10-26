﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace StudentsData.Application.ViewModels.Edit
{
    public class GroupEditViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required, MinLength(2), MaxLength(20)]
        public string Name { get; set; }
    }
}