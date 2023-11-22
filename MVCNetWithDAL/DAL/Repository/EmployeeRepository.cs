using DAL.Data;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context= context;
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = _context.Employee.ToList();
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _context.Employee.Find(id);
            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee employee = GetEmployeeById(id);
            _context.Employee.Remove(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee InsertEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
            return employee;
        }



    }
}
