using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Employee> __Employees = new List<Employee>
        {
           new Employee
           {
               Id = 1,
               Surname = "Ivanov",
               Name = "Ivan",
               Patronymic = "Ivanovich",
               Age = 39,
               BirthYear = 1981,
               EmployementYear = 2017
           },
            new Employee
           {
               Id = 2,
               Surname = "Petrov",
               Name = "Petr",
               Patronymic = "Petrovich",
               Age = 27,
               BirthYear = 1993,
               EmployementYear = 2014
           },
            new Employee
           {
               Id = 3,
               Surname = "Sidorov",
               Name = "Sidor",
               Patronymic = "Sidorovich",
               Age = 18,
               BirthYear = 2002,
               EmployementYear = 2020
           },
        };
        public IActionResult Index() => View();

        public IActionResult Employees()
        {
            ViewBag.Title = "123";
            ViewData["TestValue"] = "Value - test";

            var employees = __Employees;
            return View(employees);
        }

        public IActionResult EmployeeInfo(int id)
        {
            var employee = __Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null)
                return NotFound();

            return View(employee);
        }
    }
}
