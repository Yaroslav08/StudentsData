using System;
using System.Collections.Generic;
using System.Text;
namespace StudentsData.Application.ViewModels
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public List<StudentViewModel> Students { get; set; }
    }
}