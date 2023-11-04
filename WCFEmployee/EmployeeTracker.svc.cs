using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace WCFEmployee
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeTracker : IEmployeeTracker
    {
        public ApplicationDbContext Context { get; set; } = new ApplicationDbContext();

        public List<Employee> GetAll()
        {   
            List<Employee> employees = Context.Employees.ToList();
            return employees;
        }

        public Employee GetById(int id)
        {
            Employee employee = Context.Employees.Find(id);
            return employee;
        }
        public Employee Insert(string name, decimal salary)
        {
            Employee employee = new Employee() { name = name, salary = salary };
            Context.Employees.Add(employee);
            Context.SaveChanges();
            return employee;
        }

        public Employee Update(int id, string name, decimal salary)
        {
            Employee employee = Context.Employees.Find(id);
            employee.name = name;
            employee.salary = salary;
            Context.Employees.AddOrUpdate(employee);
            Context.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = Context.Employees.Find(id);

            if (employee != null)
            {
                Context.Employees.Remove(employee);
                Context.SaveChanges();
            }

            return employee;
        }
    }
}
