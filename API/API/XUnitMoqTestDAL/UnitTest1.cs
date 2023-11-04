using APIConsumeDAL.Controllers;
using DAL.Model;
using DAL.Repository;
using Moq;

namespace XUnitMoqTestDAL
{
    public class UnitTest1
    {
        Mock<IEmployeeRepository> _mock = new Mock<IEmployeeRepository>();

        [Fact]
        public void GetAllEmployees()
        {
            var employeeDTO = new Employee()
            {
                Id = 1,
                Name = "JK",
                Salary = 32000.35m
            };
            List<Employee> employees = new List<Employee>();
            employees.Add(employeeDTO);
            _mock.Setup(p => p.GetAllEmployees()).Returns(employees);
            EmployeeController emp = new EmployeeController(_mock.Object);
            var result = emp.GetAllEmployees();
            Assert.True(employees.Equals(result));
        }

        [Fact]
        public void GetEmployeeById()
        {
            var employeeDTO = new Employee()
            {
                Id = 1,
                Name = "JK",
                Salary = 32000.35m
            };
            _mock.Setup(p => p.GetEmployeeById(10)).Returns(employeeDTO);
            EmployeeController emp = new EmployeeController(_mock.Object);
            var result = emp.GetEmployeeById(10);
            Assert.True(employeeDTO.Equals(result));
        }

        [Fact]
        public void InsertEmployee()
        {
            Employee employee = new Employee()
            {
                Name = "David",
                Salary = 120000.95m
            };
            var employeeDTO = new Employee()
            {   Id = 15, 
                Name = "JK",
                Salary = 32000.35m
            };
            _mock.Setup(p => p.InsertEmployee(employee)).Returns(employeeDTO);
            EmployeeController emp = new EmployeeController(_mock.Object);
            var result = emp.InsertEmployee(employee);
            Assert.True(employeeDTO.Equals(result));
        }

        [Fact]
        public void UpdateEmployee()
        {
            var employee = new Employee()
            {
                Id = 10,
                Name = "David Brook",
                Salary = 120000.57m
            };
            var employeeDTO = new Employee()
            {
                Id = 1,
                Name = "JK",
                Salary = 32000.35m
            };
            _mock.Setup(p => p.UpdateEmployee(employee)).Returns(employeeDTO);
            EmployeeController emp = new EmployeeController(_mock.Object);
            var result = emp.UpdateEmployee(employee);
            Assert.True(employeeDTO.Equals(result));
        }

        [Fact]
        public void DeleteEmployee()
        {   
            var employeeDTO = new Employee()
            {
                Id = 100,
                Name = "JK",
                Salary = 32000.35m
            };
            _mock.Setup(p => p.DeleteEmployee(100)).Returns(employeeDTO);
            EmployeeController emp = new EmployeeController(_mock.Object);
            var result = emp.DeleteEmployee(100);
            Assert.True(employeeDTO.Equals(result));
        }
    }
}