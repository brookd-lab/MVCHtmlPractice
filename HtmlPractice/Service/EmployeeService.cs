using HtmlPractice.Data;
using HtmlPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HtmlPractice.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _context.Employees?.ToListAsync()!;
            return employees;
        }

        public async Task<Employee> GetEmployeeById(int Id)
        {
            var employee = await _context.Employees.FindAsync(Id);
            return employee;
        }

        public Task<Employee> Details(int Id)
        {
            var employee = GetEmployeeById(Id);
            return employee;
        }

        public async Task CreateEmployee(Employee employee)
        {   
            await _context.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(Employee employee)
        {
            _context.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
