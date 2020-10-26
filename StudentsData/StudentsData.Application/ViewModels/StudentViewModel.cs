using System;
using System.Collections.Generic;
using System.Text;
namespace StudentsData.Application.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string EmailAddress { get; set; }
        public string Passport { get; set; }
        public GroupViewModel Group { get; set; }
    }
}