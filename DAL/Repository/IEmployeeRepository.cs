using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAllEmployees();
        public Employee? GetEmployeeById(int id);
        public Employee InsertEmployee(Employee employee);
        public Employee UpdateEmployee(Employee employee);
        public Employee DeleteEmployee(int id);
    }
}
