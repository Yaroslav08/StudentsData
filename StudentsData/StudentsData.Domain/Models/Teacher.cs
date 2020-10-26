using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace StudentsData.Domain.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required, MinLength(5), MaxLength(50)]
        public string Fullname { get; set; }
        [MinLength(4), MaxLength(25)]
        public string Username { get; set; }
        [Required, MinLength(5), MaxLength(100), EmailAddress]
        public string Login { get; set; }
        [Required, MinLength(10), MaxLength(1000)]
        public string PasswordHash { get; set; }
        [MinLength(10), MaxLength(100)]
        public string Avatar { get; set; }
    }
}