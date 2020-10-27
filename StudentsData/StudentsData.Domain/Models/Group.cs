using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace StudentsData.Domain.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required, MinLength(2), MaxLength(20)]
        public string Name { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime DateStartEdu { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime DateEndEdu { get; set; }
        public List<Student> Students { get; set; }
    }
}