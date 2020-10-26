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
        [Required]
        public bool IsConfirm { get; set; } = false;
        public DateTime? DateConfirm { get; set; }
        [Required]
        public string TokenConfirm { get; set; } = Guid.NewGuid().ToString("N");
        [MinLength(10), MaxLength(100)]
        public string Avatar { get; set; }
    }
}