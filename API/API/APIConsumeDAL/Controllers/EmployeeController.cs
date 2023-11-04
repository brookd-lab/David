using DAL.Model;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIConsumeDAL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;
        //private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeRepository repo
            )
        {
            _repo = repo;
            //_logger = logger;
        }
        [HttpGet]
        public List<Employee> GetAllEmployees()
        {
            var employees = _repo.GetAllEmployees();
            return employees;
        }
        [HttpGet("{id}")]
        public Employee? GetEmployeeById(int id)
        {
            var employee = _repo.GetEmployeeById(id);
            return employee;
        }
        [HttpPut]
        public Employee UpdateEmployee(Employee employee)
        {
            return _repo.UpdateEmployee(employee);
        }
        [HttpPost]
        public Employee InsertEmployee(Employee employee)
        {
            return _repo.InsertEmployee(employee);
        }
        [HttpDelete]
        public Employee DeleteEmployee(int id)
        {
            return _repo.DeleteEmployee(id);
        }
    }
}