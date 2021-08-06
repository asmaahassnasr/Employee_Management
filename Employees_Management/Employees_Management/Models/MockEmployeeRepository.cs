using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Management.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        List<Employee> emps = new List<Employee>()
        {
            new Employee{Id=1, Name="Asmaa 1" , Emial="asma@gmail.com", Department=Dept.HR},
            new Employee{Id=2, Name="Asmaa 2" , Emial="asma@gmail.com", Department=Dept.IT},
            new Employee{Id=3, Name="Asmaa 3" , Emial="asma@gmail.com", Department=Dept.Payroll},
            new Employee{Id=4, Name="Asmaa 4" , Emial="asma@gmail.com", Department=Dept.HR}
        };

        public Employee Add(Employee employee)
        {
            employee.Id = emps.Max(e => e.Id) + 1;
            emps.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return emps;
        }

        public Employee GetEmployee(int id)
        {
            return emps.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(Employee employeeChanges)
        {
            throw new NotImplementedException();
        }
    }
}
