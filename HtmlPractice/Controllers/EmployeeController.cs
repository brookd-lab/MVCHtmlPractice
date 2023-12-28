using HtmlPractice.Data;
using HtmlPractice.Models;
using HtmlPractice.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HtmlPractice.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService  _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _service.GetEmployees();
            return View(employees);
        }

        private async Task<Employee> GetEmployeeById(int Id)
        {
            var employee = await _service.GetEmployeeById(Id);
            return employee;
        }

        public async Task<IActionResult> Details(int Id)
        {
            var employee = await _service.GetEmployeeById(Id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public IActionResult Create()
        {
            var employee = new Employee();
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            await _service.CreateEmployee(employee);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int Id)
        {
            var employee = await GetEmployeeById(Id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Employee employee)
        {
            await _service.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var employee = await GetEmployeeById(Id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee employee)
        {
            await _service.DeleteEmployee(employee);
            return RedirectToAction("Index");
        }
    }
}
