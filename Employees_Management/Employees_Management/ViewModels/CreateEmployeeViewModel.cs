using Employees_Management.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Management.ViewModels
{
    public class CreateEmployeeViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 character")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Office Email")]
        [RegularExpression(@"[a-zA-Z0-9_.+-]+@[a-zA-Z0-9]+\.[a-zA-Z0-9_.]+$", ErrorMessage = "Email not valid")]
        public string Emial { get; set; }
        [Required]
        public Dept? Department { get; set; }
       
        //If it just on file
        //public IFormFile Photo { get; set; }
        //For multiple files .. 
        public List<IFormFile> Photos { get; set; }
    }
}
