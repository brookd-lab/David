using DAL.Repository;
using Moq;
using DAL.Model;
using System;

namespace UnitTestProject
{
    public class UnitTestController
    {
        private readonly IEmployeeRepository _repo;
        public UnitTestController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        private List<Employee> GetData()
        {
            return _repo.GetAllEmployees();
        }

        [Fact]
        public void GetEmployeesTest()
        {
            // arrange
            var service = new Mock<IEmployeeRepository>();

            var employees = GetData();
            service.Setup(x => x.GetAllEmployees()).Returns(employees);

            // Act
            Assert.True(employees.Count > 0, "Expect multiple employees");
        }

    }
}