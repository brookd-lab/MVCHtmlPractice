using HtmlPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HtmlPractice.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployeeById(int Id);

        Task<Employee> Details(int Id);

        Task CreateEmployee(Employee employee);

        Task UpdateEmployee(Employee employee);

        Task DeleteEmployee(Employee employee);
    }
}

