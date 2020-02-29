using MySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySite.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> allEmp = new List<Employee>()
        {
            new Employee{ EmployeeId = 1, EmployeeName="Sam", Salary=15000 },
            new Employee{ EmployeeId = 1, EmployeeName="Tom", Salary=16000 },
            new Employee{ EmployeeId = 1, EmployeeName="John", Salary=11000 },
            new Employee{ EmployeeId = 1, EmployeeName="Salm", Salary=17000 }
        };

        // GET: Employee
        public ActionResult Index()
        {
            return View(allEmp);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            allEmp.Add(emp);
            return RedirectToAction("Index");
        }

        public ActionResult ViewAll()
        {
            return View(allEmp);
        }
    }
}