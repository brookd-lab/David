using DAL.Repository;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MVCEmployee.Models;

namespace MVCEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _repo;
        private List<Employee> _employees;

        public EmployeeController(IEmployeeRepository repo,
            ILogger<EmployeeController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _employees = _repo.GetAllEmployees();
            return View(_employees);
        }

        public Employee? GetEmployeeById(int Id)
        {
            Employee? employee = _repo.GetEmployeeById(Id);

            return employee;
        }

        public IActionResult Details(int Id)
        {
            var employee = GetEmployeeById(Id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public IActionResult Update(int Id)
        {
            var employee = GetEmployeeById(Id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            var data = GetEmployeeById(employee.Id);
            
            if (data != null)
            {
                data.Name = employee.Name;
                data.Salary = employee.Salary;
                _repo.UpdateEmployee(data);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var employee = GetEmployeeById(Id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            _repo.DeleteEmployee(employee.Id);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            var employee = new Employee();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _repo.InsertEmployee(employee);
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}