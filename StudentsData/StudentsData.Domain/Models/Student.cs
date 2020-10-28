using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace StudentsData.Domain.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required, MinLength(2), MaxLength(25)]
        public string Firstname { get; set; }
        [Required, MinLength(2), MaxLength(25)]
        public string Middlename { get; set; }
        [Required, MinLength(2), MaxLength(25)]
        public string Lastname { get; set; }
        [MinLength(5), MaxLength(250)]
        public string Photo { get; set; }
        [Required, MinLength(5), MaxLength(150)]
        public string Address { get; set; }
        [Required, MinLength(5), MaxLength(100), Phone]
        public string MobilePhone { get; set; }
        [Required, EmailAddress, MaxLength(100)]
        public string EmailAddress { get; set; }
        [MinLength(5), MaxLength(250)]
        public string Passport { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}