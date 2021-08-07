using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Management.Models
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Emp001", Emial = "emp1@gmail.com", Department = Dept.HR },
                new Employee { Id = 2, Name = "Emp002", Emial = "emp2@gmail.com", Department = Dept.IT },
                new Employee { Id = 3, Name = "Emp003", Emial = "emp3@gmail.com", Department = Dept.Payroll }
                );
        }
    }
}
