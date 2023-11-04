using MVCConsumeWCF.EmployeeService;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCConsumeWCF.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService.EmployeeTrackerClient _client
            = new EmployeeService.EmployeeTrackerClient();

        public EmployeeController()
        {

        }

        public ActionResult Index()
        {
            var employees = _client.GetAll();
            return View(employees);
        }

        public EmployeeService.Employee GetEmployeeById(int Id)
        {
            var employee = _client.GetById(Id);

            return employee;
        }

        public ActionResult Details(int Id)
        {
            var employee = GetEmployeeById(Id);

            return View(employee);
        }

        public ActionResult Update(int Id)
        {
            var employee = GetEmployeeById(Id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            _client.Update(employee.id, employee.name, Convert.ToDecimal(employee.salary));
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            var employee = GetEmployeeById(Id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            _client.Delete(employee.id);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            var employee = new Employee();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            _client.Insert(employee.name, Convert.ToDecimal(employee.salary));
            return RedirectToAction("Index");
        }


        public ActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public ActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}