using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace StudentsData.Application.ViewModels.Create
{
    public class GroupCreateViewModel
    {
        [Required(ErrorMessage = "Обов'язкове до заповнення"), MinLength(2, ErrorMessage = "Мінімальна довжина 2 символи"), MaxLength(20, ErrorMessage = "Максимальна довжина 20 символи"), DisplayName("Ім'я")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Обов'язкове до заповнення"), DataType(DataType.Date), DisplayName("Початок навчання")]
        public DateTime DateStartEdu { get; set; }
        [Required(ErrorMessage = "Обов'язкове до заповнення"), DataType(DataType.Date), DisplayName("Кінець навчання")]
        public DateTime DateEndEdu { get; set; }
    }
}