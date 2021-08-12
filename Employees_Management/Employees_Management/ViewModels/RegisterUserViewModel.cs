using Employees_Management.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Management.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [EmailAddress]
        //Remote Validation From Server 
        [Remote(action: "IsEmailInUse",controller:"Account")]
        //Custom Validation Attr from client
        [ValidEmailDomainAttribute(allowDomain:"gmail.com",ErrorMessage ="Must be gmail account")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password", ErrorMessage ="Doesnot match")]
        public string ConfirmPassword { get; set; }

    }
}
