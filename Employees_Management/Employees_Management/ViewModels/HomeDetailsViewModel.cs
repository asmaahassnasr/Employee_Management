using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employees_Management.Models;

namespace Employees_Management.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Employee Employee { get; set; }
        public string PageTitle { get; set; }
    }
}
