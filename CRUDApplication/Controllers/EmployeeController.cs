using CRUDApplication.Data;
using CRUDApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var objList = _employeeRepository.Index();
            //IEnumerable<Employee> objList = _db.Employees;
            return View(objList);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Create(obj);
                return RedirectToAction("index");
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(Employee obj)
        {
            var employee = _employeeRepository.Delete(obj.Id);
            return View(employee);

        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var employee = _employeeRepository.DeletePost(id);

            return RedirectToAction("index");

        }

        [Authorize]
        [HttpGet]
        public IActionResult Update(int? id)
        {
            var employee = _employeeRepository.Update(id);


            return View(employee);

        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Employee obj)
        {
            var employee = _employeeRepository.Update(obj);

            return RedirectToAction("index");
        }
    }
}
